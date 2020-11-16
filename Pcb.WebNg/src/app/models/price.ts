/**
 * Provisioners CookBook Api
 * This is the API for the Provisioner's CookBook Project
 *
 * OpenAPI spec version: 1.0.0-oas3
 * Contact: ianoxwell@gmail.com
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */

export interface Price {
	_id?: string;
	brandName?: string;
	price: number;
	quantity: number;
	measurement?: string;
	storeName?: string;
	lastChecked?: number | Date;
	apiLink?: string;
}