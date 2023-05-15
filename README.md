# Experimental Workload

## Project Structure

```
dotnet
 |____ az-batch-function		-> Azure Function Project for Batch Computing
 |____ az-continuous-function	-> Azure Function Project for Continuous Application Computing
 |____ batch-computing			-> Business Logic for Batch Computing
 |____ continuous-computing		-> Business Logic for Continuous Application Computing
 |____ web-batch-api			-> Web Application for Batch Computing
 |____ web-continuous-api		-> Web Application for Continuous Application Computing
 |____ web-monolithic-api		-> Web Application for Batch & Continuous Application Computing
 |____ dotnet.sln
```

## Azure Functions

> [Azure Functions Documentation](https://learn.microsoft.com/en-us/azure/azure-functions)

### Prerequisites

* IDE with __Azure Toolkit__ Plugin
* Install [Azure Functions Core Tools](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local)
* Check __System Environment Variable__ `PATH` for `...\Azure Functions Core Tools\`
* Install [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-windows)

### Local Execution

__Java Stack:__

```shell
mvn clean install
cd azure-functions/executable-java-function
mvn azure-functions:run
```

### Deployment

> [Azure Function CLI Usage](https://learn.microsoft.com/en-us/azure/azure-functions/create-first-function-cli-java)

```shell
az login
cd azure-functions/executable-java-function
mvn azure-functions:deploy
```
