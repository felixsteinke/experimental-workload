package org.experimental.function;

import com.microsoft.azure.functions.*;
import com.microsoft.azure.functions.annotation.AuthorizationLevel;
import com.microsoft.azure.functions.annotation.FunctionName;
import com.microsoft.azure.functions.annotation.HttpTrigger;

import java.util.ArrayList;
import java.util.Optional;

/**
 * Azure Functions with HTTP Trigger.
 */
public class AzureHttpFunction {
    /**
     * This function listens at endpoint "/api/sorting-fast".
     */
    @FunctionName("sorting-fast")
    public HttpResponseMessage runFast(
            @HttpTrigger(name = "req", methods = {HttpMethod.GET, HttpMethod.POST}, authLevel = AuthorizationLevel.ANONYMOUS)
                    HttpRequestMessage<Optional<ArrayList<Integer>>> request,
            final ExecutionContext context) {
        // Logging
        context.getLogger().info("Azure Java HTTP [" + request.getHttpMethod() + "] function processed a fast request.");
        // Validation
        if (request.getBody().isEmpty()) {
            return request.createResponseBuilder(HttpStatus.BAD_REQUEST)
                    .body("Only POST requests with body can be processed.")
                    .build();
        }
        // Process
        final ArrayList<Integer> body = request.getBody().get();
        String bodyString = body.toString();
        context.getLogger().info("Request Body: " + ((bodyString.length() > 100) ? bodyString.substring(0, 100) + " ...(" + (bodyString.length() - 100) + " more characters)" : bodyString));
        SortingProcessor.sortInON1(body);
        // Response
        return request.createResponseBuilder(HttpStatus.OK)
                .header("Content-Type", "application/json")
                .body(body)
                .build();
    }

    /**
     * This function listens at endpoint "/api/sorting-slow".
     */
    @FunctionName("sorting-slow")
    public HttpResponseMessage runSlow(
            @HttpTrigger(name = "req", methods = {HttpMethod.GET, HttpMethod.POST}, authLevel = AuthorizationLevel.ANONYMOUS)
                    HttpRequestMessage<Optional<ArrayList<Integer>>> request,
            final ExecutionContext context) {
        // Logging
        context.getLogger().info("Azure Java HTTP [" + request.getHttpMethod() + "] function processed a slow request.");
        // Validation
        if (request.getBody().isEmpty()) {
            return request.createResponseBuilder(HttpStatus.BAD_REQUEST)
                    .body("Only POST requests with body can be processed.")
                    .build();
        }
        // Process
        final ArrayList<Integer> body = request.getBody().get();
        String bodyString = body.toString();
        context.getLogger().info("Request Body: " + ((bodyString.length() > 100) ? bodyString.substring(0, 100) + " ...(" + (bodyString.length() - 100) + " more characters)" : bodyString));
        SortingProcessor.sortInON2(body);
        // Response
        return request.createResponseBuilder(HttpStatus.OK)
                .header("Content-Type", "application/json")
                .body(body)
                .build();
    }
}
