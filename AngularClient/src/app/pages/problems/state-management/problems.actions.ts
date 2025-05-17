import { createAction, props } from '@ngrx/store';
import { IProblemDto, IProblemCatalogDto, IProblemCategoryDto, IProblemsDto, ProblemDto } from 'app/web-api-client';
import { IProblemsFilter } from './problems.selectors';

//Problem Actions

export const openProblem = createAction(
    '[Problems Page] Open Problem',
    props<IProblemDto>()
);

export const deleteProblem = createAction(
    '[Problems Page] Delete Problem',
    props<IProblemDto>()
);

export const deleteProblems = createAction(
    '[Problems Page] Delete Problem',
    props<{ ids: number[] }>()
);

export const createProblem = createAction(
    '[Problems Page] Create Problem',
    props<IProblemDto>()
);

export const updateProblem = createAction(
    '[Problems Page] Update Problem',
    props<IProblemDto>()
);

//Problems Actions

export const loadProblems = createAction(
    '[Problems Page] Load Problems',
    props<IProblemsDto>()
);

export const filterProblems = createAction(
    '[Problems Page] Filter Problems',
    props<IProblemsFilter>()
);

//Problem Catalog Actions

export const openProblemCatalog = createAction(
    '[Problems Page] Open Problem Catalog',
    props<IProblemCatalogDto>()
);

export const deleteProblemCatalog = createAction(
    '[Problems Page] Delete Problem Catalog',
    props<IProblemCatalogDto>()
);

export const createProblemCatalog = createAction(
    '[Problems Page] Create Problem Catalog',
    props<IProblemCatalogDto>()
);

export const updateProblemCatalog = createAction(
    '[Problems Page] Update Problem Catalog',
    props<IProblemCatalogDto>()
);

//Problem Category Actions

export const openProblemCategory = createAction(
    '[Problems Page] Open Problem Category',
    props<IProblemCategoryDto>()
);

export const deleteProblemCategory = createAction(
    '[Problems Page] Delete Problem Category',
    props<IProblemCategoryDto>()
);

export const createProblemCategory = createAction(
    '[Problems Page] Create Problem Category',
    props<IProblemCategoryDto>()
);

export const updateProblemCategory = createAction(
    '[Problems Page] Update Problem Category',
    props<IProblemCategoryDto>()
);