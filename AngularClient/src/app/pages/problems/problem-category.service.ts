import { Injectable } from '@angular/core';
import { map, Observable, tap } from 'rxjs';
import { CreateProblemCategoryCommand, DeleteProblemCategoriesCommand, ProblemCategoryDto, ProblemCategoriesClient, UpdateProblemCategoryCommand } from 'app/web-api-client';
import { ToastType } from 'app/shared/enums/taost-type.enum';
import { ToastService } from 'app/shared/services/toast.service';
import { CacheService } from 'app/shared/services/cache.service';
import { Store } from '@ngrx/store';
import { createProblemCategory, deleteProblemCategory, updateProblemCategory } from './state-management/problems.actions';

@Injectable({
    providedIn: 'root'
})
export class ProblemCategoryService extends CacheService<ProblemCategoryDto> {

    constructor(
        private readonly _problemCategoriesClient: ProblemCategoriesClient,
        private readonly _toastService: ToastService,
        private readonly _store: Store) {
        super();
    }

    saveProblemCategory(problemCategoryId: number, problemCategory: ProblemCategoryDto): Observable<ProblemCategoryDto> {
        if (problemCategoryId > 0)
            return this._problemCategoriesClient.update(problemCategoryId, UpdateProblemCategoryCommand.fromJS(problemCategory)).pipe(
                tap({
                    next: () => {
                        this.removeCache(problemCategoryId);
                        this._toastService.openToast("Le problème sous catégorie a été modifiée", ToastType.Success, 3000);
                        this._store.dispatch(updateProblemCategory(problemCategory));
                    },
                    error: error => this._toastService.openToast(error, ToastType.Error),
                }),
                map(() => problemCategory));
        else
            return this._problemCategoriesClient.create(CreateProblemCategoryCommand.fromJS(problemCategory)).pipe(tap({
                next: (id) => {
                    this._toastService.openToast("Le problème sous catégorie a été créée", ToastType.Success, 3000);
                    problemCategory.id = id;
                    this._store.dispatch(createProblemCategory(problemCategory));
                },
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
                    this._store.dispatch(deleteProblemCategory({ id }));
                },
                error: error => this._toastService.openToast(error, ToastType.Error),
            })
        );

    }
}
