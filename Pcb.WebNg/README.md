# CookBook

This project is designed to assist in stocking up your pantry to enable you to create many meals, converting cups to kg etc. Originally intended for school's Food Science programs it has been adapted for the long term planner / provisioner. 

## Technology used in front end
Angular 11+<br/>
Angular Material 10+<br/>
rxjs 6.6.x<br/>
auth0 JWT<br/>

## Server side
API written in .NET 5.0<br/>
MsSql database updated with Entity First Framework<br/>
Azure hosted service: App Service, SQL Database, Storage Account and Application Insights<br/>
Auth using Google as a social provider and API provided JWT<br/>
Recipes and ingredients from Spoonacular api (thank you) - https://spoonacular.com/food-api<br/>
Raw ingredient / nutritional Data sourced from the Usda Food database<br/>

## Development server
Run `ng serve --ssl` for a dev server. Navigate to `https://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).


## Further help

To get more help on the `angular-cli` use `ng help` or go check out the [Angular-CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
