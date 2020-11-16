import {
  ActionReducer,
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
  MetaReducer
} from '@ngrx/store';
import { environment } from '../../../environments/environment';
import * as fromFilterPayload from './filter-payload.reducer';


export interface State {
  [fromFilterPayload.filterPayloadFeatureKey]: fromFilterPayload.State;
}

export const reducers: ActionReducerMap<State> = {
  [fromFilterPayload.filterPayloadFeatureKey]: fromFilterPayload.reducer,
};

export const selectFilterState = createFeatureSelector<fromFilterPayload.State>('filterPayload');
export const getFilterQuery = createSelector(selectFilterState, fromFilterPayload.getFilterQuery);
export const getIngredientFilterQuery = createSelector(selectFilterState, fromFilterPayload.getIngredientFilterQuery);
// export const setFilterQuery = createSelector(selectFilterState, fromFilterPayload.setFilterQuery);

// export const metaReducers: MetaReducer<State>[] = !environment.production ? [] : [];
