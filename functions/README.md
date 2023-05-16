# Serverless Function Workloads

## Microsoft Azure

> [Azure Functions Documentation](https://learn.microsoft.com/azure/azure-functions)

Prerequisite is the [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-windows).

### C#

### Java

[__Local Run:__](https://learn.microsoft.com/en-us/azure/azure-functions/create-first-function-cli-java)

```shell
mvn clean install
mvn azure-functions:run
```

__Deployment:__

```shell
az login
mvn azure-functions:deploy
```

## Google Cloud Platform (GCP)

> [GCP Functions Documentation](https://cloud.google.com/functions/docs/writing)

Prerequisite is the [Google Cloud CLI](https://cloud.google.com/sdk/gcloud).

### Java

[__Local
Run:__](https://github.com/GoogleCloudPlatform/functions-framework-java#running-a-function-with-the-maven-plugin)

```shell
mvn clean install
mvn function:run
```

[__Deployment:__](https://cloud.google.com/functions/docs/create-deploy-http-java)

```shell
gcloud functions deploy my-first-function --entry-point functions.HelloWorld --runtime java17 --trigger-http --memory 512MB --allow-unauthenticated
gcloud functions describe my-first-function
gcloud functions logs read my-first-function
```
