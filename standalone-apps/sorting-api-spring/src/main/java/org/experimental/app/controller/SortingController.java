package org.experimental.app.controller;

import org.experimental.app.service.SortingProcessor;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.logging.Logger;

@CrossOrigin(origins = "*")
@RestController
@RequestMapping("/api")
public class SortingController {
    private final Logger LOGGER = Logger.getLogger(SortingController.class.getName());

    @PostMapping(path="/sort-on1", produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<ArrayList<Integer>> sortOn1(@RequestBody ArrayList<Integer> requestBody) {
        LOGGER.info("Sorting " + requestBody.size() + " items in O(n*log(n)).");
        SortingProcessor.sortInON1(requestBody);
        return new ResponseEntity<>(requestBody, HttpStatus.OK);
    }

    @PostMapping(path="/sort-on2", produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<ArrayList<Integer>> sortOn2(@RequestBody ArrayList<Integer> requestBody) {
        LOGGER.info("Sorting " + requestBody.size() + " items in O(n^2).");
        SortingProcessor.sortInON2(requestBody);
        return new ResponseEntity<>(requestBody, HttpStatus.OK);
    }

    @PostMapping(path="/sort-on3", produces = MediaType.APPLICATION_JSON_VALUE, consumes = MediaType.APPLICATION_JSON_VALUE)
    public ResponseEntity<ArrayList<Integer>> sortOn3(@RequestBody ArrayList<Integer> requestBody) {
        LOGGER.info("Sorting " + requestBody.size() + " items in O(n^3).");
        SortingProcessor.sortInON3(requestBody);
        return new ResponseEntity<>(requestBody, HttpStatus.OK);
    }
}
