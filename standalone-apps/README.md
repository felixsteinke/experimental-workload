# Sorting Sample

## 1. Spring API Implementation

All commands are relative to the project directory:

```shell
cd ./spring-api
```

### 1.1. Docker Commands

__Docker Hub:__ [felixsteinke/sorting-api](https://hub.docker.com/r/felixsteinke/sorting-api)

```shell
docker build -t  felixsteinke/sorting-api:v1 .
docker push felixsteinke/sorting-api:v1  
```

### 1.2. GraalVM Native Support

This project has been configured to let you generate either a lightweight container or a native executable. It is also
possible to run your tests in a native image.

__Lightweight Container with Cloud Native Buildpacks:__

If you're already familiar with Spring Boot container images support, this is the easiest way to get started. Docker
should be installed and configured on your machine prior to creating the image.

To create the image, run the following goal:

```shell
./mvnw spring-boot:build-image -Pnative
```

Then, you can run the app like any other container:

```shell
docker run --rm -p 8080:8080 sorting:0.0.1-SNAPSHOT
```

__Executable with Native Build Tools:__

Use this option if you want to explore more options such as running your tests in a native image. The
GraalVM `native-image` compiler should be installed and configured on your machine.

NOTE: GraalVM 22.3+ is required.

To create the executable, run the following goal:

```shell
./mvnw native:compile -Pnative
```

Then, you can run the app as follows:

```shell
target/sorting
```

You can also run your existing tests suite in a native image. This is an efficient way to validate the compatibility of
your application.

To run your existing tests in a native image, run the following goal:

```shell
./mvnw test -PnativeTest
```

### 1.3. Reference Documentation

For further reference, please consider the following sections:

* [Official Apache Maven documentation](https://maven.apache.org/guides/index.html)
* [Spring Boot Maven Plugin Reference Guide](https://docs.spring.io/spring-boot/docs/3.0.5/maven-plugin/reference/html/)
* [Create an OCI image](https://docs.spring.io/spring-boot/docs/3.0.5/maven-plugin/reference/html/#build-image)
* [GraalVM Native Image Support](https://docs.spring.io/spring-boot/docs/3.0.5/reference/html/native-image.html#native-image)
* [Spring Web](https://docs.spring.io/spring-boot/docs/3.0.5/reference/htmlsingle/#web)

The following guides illustrate how to use some features concretely:

* [Building a RESTful Web Service](https://spring.io/guides/gs/rest-service/)
* [Serving Web Content with Spring MVC](https://spring.io/guides/gs/serving-web-content/)
* [Building REST services with Spring](https://spring.io/guides/tutorials/rest/)

These additional references should also help you:

* [Configure AOT settings in Build Plugin](https://docs.spring.io/spring-boot/docs/3.0.5/maven-plugin/reference/htmlsingle/#aot)
