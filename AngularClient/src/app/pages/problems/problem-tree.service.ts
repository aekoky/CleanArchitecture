import { Injectable } from '@angular/core';
import { BehaviorSubject, filter, map, Observable, of, shareReplay, switchMap, take, tap } from 'rxjs';
import { TreeService } from 'app/shared/modules/tree/tree.interface';
import { NodeLevel, TreeNode } from 'app/shared/modules/tree/tree.model';
import { ProblemService } from './problem.service';
import { ViewMode } from 'app/shared/enums/view-mode.enum';
import { ProblemCatalogDto, ProblemCategoryDto } from 'app/web-api-client';
import { DialogService } from 'app/shared/services/dialog.service';
import { ProblemCatalogService } from './problem-catalog.service';
import { ProblemCategoryService } from './problem-category.service';
import { Store } from '@ngrx/store';
import { EntityType } from 'app/shared/enums/entity-type.enum';
import { openProblem, openProblemCatalog, openProblemCategory } from './state-management/problems.actions';
import { problemsSelector } from './state-management/problems.selectors';

@Injectable({
    providedIn: 'root'
})
export class ProblemTreeService implements TreeService {
    treeNodes: Observable<TreeNode[]>;

    constructor(
        private readonly _dialogService: DialogService,
        private readonly _problemService: ProblemService,
        private readonly _problemCategoryService: ProblemCategoryService,
        private readonly _problemCatalogService: ProblemCatalogService,
        private readonly _store: Store
    ) {
        this.treeNodes = _store.select(problemsSelector).pipe(
            shareReplay(1),
            map(problems => {
                const treeNodes: Array<TreeNode> = [];
                if (problems?.problemCatalogs?.length)
                    for (const catalog of problems.problemCatalogs) {
                        const catalogCategories = problems?.problemCategories
                            .filter(category => category.problemCatalogId === catalog.id)
                            .map(category => ({
                                id: category.id,
                                name: category.name,
                                description: category.description,
                                parentId: category.problemCatalogId,
                                children: [],
                                nodeLevel: NodeLevel.Category
                            }));
                        const catalogNode: TreeNode = {
                            id: catalog.id,
                            name: catalog.name,
                            description: catalog.description,
                            nodeLevel: NodeLevel.Catalog,
                            children: catalogCategories
                        };
                        treeNodes.push(catalogNode);
                    }
                if (problems?.problemCategories?.length)
                    for (const category of problems.problemCategories.filter(category => !category.problemCatalogId)) {
                        const categoryNode: TreeNode = {
                            id: category.id,
                            name: category.name,
                            description: category.description,
                            parentId: category.problemCatalogId,
                            nodeLevel: NodeLevel.Category,
                            children: []
                        };
                        treeNodes.push(categoryNode);
                    }
                return treeNodes;
            }));
    }

    deleteTreeNode(id: number, nodeLevel: NodeLevel): Observable<void> {
        let deleteObservable: Observable<void>;
        switch (nodeLevel) {
            case NodeLevel.Node:
                deleteObservable = this._problemService.deleteProblem(id);
                break;
            case NodeLevel.Category:
                deleteObservable = this._problemCategoryService.deleteProblemCategory(id);
                break;
            case NodeLevel.Catalog:
                deleteObservable = this._problemCatalogService.deleteProblemCatalog(id);
                break;
        }
        return deleteObservable;
    }

    openNode(nodeLevel: NodeLevel, treeNode?: TreeNode, parentId?: number): Observable<TreeNode> {
        let nodeEntityType: EntityType;
        switch (nodeLevel) {
            case NodeLevel.Node:
                nodeEntityType = EntityType.Problem;
                this._store.dispatch(openProblem({
                    id: treeNode?.id,
                    name: treeNode?.name,
                    description: treeNode?.description,
                    problemCategoryId: treeNode?.parentId ?? parentId
                }));
                break;
            case NodeLevel.Category:
                nodeEntityType = EntityType.ProblemCategory;
                this._store.dispatch(openProblemCategory({
                    id: treeNode?.id,
                    name: treeNode?.name,
                    description: treeNode?.description,
                    problemCatalogId: treeNode?.parentId ?? parentId
                }));
                break;
            case NodeLevel.Catalog:
                nodeEntityType = EntityType.ProblemCatalog;
                this._store.dispatch(openProblemCatalog({
                    id: treeNode?.id,
                    name: treeNode?.name,
                    description: treeNode?.description
                }));
                break;
        }
        return this._dialogService.dialog(nodeEntityType).pipe(
            switchMap(matDialogRef => matDialogRef.afterClosed()),
            filter(nodeEntity => !!nodeEntity?.id));
    }

    getTreeNodes(): Observable<TreeNode[]> {
        return this.treeNodes;
    }
}
