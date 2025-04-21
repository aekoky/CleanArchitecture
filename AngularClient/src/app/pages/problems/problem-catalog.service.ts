import { Injectable } from '@angular/core';
import { map, Observable, tap } from 'rxjs';
import { CreateProblemCatalogCommand, DeleteProblemCatalogsCommand, ProblemCatalogDto, ProblemCatalogsClient, UpdateProblemCatalogCommand } from 'app/web-api-client';
import { ToastType } from 'app/shared/enums/taost-type.enum';
import { ToastService } from 'app/shared/services/toast.service';
import { CacheService } from 'app/shared/services/cache.service';


@Injectable({
    providedIn: 'root'
})
export class ProblemCatalogService extends CacheService<ProblemCatalogDto> {

    constructor(
        private readonly _problemCatalogsClient: ProblemCatalogsClient,
        private readonly _toastService: ToastService) {
        super();
    }

    saveProblemCatalog(problemCatalogId: number, problemCatalog: ProblemCatalogDto): Observable<ProblemCatalogDto> {
        if (problemCatalogId > 0)
            return this._problemCatalogsClient.update(problemCatalogId, UpdateProblemCatalogCommand.fromJS(problemCatalog)).pipe(
                tap({
                    next: () => {
                        this.removeCache(problemCatalogId);
                        this._toastService.openToast("Le problème catégorie a été modifiée", ToastType.Success, 3000)
                    },
                    error: error => this._toastService.openToast(error, ToastType.Error),
                }),
                map(() => problemCatalog));
        else
            return this._problemCatalogsClient.create(CreateProblemCatalogCommand.fromJS(problemCatalog)).pipe(
                tap({
                    next: (id) => this._toastService.openToast("Le problème catégorie a été créée", ToastType.Success, 3000)
                    ,
                    error: error => this._toastService.openToast(error, ToastType.Error),
                }),
                map((id) => {
                    problemCatalog.id = id;
                    return problemCatalog;
                }));
    }

    deleteProblemCatalog(id: number): Observable<void> {
        return this._problemCatalogsClient.delete(id).pipe(
            tap({
                next: () => {
                    this.removeCache(id);
                    this._toastService.openToast("Le problème catégorie est supprimée avec succès", ToastType.Success, 3000)
                },
                error: error => this._toastService.openToast(error, ToastType.Error),
            })
        );

    }

    deleteProblemCatalogs(ids: number[]): Observable<void> {
        return this._problemCatalogsClient.deleteProblemCatalogs(DeleteProblemCatalogsCommand.fromJS({ ids })).pipe(tap({
            next: () => {
                for (const id of ids)
                    this.removeCache(id);
                this._toastService.openToast('Les problèmes catégories sont supprimées avec succès', ToastType.Success, 3000)
            },
            error: error => this._toastService.openToast(error, ToastType.Error),
        }));
    }
}
