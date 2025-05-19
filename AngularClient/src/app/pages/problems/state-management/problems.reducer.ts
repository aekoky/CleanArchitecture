import { createReducer, on } from '@ngrx/store';
import * as ProblemPageActions from './problems.actions';
import { IProblemCatalogDto, IProblemCategoryDto, IProblemDto, IProblemsDto, ProblemCatalogDto, ProblemCategoryDto, ProblemDto } from 'app/web-api-client';

export const problemsReducer = createReducer(
    <IProblemsDto>{ problems: [], problemCatalogs: [], problemCategories: [] },
    on(ProblemPageActions.loadProblems, (state, entityState) => {
        return entityState;
    }),
    on(ProblemPageActions.createProblem, (state, entityState) => {
        const problems = { ...state };
        problems.problems = [...problems.problems, ProblemDto.fromJS(entityState)];
        if (entityState.problemCategoryId)
            problems.problemCategories = problems.problemCategories.map(problemCategory => problemCategory.id === entityState.problemCategoryId ? ProblemCategoryDto.fromJS({ ...problemCategory, problemsCount: problemCategory.problemsCount + 1 }) : problemCategory)
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
            const problem = problems.problems[index];
            if (problem.problemCategoryId)
                problems.problemCategories = problems.problemCategories.map(problemCategory => problemCategory.id === problem.problemCategoryId ? ProblemCategoryDto.fromJS({ ...problemCategory, problemsCount: problemCategory.problemsCount - 1 }) : problemCategory)
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
        if (entityState.problemCatalogId)
            problems.problemCatalogs = problems.problemCatalogs.map(problemCatalog => problemCatalog.id === entityState.problemCatalogId ? ProblemCatalogDto.fromJS({ ...problemCatalog, categoriesCount: problemCatalog.categoriesCount + 1 }) : problemCatalog);
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
            const problemCategory = problems.problemCategories[index];
            if (problemCategory.problemCatalogId)
                problems.problemCatalogs = problems.problemCatalogs.map(problemCatalog => problemCatalog.id === problemCategory.problemCatalogId ? ProblemCatalogDto.fromJS({ ...problemCatalog, categoriesCount: problemCatalog.categoriesCount - 1 }) : problemCatalog);
            problems.problemCategories.splice(index, 1);
        }

        return problems;
    })
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
