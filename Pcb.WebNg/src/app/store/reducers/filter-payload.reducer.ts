import { Action } from '@ngrx/store';
import { FilterQuery } from '@models/filterQuery';
import * as filterPayloadActions from '../action/filter-payload.actions';
import { IngredientFilterObject } from '@models/common.model';


export const filterPayloadFeatureKey = 'filterPayload';

export interface State {
	filterQuery?: FilterQuery;
	ingredientFilterQuery?: IngredientFilterObject;
}

export const initialState: State = {
	filterQuery: {
		orderby: 'name',
		perPage: 10,
		page: 0
	},
	ingredientFilterQuery: {
		name: '',
		type: [],
		parent: '',
		allergies: [],
		purchasedBy: ''
	}
};

export function reducer(state = initialState, action: filterPayloadActions.FilterPayloadActions): State {
	switch (action.type) {
		case filterPayloadActions.FilterPayloadActionTypes.SetFilterPayLoad:
			return handleSetFilter(state, action);
		case filterPayloadActions.FilterPayloadActionTypes.LoadFilterPayloads:
			console.log('load filter state from the reducer', state);
			return state;
		default:
			return state;
	}
}

function handleSetFilter(state: State, action: filterPayloadActions.SetFilterPayLoad): State {
	return {
		...state,
		filterQuery: action.payload
	};
}

export const getFilterQuery = (state: State) => {
	console.log('getFilterQuery', state);
	// return reducer(state, filterPayloadActions.LoadFilterPayloads());
	return (state) ? state.filterQuery : undefined;
};

export const getIngredientFilterQuery = (state: State) => {
	console.log('getIngredientFilterQuery', state);
	// return reducer(state, filterPayloadActions.LoadFilterPayloads());
	return (state) ? state.ingredientFilterQuery : undefined;
};

// export const setFilterQuery = (query: any) => {
//   console.log('set FilterQuery in reducer ran', query);
//   return new filterPayloadActions.SetFilterPayLoad(query);
// }
