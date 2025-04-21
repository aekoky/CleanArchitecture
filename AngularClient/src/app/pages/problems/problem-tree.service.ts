import { Injectable } from '@angular/core';
import { BehaviorSubject, filter, map, Observable, of, shareReplay, switchMap, take, tap } from 'rxjs';
import { TreeService } from 'app/shared/modules/tree/tree.interface';
import { NodeLevel, TreeNode } from 'app/shared/modules/tree/tree.model';
import { ProblemService } from './problem.service';
import { ViewMode } from 'app/shared/enums/view-mode.enum';
import { ProblemCatalogDto, ProblemCategoriesDto, ProblemCategoryDto } from 'app/web-api-client';
import { DialogService } from 'app/shared/services/dialog.service';
import { ProblemCatalogService } from './problem-catalog.service';
import { ProblemCategoryService } from './problem-category.service';
import { Store } from '@ngrx/store';
import { EntityType } from 'app/shared/enums/entity-type.enum';
import { setProblemCatalogEntityState, setProblemCategoryEntityState, setProblemEntityState } from './state-management/problems.actions';

@Injectable({
    providedIn: 'root'
})
export class ProblemTreeService implements TreeService {
    problemCatalogsCategories = new BehaviorSubject<ProblemCategoriesDto>(undefined);
    problemCatalogs = new BehaviorSubject<ProblemCatalogDto[]>([]);
    problemCategories = new BehaviorSubject<ProblemCategoryDto[]>([]);
    treeNodes: Observable<TreeNode[]>;
    private _refreshProblems$ = new BehaviorSubject<void>(undefined);

    constructor(
        private readonly _dialogService: DialogService,
        private readonly _problemService: ProblemService,
        private readonly _problemCategoryService: ProblemCategoryService,
        private readonly _problemCatalogService: ProblemCatalogService,
        private readonly _store: Store
    ) {
        this.treeNodes = this._refreshProblems$.pipe(
            switchMap(() => this._problemService.getProblemCatalogs()),
            shareReplay(1),
            tap((problemCategories) => {
                this.problemCatalogsCategories.next(problemCategories);
                this.problemCatalogs.next(problemCategories.problemCatalogs);
                this.problemCategories.next(problemCategories.problemCategories);
            }),
            map(problemCatalogs => {
                const treeNodes: Array<TreeNode> = [];
                for (const catalog of problemCatalogs.problemCatalogs) {
                    const catalogCategories = catalog.categories
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
                for (const category of problemCatalogs.problemCategories) {
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
                deleteObservable = this._problemCategoryService.deleteProblemCategory(id).pipe(tap(() => {
                    this.problemCatalogsCategories.pipe(take(1)).subscribe(problemCategories => {
                        const problemCategoryIndex = problemCategories.problemCategories.findIndex(problemCategory => problemCategory.id === id);
                        if (problemCategoryIndex !== -1)
                            problemCategories.problemCategories.splice(problemCategoryIndex, 1);
                        else
                            for (var problemCatalog of problemCategories.problemCatalogs) {
                                const problemCategoryIndex = problemCatalog.categories.findIndex(problemCategory => problemCategory.id === id);
                                if (problemCategoryIndex !== -1)
                                    problemCatalog.categories.splice(problemCategoryIndex, 1);

                            }
                        this.problemCatalogsCategories.next(problemCategories);
                    });
                }));
                break;
            case NodeLevel.Catalog:
                deleteObservable = this._problemCatalogService.deleteProblemCatalog(id)
                break;
        }
        return deleteObservable.pipe(tap(() => this._refreshProblems$.next()));
    }

    openNode(nodeLevel: NodeLevel, treeNode?: TreeNode, parentId?: number): Observable<TreeNode> {
        let nodeEntityType: EntityType;
        switch (nodeLevel) {
            case NodeLevel.Node:
                nodeEntityType = EntityType.Problem;
                this._store.dispatch(setProblemEntityState({
                    viewMode: ViewMode.Dialog, entity: {
                        id: treeNode?.id,
                        name: treeNode?.name,
                        description: treeNode?.description,
                        problemCategoryId: treeNode?.parentId ?? parentId,
                    }
                }));
                break;
            case NodeLevel.Category:
                nodeEntityType = EntityType.ProblemCategory;
                this._store.dispatch(setProblemCategoryEntityState({
                    viewMode: ViewMode.Dialog, entity: {
                        id: treeNode?.id,
                        name: treeNode?.name,
                        description: treeNode?.description,
                        problemCatalogId: treeNode?.parentId ?? parentId,
                    }
                }));
                break;
            case NodeLevel.Catalog:
                nodeEntityType = EntityType.ProblemCatalog;
                this._store.dispatch(setProblemCatalogEntityState({
                    viewMode: ViewMode.Dialog, entity: {
                        id: treeNode?.id,
                        name: treeNode?.name,
                        description: treeNode?.description,
                    }
                }));
                break;
        }
        return this._dialogService.dialog(nodeEntityType).pipe(
            switchMap(matDialogRef => matDialogRef.afterClosed()),
            filter(nodeEntity => !!nodeEntity?.id),
            tap(() => this._refreshProblems$.next()));
    }

    getTreeNodes(): Observable<TreeNode[]> {
        return this.treeNodes;
    }
}
