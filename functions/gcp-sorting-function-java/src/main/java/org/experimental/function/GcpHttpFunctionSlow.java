package org.experimental.function;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.google.cloud.functions.HttpFunction;
import com.google.cloud.functions.HttpRequest;
import com.google.cloud.functions.HttpResponse;

import java.io.BufferedWriter;
import java.util.ArrayList;
import java.util.logging.Logger;
import java.util.stream.Collectors;

/**
 * Google Cloud Functions with HTTP Trigger.
 */
public class GcpHttpFunctionSlow implements HttpFunction {
    private static final ObjectMapper OBJ_MAPPER = new ObjectMapper();
    private final Logger LOGGER = Logger.getLogger(GcpHttpFunctionFast.class.getName());

    @Override
    public void service(HttpRequest httpRequest, HttpResponse httpResponse) throws Exception {
        String jsonBody = httpRequest.getReader().lines().collect(Collectors.joining());
        // Logging
        LOGGER.info("Gcp HTTP [" + httpRequest.getMethod() + "] function processed a slow request with body: " + jsonBody);

        try (BufferedWriter writer = httpResponse.getWriter()) {
            // Validation
            if (jsonBody.isBlank()) {
                httpResponse.setStatusCode(400);
                httpResponse.setContentType("application/json");
                writer.write("Only requests with body can be processed.");
                return;
            }
            // Process
            final ArrayList<Integer> body = OBJ_MAPPER.readValue(jsonBody, OBJ_MAPPER.getTypeFactory().constructCollectionType(ArrayList.class, Integer.class));
            SortingProcessor.sortInON2(body);
            // Response
            httpResponse.setStatusCode(200);
            httpResponse.setContentType("application/json");
            writer.write(OBJ_MAPPER.writeValueAsString(body));
        }
    }
}
