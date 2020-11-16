import { Action } from '@ngrx/store';
import { FilterQuery } from '../../models/filterQuery';

export enum FilterPayloadActionTypes {
  LoadFilterPayloads = '[FilterPayload] Load FilterPayloads',
  SetFilterPayLoad = '[FilterPayload] Set FilterPayloads',
  LoadFilterPayloadsSuccess = '[FilterPayload] Load FilterPayloads Success',
  LoadFilterPayloadsFailure = '[FilterPayload] Load FilterPayloads Failure',
}

export class LoadFilterPayloads implements Action {
  readonly type = FilterPayloadActionTypes.LoadFilterPayloads;
}

export class SetFilterPayLoad implements Action {
  readonly type = FilterPayloadActionTypes.SetFilterPayLoad;
  constructor(public payload: FilterQuery) {}
}

export class LoadFilterPayloadsSuccess implements Action {
  readonly type = FilterPayloadActionTypes.LoadFilterPayloadsSuccess;
  constructor(public payload: any) { }
}

export class LoadFilterPayloadsFailure implements Action {
  readonly type = FilterPayloadActionTypes.LoadFilterPayloadsFailure;
  constructor(public payload: { error: any }) { }
}

export type FilterPayloadActions = LoadFilterPayloads | SetFilterPayLoad | LoadFilterPayloadsSuccess | LoadFilterPayloadsFailure;

