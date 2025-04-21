import { Injectable } from '@angular/core';
import { filter, map, Observable, of, switchMap, tap } from 'rxjs';
import { CreateProblemCommand, DeleteProblemsCommand, ProblemCategoriesDto, ProblemDto, ProblemsClient, UpdateProblemCommand } from 'app/web-api-client';
import { ToastType } from 'app/shared/enums/taost-type.enum';
import { ToastService } from 'app/shared/services/toast.service';
import { CacheService } from 'app/shared/services/cache.service';

@Injectable({
    providedIn: 'root'
})
export class ProblemService extends CacheService<ProblemDto> {

    constructor(
        private readonly _problemsClient: ProblemsClient,
        private readonly _toastService: ToastService) {
        super();
    }

    saveProblem(problemId: number, problem: ProblemDto): Observable<ProblemDto> {
        if (problemId > 0)
            return this._problemsClient.update(problemId, UpdateProblemCommand.fromJS(problem)).pipe(
                tap(
                    {
                        next: () => {
                            this.removeCache(problemId);
                            this._toastService.openToast('Le problème a été modifié', ToastType.Success, 3000)
                        },
                        error: error => this._toastService.openToast(error, ToastType.Error)
                    }
                ),
                map(() => problem));
        else
            return this._problemsClient.create(CreateProblemCommand.fromJS(problem)).pipe(tap(
                {
                    next: (id) => this._toastService.openToast('Le problème a été créé', ToastType.Success, 3000),
                    error: error => this._toastService.openToast(error, ToastType.Error),
                }),
                map((id) => {
                    problem.id = id;
                    return problem;
                }));
    }

    getProblems(): Observable<ProblemDto[]> {
        return this._problemsClient.getProblems();
    }

    getProblemCatalogs(): Observable<ProblemCategoriesDto> {
        return this._problemsClient.getProblemCatalogs();
    }
    getProblemsByCategory(problemCategoryIds?: number[], problemCatalogIds?: number[]): Observable<ProblemDto[]> {
        return this._problemsClient.getProblemsByCategory(problemCategoryIds, problemCatalogIds);
    }

    deleteProblem(id: number): Observable<void> {
        return this._problemsClient.delete(id).pipe(
            tap({
                next: () => {
                    this.removeCache(id);
                    this._toastService.openToast('Le problème est supprimé avec succès', ToastType.Success, 3000)
                },
                error: error => this._toastService.openToast(error, ToastType.Error),
            })
        );
    }

    deleteProblems(ids: number[]): Observable<void> {
        return this._problemsClient.deleteProblems(DeleteProblemsCommand.fromJS({ ids }))
            .pipe(tap(
                {
                    next: () => {
                        for (const id of ids)
                            this.removeCache(id);
                        this._toastService.openToast('Les problèmes sont supprimés avec succès', ToastType.Success, 3000)
                    },
                    error: error => this._toastService.openToast(error, ToastType.Error),
                }
            ));
    }
}
function tao(): import("rxjs").OperatorFunction<void, ProblemDto> {
    throw new Error('Function not implemented.');
}

