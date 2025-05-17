import { createReducer, on } from '@ngrx/store';
import * as ProblemPageActions from './problems.actions';
import { IProblemCatalogDto, IProblemCategoryDto, IProblemDto, IProblemsDto, Problem, ProblemCatalogDto, ProblemCategoryDto, ProblemDto } from 'app/web-api-client';
import { IProblemsFilter } from './problems.selectors';

export const problemsReducer = createReducer(
    <IProblemsDto>{ problems: [], problemCatalogs: [], problemCategories: [] },
    on(ProblemPageActions.loadProblems, (state, entityState) => {
        return entityState;
    }),
    on(ProblemPageActions.createProblem, (state, entityState) => {
        const problems = { ...state };
        problems.problems = [...problems.problems, ProblemDto.fromJS(entityState)];
        return problems;
    }),
    on(ProblemPageActions.updateProblem, (state, entityState) => {
        const problems = { ...state };
        const index = problems.problems.findIndex(problem => problem.id == entityState.id);
        if (index !== -1) {
            problems.problems = [...problems.problems];
            problems.problems[index] = ProblemDto.fromJS(entityState)
        }
        return problems;
    }),
    on(ProblemPageActions.deleteProblem, (state, entityState) => {
        const problems = { ...state };
        const index = problems.problems.findIndex(problem => problem.id == entityState.id);
        if (index !== -1) {
            problems.problems = [...problems.problems];
            problems.problems.splice(index, 1);
        }
        return problems;
    }),
    on(ProblemPageActions.deleteProblems, (state, entityState) => {
        if (!entityState?.ids?.length)
            return state;
        const problems = { ...state };
        problems.problems = problems.problems.filter(problem => !entityState.ids.includes(problem.id))
        return problems;
    }),
    on(ProblemPageActions.createProblemCatalog, (state, entityState) => {
        const problems = { ...state };
        problems.problemCatalogs = [...state.problemCatalogs, ProblemCatalogDto.fromJS(entityState)];
        return problems;
    }),
    on(ProblemPageActions.updateProblemCatalog, (state, entityState) => {
        const problems = { ...state };
        const index = problems.problemCatalogs.findIndex(problemCatalog => problemCatalog.id == entityState.id);
        if (index !== -1) {
            problems.problemCatalogs = [...problems.problemCatalogs];
            problems.problemCatalogs[index] = ProblemCatalogDto.fromJS(entityState)
        }
        return problems;
    }),
    on(ProblemPageActions.deleteProblemCatalog, (state, entityState) => {
        const problems = { ...state };
        const index = problems.problemCatalogs.findIndex(problem => problem.id == entityState.id);
        if (index !== -1) {
            problems.problemCatalogs = [...problems.problemCatalogs];
            problems.problemCatalogs.splice(index, 1);
        }
        return problems;
    }),
    on(ProblemPageActions.createProblemCategory, (state, entityState) => {
        const problems = { ...state };
        problems.problemCategories = [...problems.problemCategories, ProblemCategoryDto.fromJS(entityState)];
        return problems;
    }),
    on(ProblemPageActions.updateProblemCategory, (state, entityState) => {
        const problems = { ...state };
        const index = problems.problemCategories.findIndex(problemCategory => problemCategory.id == entityState.id);
        if (index !== -1) {
            problems.problemCategories = [...problems.problemCategories];
            problems.problemCategories[index] = ProblemCategoryDto.fromJS(entityState)
        }
        return problems;
    }),
    on(ProblemPageActions.deleteProblemCategory, (state, entityState) => {
        const problems = { ...state };
        const index = problems.problemCategories.findIndex(problem => problem.id == entityState.id);
        if (index !== -1) {
            problems.problemCategories = [...problems.problemCategories];
            problems.problemCategories.splice(index, 1);
        }
        return problems;
    })
);

export const problemsFilterReducer = createReducer(
    <IProblemsFilter>{},
    on(ProblemPageActions.filterProblems, (state, entityState) => {
        return entityState;
    }),
);

export const problemReducer = createReducer(
    <IProblemDto>undefined,
    on(ProblemPageActions.openProblem, (state, entityState) => {
        return entityState;
    }),
    on(ProblemPageActions.createProblem, (state, entityState) => {
        return undefined;
    }),
    on(ProblemPageActions.updateProblem, (state, entityState) => {
        return undefined;
    }),
    on(ProblemPageActions.deleteProblem, (state, entityState) => {
        return undefined;
    })
);

export const problemCatalogReducer = createReducer(
    <IProblemCatalogDto>undefined,
    on(ProblemPageActions.openProblemCatalog, (state, entityState) => {
        return entityState;
    }),
    on(ProblemPageActions.createProblemCatalog, (state, entityState) => {
        return undefined;
    }),
    on(ProblemPageActions.updateProblemCatalog, (state, entityState) => {
        return undefined;
    }),
    on(ProblemPageActions.deleteProblemCatalog, (state, entityState) => {
        return undefined;
    })
);

export const problemCategoryReducer = createReducer(
    <IProblemCategoryDto>undefined,
    on(ProblemPageActions.openProblemCategory, (state, entityState) => {
        return entityState;
    }),
    on(ProblemPageActions.createProblemCategory, (state, entityState) => {
        return undefined;
    }),
    on(ProblemPageActions.updateProblemCategory, (state, entityState) => {
        return undefined;
    }),
    on(ProblemPageActions.deleteProblemCategory, (state, entityState) => {
        return undefined;
    })
);
