declare const require: any;

export const environment = {
  production: true,
  baseURL: 'https://pcookbook.z8.web.core.windows.net/',
  apiUrl: 'https://pcookbook-api.azurewebsites.net/',
  apiVersion: '/api/v1/',
  version: require('../../package.json').version,
  resultsPerPage: 10,
};
