import { Injectable } from '@angular/core';
import { fromEvent, Observable } from 'rxjs';
import { filter, map } from 'rxjs/operators';

@Injectable()
export class StorageService {
	/**
	 * Gets item from local storage, if key is not found returns 'null'.
	 * @param key string key to check on localStorage.
	 * @returns string - if unable to find returns string of 'null' - odd.
	 */
	getItem(key: string): string | null {
		return this.getStorage().getItem(key);
	}

	/**
	 * Sets localStorage key value pair.
	 * @param key key to set.
	 * @param value value to set key to.
	 */
	setItem(key: string, value: string): void {
		this.getStorage().setItem(key, value);
	}

	/**
	 * Removes key from the localStorage.
	 * @param key item name to remove.
	 */
	removeItem(key: string) {
		this.getStorage().removeItem(key);
	}

	/**
	 * Creates an observable from any storage events related to key.
	 * @param key item name to observe.
	 * @returns the new value of the observed item.
	 */
	observeItem(key: string): Observable<string> {
		return fromEvent<StorageEvent>(window, 'storage')
			.pipe(
				filter(event => event.storageArea === this.getStorage()),
				filter(event => event.key === key),
				map(event => event.newValue)
			);
	}

	/**
	 * private method to access the localStorage.
	 * @returns localStorage.
	 */
	private getStorage(): Storage {
		return window.localStorage;
	}
}