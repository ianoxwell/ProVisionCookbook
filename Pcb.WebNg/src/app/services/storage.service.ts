import { Injectable } from '@angular/core';
import { Observable, fromEvent } from 'rxjs';
import { filter, map } from 'rxjs/operators';

@Injectable()
export class StorageService {
	getItem(key: string): string {
		return this.getStorage().getItem(key);
	}
	setItem(key: string, value: string): void {
		this.getStorage().setItem(key, value);
	}
	removeItem(key: string) {
		this.getStorage().removeItem(key);
	}
	observeItem(key: string): Observable<string> {
		const observable = fromEvent<StorageEvent>(window, 'storage')
			.pipe(
				filter(event => event.storageArea === this.getStorage()),
				filter(event => event.key === key),
				map(event => event.newValue)
			);

		return observable;
	}

	private getStorage(): Storage {
		return window.localStorage;
	}
}