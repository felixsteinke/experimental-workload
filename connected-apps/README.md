# Workload from Connected Apps

## Database API

> Requirement: Microsoft SQL Server on port `1433` with `exp_workload_db`

### .NET Implementation

### Spring Boot Implementation

* Project location: `cd ./db-api-spring`
* Local execution:
    * Build and test application: `mvn package`
    * Run application: `mvn spring-boot:run`
* Container:
    * Build image: `docker build -t felixsteinke/db-api-spring:latest .`
    * Run container: `docker run -p 8080:80 felixsteinke/db-api-spring:latest`
    * Push image: `docker push felixsteinke/db-api-spring:latest`
