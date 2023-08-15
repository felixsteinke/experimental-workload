package org.experimental.app.model;

import lombok.Data;

@Data
public class JdbcPing {
    private String connectionUrl;
    private String username;
    private String password;
}
