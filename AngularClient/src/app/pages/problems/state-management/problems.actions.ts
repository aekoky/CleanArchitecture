import { createAction, props } from '@ngrx/store';
import { EntityState } from 'app/shared/models/entity-state';
import { ProblemCatalogDto, ProblemCategoryDto, ProblemDto } from 'app/web-api-client';
import * as ProblemPageActions from './problems.actions';

//Problem Actions

export const setProblemEntityState = createAction(
    '[Problem Page] Set Problem Entity State',
    props<EntityState>()
);

export const resetProblemEntityState = createAction(
    '[Problem Page] Reset Problem Entity State'
);

export const openProblemDialog = createAction(
    '[Problem Page] Open Problem Dialog',
);

export const problemDialogClosed = createAction(
    '[Problem Page] Problem Dialog Closed',
    props<ProblemDto>()
);

export const problemDialogOpened = createAction(
    '[Problem Page] Problem Dialog Opened',
);
//Problem List Actions

export const setProblemListEntityState = createAction(
    '[Problem Page] Set Problem List Entity State',
    props<EntityState>()
);

export const resetProblemListEntityState = createAction(
    '[Problem Page] Reset Problem List Entity State'
);

//Problem Catalog Actions

export const setProblemCatalogEntityState = createAction(
    '[Problem Page] Set Problem Catalog Entity State',
    props<EntityState>()
);

export const resetProblemCatalogEntityState = createAction(
    '[Problem Page] Reset Problem Catalog Entity State'
);

export const openProblemCatalogDialog = createAction(
    '[Problem Page] Open Problem Catalog Dialog',
);

export const problemCatalogDialogClosed = createAction(
    '[Problem Page] Problem Catalog Dialog Closed',
    props<ProblemCatalogDto>()
);

export const problemCatalogDialogOpened = createAction(
    '[Problem Page] Problem Catalog Dialog Opened',
);

//Problem Category Actions

export const setProblemCategoryEntityState = createAction(
    '[Problem Page] Set Problem Category Entity State',
    props<EntityState>()
);

export const resetProblemCategoryEntityState = createAction(
    '[Problem Page] Reset Problem Category Entity State'
);

export const openProblemCategoryDialog = createAction(
    '[Problem Page] Open Problem Dialog Category',
);

export const problemCategoryDialogClosed = createAction(
    '[Problem Page] Problem Category Dialog Closed',
    props<ProblemCategoryDto>()
);

export const problemCategoryDialogOpened = createAction(
    '[Problem Page] Problem Category Dialog Opened',
);