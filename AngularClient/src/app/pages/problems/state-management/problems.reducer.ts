import { createReducer, on } from '@ngrx/store';
import * as ProblemPageActions from './problems.actions';
import { EntityType } from 'app/shared/enums/entity-type.enum';
import { EntityState } from 'app/shared/models/entity-state';

//Problem Actions
export const problemPageStateReducer = createReducer(
    new Map<EntityType, EntityState>,
    on(ProblemPageActions.setProblemEntityState, (state, entityState) => {
        state.set(EntityType.Problem, entityState);
        return new Map(state);
    }),
    on(ProblemPageActions.resetProblemEntityState, state => {
        state.delete(EntityType.Problem);
        return new Map(state);
    }),
    on(ProblemPageActions.setProblemListEntityState, (state, entityState) => {
        state.set(EntityType.ProblemList, entityState);
        return new Map(state);
    }),
    on(ProblemPageActions.resetProblemListEntityState, state => {
        state.delete(EntityType.ProblemList);
        return new Map(state);
    }),
    on(ProblemPageActions.setProblemCatalogEntityState, (state, entityState) => {
        state.set(EntityType.ProblemCatalog, entityState);
        return new Map(state);
    }),
    on(ProblemPageActions.resetProblemCatalogEntityState, state => {
        state.delete(EntityType.ProblemCatalog);
        return new Map(state);
    }),

    on(ProblemPageActions.setProblemCategoryEntityState, (state, entityState) => {
        state.set(EntityType.ProblemCategory, entityState);
        return new Map(state);
    }),
    on(ProblemPageActions.resetProblemCategoryEntityState, state => {
        state.delete(EntityType.ProblemCategory);
        return new Map(state);
    }),
);
