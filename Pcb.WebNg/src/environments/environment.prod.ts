declare const require: any;

export const environment = {
  production: true,
  baseURL: 'https://provisioners-cookbook.herokuapp.com/',
  apiUrl: 'https://localhost:44303',
  apiVersion: '/api/v1/',
  version: require('../../package.json').version,
};
