import { Injectable } from '@angular/core';
import { map, Observable, tap } from 'rxjs';
import { CreateProblemCategoryCommand, DeleteProblemCategoriesCommand, ProblemCategoryDto, ProblemCategoriesClient, UpdateProblemCategoryCommand } from 'app/web-api-client';
import { ToastType } from 'app/shared/enums/taost-type.enum';
import { ToastService } from 'app/shared/services/toast.service';
import { CacheService } from 'app/shared/services/cache.service';

@Injectable({
    providedIn: 'root'
})
export class ProblemCategoryService extends CacheService<ProblemCategoryDto> {

    constructor(
        private readonly _problemCategoriesClient: ProblemCategoriesClient,
        private readonly _toastService: ToastService) {
        super();
    }

    saveProblemCategory(problemCategoryId: number, problemCategory: ProblemCategoryDto): Observable<ProblemCategoryDto> {
        if (problemCategoryId > 0)
            return this._problemCategoriesClient.update(problemCategoryId, UpdateProblemCategoryCommand.fromJS(problemCategory)).pipe(
                tap({
                    next: () => {
                        this.removeCache(problemCategoryId);
                        this._toastService.openToast("Le problème sous catégorie a été modifiée", ToastType.Success, 3000)
                    },
                    error: error => this._toastService.openToast(error, ToastType.Error),
                }),
                map(() => problemCategory));
        else
            return this._problemCategoriesClient.create(CreateProblemCategoryCommand.fromJS(problemCategory)).pipe(tap({
                next: (id) => this._toastService.openToast("Le problème sous catégorie a été créée", ToastType.Success, 3000),
                error: error => this._toastService.openToast(error, ToastType.Error),
            }),
                map((id) => {
                    problemCategory.id = id;
                    return problemCategory;
                }));
    }

    deleteProblemCategory(id: number): Observable<void> {
        return this._problemCategoriesClient.delete(id).pipe(
            tap({
                next: () => {
                    this.removeCache(id);
                    this._toastService.openToast("Le problème sous catégorie est supprimée avec succès", ToastType.Success, 3000)
                },
                error: error => this._toastService.openToast(error, ToastType.Error),
            })
        );

    }

    deleteProblemCategories(ids: number[]): Observable<void> {
        return this._problemCategoriesClient.deleteProblemCategories(DeleteProblemCategoriesCommand.fromJS({ ids })).pipe(tap({
            next: () => {
                for (const id of ids)
                    this.removeCache(id);
                this._toastService.openToast('Les problèmes sous catégories sont supprimées avec succès', ToastType.Success, 3000)
            },
            error: error => this._toastService.openToast(error, ToastType.Error),
        }));
    }
}
