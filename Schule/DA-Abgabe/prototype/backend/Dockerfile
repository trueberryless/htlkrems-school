FROM openjdk:21-jdk
WORKDIR /app

COPY .mvn/ .mvn
COPY mvnw pom.xml ./
RUN ./mvnw dependency:go-offline

COPY src ./src
RUN ./mvnw package -Dmaven.test.skip
CMD ["java", "-jar", "./target/ndfa-backend.jar"]