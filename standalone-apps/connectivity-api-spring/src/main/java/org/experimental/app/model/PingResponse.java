package org.experimental.app.model;

import lombok.Data;
import org.springframework.http.HttpStatusCode;

@Data
public class PingResponse {
    private String requestUrl;
    private HttpStatusCode status;
    private String responseBody;
    private Boolean success;

    public void setSuccess(HttpStatusCode status) {
        this.success = !status.is4xxClientError() && !status.is5xxServerError();
    }

    public void setSuccess(Boolean success) {
        this.success = success;
    }
}
