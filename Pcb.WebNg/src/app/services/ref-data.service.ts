import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { MeasurementModel } from '@models/ingredient-model';
import { ReferenceAll, ReferenceDetail, ReferenceItem, ReferenceItemFull, ReferenceType } from '@models/reference.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
	providedIn: 'root'
})
export class RefDataService {
	private defaultHeader = new HttpHeaders()
		.set('Content-Type', 'application/json;odata=verbose')
		.set('Accept', 'application/json;odata=verbose');
	private apiUrl = environment.apiUrl + environment.apiVersion;

	constructor(
		private router: Router,
		private httpClient: HttpClient
	) { }

	public getReference(type: ReferenceType, detail = ReferenceDetail.Basic): Observable<ReferenceItem | ReferenceItemFull> {
		return this.httpClient.get<ReferenceItem | ReferenceItemFull>
			(`${this.apiUrl}reference?type=${type}&detail=${detail}`, {headers: this.defaultHeader});
	}

	public getAllReferences(): Observable<ReferenceAll> {
		return this.httpClient.get<ReferenceAll>(`${this.apiUrl}reference/all`, {headers: this.defaultHeader});
	}

	public getMeasurements(): Observable<Array<MeasurementModel>> {
		return this.httpClient.get<Array<MeasurementModel>>(`${this.apiUrl}reference/measurements`, {headers: this.defaultHeader});
	}

}
