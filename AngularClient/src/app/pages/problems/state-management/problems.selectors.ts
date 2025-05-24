import { createSelector } from '@ngrx/store';
import { IProblemCatalogDto, IProblemCategoryDto, IProblemDto, IProblemsDto } from 'app/web-api-client';

export interface IProblemPageState {
    problems: IProblemsDto;
    problem: IProblemDto;
    problemCatalog: IProblemCatalogDto;
    problemCategory: IProblemCategoryDto;
}

export const selectState = (state: IProblemPageState) => state;

export const problemSelector = createSelector(
    selectState,
    (state) => {
        return state.problem;
    }
);
export const problemsSelector = createSelector(
    selectState,
    (state) => {
        return state.problems;
    }
);

export const problemCatalogSelector = createSelector(
    selectState,
    (state) => {
        return state.problemCatalog;
    }
);

export const problemsCategorySelector = createSelector(
    selectState,
    (state) => {
        return state.problemCategory;
    }
);