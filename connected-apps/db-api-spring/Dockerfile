# Build stage
FROM maven:3.8.4-openjdk-17-slim AS build
WORKDIR /app
COPY pom.xml .
RUN mvn dependency:go-offline
COPY src /app/src/
RUN mvn package -DskipTests

# Run stage
FROM openjdk:17-jdk-slim
WORKDIR /app
COPY --from=build /app/target/db-api-spring-1.0.0.jar /app/api.jar
EXPOSE 80
CMD ["java", "-jar", "/app/api.jar", "--spring.profiles.active=prod"]
