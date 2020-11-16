import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { of, Observable } from 'rxjs';

// import * as StackTrace from 'stacktrace-js';
import { ISortPageObj, PagedResult } from '@models/common.model';
import { environment } from 'src/environments/environment';
import { IEventLogDetail, ILogSearchCriteria } from '@models/log.models';


@Injectable()
export class LogService {
	constructor (
		private http: HttpClient
	) {}

	/**
	 * Gets today's results.
	 */
	getTodaysLogs( logSearchCriteria: ILogSearchCriteria, sortingCriteria: ISortPageObj): Observable<PagedResult<IEventLogDetail>> {
		const url = `${environment.apiUrl}${environment.apiVersion}admin/logs`;
		let params:any = logSearchCriteria;
		if (sortingCriteria) {
			params = {
				pageIndex: sortingCriteria.pageIndex,
				pageSize: sortingCriteria.pageSize,
				...params
			}

			if (sortingCriteria.sort && sortingCriteria.order) {
				params = {
					sort: sortingCriteria.sort,
					order: sortingCriteria.order,
					... params
				}
			}
		}
		return this.http.post<PagedResult<IEventLogDetail>>(url, params);
	}

	/**
	 * Posts a log with varying severities.
	 * @param error a model of the error
	 */
	logMessage(logLevel: string, error: any, message: string, detail: string): Observable<boolean> {
		// todo remove the fake retjun
		return of(true);
		// Create a neat error message for the server to log
		console.log('logMessage started', detail);
		const customMessage = this.constructLogMessage(error, message);
		console.log('custom logMessage', customMessage, message);
		// Construct the log message model
		const body = {
			logLevel,
			message: customMessage,
			detail
		};

		// const url = `${this.configService.config.connections.webApiBaseUrl}log`;
		// return this.http.post<boolean>(url, body);
	}

	/**
	 * This generates a stack trace before the event occurred
	 * Also logs the message POSTing to the API.
	 * @param error The error provided by the error handlers
	 * @param message The custom message provided by the error handlers
	 */
	logErrorWithStackTrace(error: any, message: string) {
		console.log(error);
		if (!!error && !!error.error) {
			// Generate a stack trace and log it
			console.log('Can we do better than stackTrace??');
			// StackTrace.fromError(error)
			// 	.then(stackframes => {
			// 		const detail = stackframes.map(sf => sf.toString()).join('\n');

			// 		// Log the message
			// 		this.logMessage('Error', error, message, detail).subscribe();
			// 	})
			// 	.catch(err => {
			// 		console.log('Error when logging with stack trace...');
			// 		console.log(err);
			// 	});
		} else {
			this.logMessage('Error', error, message, null).subscribe();
		}
	}

	/** Constructs a detailed message with any available information */
	constructLogMessage(error: any, message: string) {
		let response = message + '\n';
		if (!!error) {
			response += error.status ? `Status Code: ${error.status}\n` : '';
			response += error.statusText ? `Http Response: ${error.statusText}\n` : '';
			response += error.url ? `Error Url: ${error.url}\n` : '';
			response += this.getExtraLogInfo();
		}

		return response;
	}

	/** Some extra logging information */
	getExtraLogInfo() {
		return `Page On: ${window.location.pathname}
Referrer: ${document.referrer}
Browser Name: ${navigator.appName}
Browser Engine: ${navigator.product}
User Agent: ${navigator.userAgent}`;
	}
}