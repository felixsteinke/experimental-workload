package org.experimental.app;

import org.experimental.app.model.JdbcPing;
import org.experimental.app.model.PingResponse;
import org.experimental.app.model.RestPing;
import org.springframework.http.HttpStatusCode;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.reactive.function.client.WebClient;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

@CrossOrigin(origins = "*")
@RestController
@RequestMapping("/api")
public class Controller {

    private final WebClient webClient;

    public Controller() {
        this.webClient = WebClient.builder().build();
    }

    @PostMapping("/ping-api")
    public ResponseEntity<PingResponse> pingRestApi(@RequestBody RestPing pingRequest) {
        var pingResponse = new PingResponse();
        pingResponse.setRequestUrl(pingRequest.getUrl());

        try {
            var responseSpec = webClient.get().uri(pingRequest.getUrl()).retrieve();
            var status = getStatusCode(responseSpec);

            pingResponse.setResponseBody(responseSpec.bodyToMono(String.class).block());
            pingResponse.setStatus(status);
            pingResponse.setSuccess(!status.is4xxClientError() && !status.is5xxServerError());
        } catch (Exception e) {
            pingResponse.setResponseBody(e.getClass().getSimpleName() + ": " + e.getMessage());
            pingResponse.setStatus(HttpStatusCode.valueOf(500));
            pingResponse.setSuccess(false);
        }

        return ResponseEntity.ok(pingResponse);
    }

    @PostMapping("/ping-database")
    public ResponseEntity<PingResponse> pingDatabase(@RequestBody JdbcPing pingRequest) {
        var pingResponse = new PingResponse();
        pingResponse.setRequestUrl(pingRequest.getConnectionUrl());

        try (Connection connection = DriverManager.getConnection(pingRequest.getConnectionUrl(), pingRequest.getUsername(), pingRequest.getPassword());
             PreparedStatement preparedStatement = connection.prepareStatement("SELECT 1");
             ResultSet resultSet = preparedStatement.executeQuery()) {
            if (resultSet.next()) {
                pingResponse.setResponseBody("Successful query of SELECT 1.");
            } else {
                pingResponse.setResponseBody("Successful query with empty result.");
            }
            pingResponse.setStatus(HttpStatusCode.valueOf(200));
            pingResponse.setSuccess(true);
        } catch (Exception e) {
            pingResponse.setResponseBody(e.getClass().getSimpleName() + ": " + e.getMessage());
            pingResponse.setStatus(HttpStatusCode.valueOf(500));
            pingResponse.setSuccess(false);
        }

        return ResponseEntity.ok(pingResponse);
    }

    private HttpStatusCode getStatusCode(WebClient.ResponseSpec responseSpec) {
        var response = responseSpec.toBodilessEntity().block();
        if (response == null) {
            return HttpStatusCode.valueOf(404);
        }
        return response.getStatusCode();
    }
}
