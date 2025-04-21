import { createSelector } from '@ngrx/store';
import { EntityType } from 'app/shared/enums/entity-type.enum';

export const selectState = (state) => state.problemPageState;

//Problem Entity State Selector
export const selectProblemEntityState = createSelector(
    selectState,
    (state) => {
        return state.get(EntityType.Problem);
    }
);

//Problem List Entity State Selector
export const selectProblemListEntityState = createSelector(
    selectState,
    (state) => state.get(EntityType.ProblemList)
);

//Problem Catalog Entity State Selector
export const selectProblemCatalogEntityState = createSelector(
    selectState,
    (state) => state.get(EntityType.ProblemCatalog)
);

//Problem Category Entity State Selector
export const selectProblemCategoryEntityState = createSelector(
    selectState,
    (state) => state.get(EntityType.ProblemCategory)
);