# Workload from Standalone Apps

## Sorting API

### .NET Implementation

### Spring Boot Implementation

* Project location: `cd ./sorting-api-spring`
* Local execution:
    * Build and test application: `mvn package`
    * Run application: `mvn spring-boot:run`
* Container:
    * Build image: `docker build -t felixsteinke/sorting-api-spring:latest .`
    * Run container: `docker run -p 8080:80 felixsteinke/sorting-api-spring:latest`
    * Push image: `docker push felixsteinke/sorting-api-spring:latest`
* [Cloud Native Container](https://docs.spring.io/spring-boot/docs/3.0.5/reference/html/native-image.html#native-image)
    * Build native image: `mvn spring-boot:build-image -Pnative`
    * Rename native image: `docker tag sorting-api-spring:1.0.0 felixsteinke/sorting-api-spring:native`
    * Run container: `docker run -p 8080:8080 felixsteinke/sorting-api-spring:native`
    * Push native image: `docker push felixsteinke/sorting-api-spring:native`
* TODOs:
    * Native Swagger UI is not rendered.
