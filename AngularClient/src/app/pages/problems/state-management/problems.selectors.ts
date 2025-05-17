import { createSelector } from '@ngrx/store';
import { IProblemCatalogDto, IProblemCategoryDto, IProblemDto, IProblemsDto } from 'app/web-api-client';

export interface IProblemsFilter {
    keyword: string;
    selectedCatalogs?: number[];
    selectedCategories?: number[];
}

export interface IProblemPageState {
    problems: IProblemsDto;
    problemsFilter: IProblemsFilter;
    problem: IProblemDto;
    problemCatalog: IProblemCatalogDto;
    problemCategory: IProblemCategoryDto;
}

export const selectState = (state: IProblemPageState) => state;

//Problem Entity State Selector
export const problemSelector = createSelector(
    selectState,
    (state) => {
        return state.problem;
    }
);
//Problems List State Selector
export const problemsSelector = createSelector(
    selectState,
    (state) => {
        return state.problems;
    }
);

//Problems List Filter State Selector
export const problemsFilterSelector = createSelector(
    selectState,
    (state) => {
        return state.problemsFilter;
    }
);

//Problem Catalog Entity State Selector
export const problemCatalogSelector = createSelector(
    selectState,
    (state) => {
        return state.problemCatalog;
    }
);

//Problem Category Entity State Selector
export const problemsCategorySelector = createSelector(
    selectState,
    (state) => {
        return state.problemCategory;
    }
);