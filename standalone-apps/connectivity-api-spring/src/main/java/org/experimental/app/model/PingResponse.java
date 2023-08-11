package org.experimental.app.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.Data;
import org.springframework.http.HttpStatusCode;

@Data
public class PingResponse {
    private String requestUrl;
    private String status;
    private String responseBody;
    private Boolean success;

    public void setStatus(HttpStatusCode status) {
        this.status = status.toString();
    }
}
