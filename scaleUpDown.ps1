<#
.SYNOPSIS
    This script changes the service plan of an Azure resource to the specified sku.

.DESCRIPTION
    Designed to run as an build pipeline triggered on a twice daily basis following https://medium.com/@juescuder/automatic-scale-up-or-down-for-app-service-plans-with-azure-devops-3044e09f01a9.

.PARAMETER sku
    The parameter sku is used to define the sku to shift to.

.EXAMPLE
    .\scaleUpDown.ps1 B1

.EXAMPLE
    .\scaleUpDown.ps1 S1

.NOTES
    Author: Ian Oxwell
    Last Edit: 2021-02-06
    Version 1.0 - initial release of scaleUpDown
#>

param ($sku)
$subscription = "OxwellDevCred"
$resourceGroup = "PCookbook"
$appServicePlan = "pcookbook-linux"
$appService = "pcookbook-api"

az appservice plan update --name $appServicePlan --resource-group $resourceGroup --subscription $subscription --sku $sku
az webapp restart --name $appService --resource-group $resourceGroup --subscription $subscription
