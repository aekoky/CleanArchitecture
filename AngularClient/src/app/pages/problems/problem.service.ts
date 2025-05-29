import { Injectable } from '@angular/core';
import { map, Observable, tap } from 'rxjs';
import { CreateProblemCommand, DeleteProblemsCommand, ProblemDto, ProblemsClient, ProblemsDto, UpdateProblemCommand } from 'app/web-api-client';
import { ToastType } from 'app/shared/enums/taost-type.enum';
import { ToastService } from 'app/shared/services/toast.service';
import { CacheService } from 'app/shared/services/cache.service';
import { Store } from '@ngrx/store';
import { createProblem, deleteProblem, deleteProblems, updateProblem } from './state-management/problems.actions';

@Injectable({
    providedIn: 'root'
})
export class ProblemService extends CacheService<ProblemDto> {

    constructor(
        private readonly _problemsClient: ProblemsClient,
        private readonly _toastService: ToastService,
        private readonly _store: Store) {
        super();
    }

    saveProblem(problemId: number, problem: ProblemDto): Observable<ProblemDto> {
        if (problemId > 0)
            return this._problemsClient.update(problemId, UpdateProblemCommand.fromJS(problem)).pipe(
                tap(
                    {
                        next: () => {
                            this.removeCache(problemId);
                            this._toastService.openToast($localize`The issue has been changed`, ToastType.Success, 3000);
                            this._store.dispatch(updateProblem(problem));

                        },
                        error: error => this._toastService.openToast(error, ToastType.Error)
                    }
                ),
                map(() => problem));
        else
            return this._problemsClient.create(CreateProblemCommand.fromJS(problem)).pipe(tap(
                {
                    next: (id) => {
                        this._toastService.openToast($localize`The issue has been created`, ToastType.Success, 3000);
                        problem.id = id;
                        this._store.dispatch(createProblem(problem));
                    },
                    error: error => this._toastService.openToast(error, ToastType.Error),
                }),
                map((id) => {
                    problem.id = id;
                    return problem;
                }));
    }

    getProblems(): Observable<ProblemsDto> {
        return this._problemsClient.getProblems();
    }

    deleteProblem(id: number): Observable<void> {
        return this._problemsClient.delete(id).pipe(
            tap({
                next: () => {
                    this.removeCache(id);
                    this._toastService.openToast($localize`The issue has been removed successfully`, ToastType.Success, 3000);
                    this._store.dispatch(deleteProblem({ id }));
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
                        this._toastService.openToast($localize`The issues are successfully removed`, ToastType.Success, 3000)
                        this._store.dispatch(deleteProblems({ ids }));
                    },
                    error: error => this._toastService.openToast(error, ToastType.Error),
                }
            ));
    }
}