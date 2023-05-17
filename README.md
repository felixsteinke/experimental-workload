# Experimental Workload Repository

## Project Structure

```
root
 |__ connected-apps/  --> applications with external services as dependencies
 |__ functions/       --> serverless functions as native cloud implementations
 |__ libraries/       --> business logic of shared workloads
 |__ standalone-apps/ --> application without external dependencies
 |__ tools/           --> utility tools for experiments
 |__ repo.postman_collection.json --> requests for all applications
 |__ repo.sln         --> packaging for all c# projects
 |__ pom.xml          --> packaging for all java modules
```

Check out the directories for a more detailed description.

## System Requirements

### C# and .NET

* .NET SDK
* .NET IDE (Visual Studio)

### Java and Spring Boot

* JDK 17+
* Maven 3.8+
* Java IDE (IntelliJ)

### Tools

* Docker Desktop
* Postman
