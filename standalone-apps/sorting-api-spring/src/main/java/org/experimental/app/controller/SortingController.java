package org.experimental.app.controller;

import org.experimental.app.service.SortingProcessor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.ArrayList;
import java.util.logging.Logger;

@RestController
@RequestMapping("/api")
public class SortingController {
    private final Logger LOGGER = Logger.getLogger(SortingController.class.getName());

    @PostMapping("/sort-on1")
    public ResponseEntity<ArrayList<Integer>> sortOn1(@RequestBody ArrayList<Integer> requestBody) {
        LOGGER.info("Sorting " + requestBody.size() + " items in O(n*log(n)).");
        SortingProcessor.sortInON1(requestBody);
        return new ResponseEntity<>(requestBody, HttpStatus.OK);
    }

    @PostMapping("/sort-on2")
    public ResponseEntity<ArrayList<Integer>> sortOn2(@RequestBody ArrayList<Integer> requestBody) {
        LOGGER.info("Sorting " + requestBody.size() + " items in O(n^2).");
        SortingProcessor.sortInON2(requestBody);
        return new ResponseEntity<>(requestBody, HttpStatus.OK);
    }

    @PostMapping("/sort-on3")
    public ResponseEntity<ArrayList<Integer>> sortOn3(@RequestBody ArrayList<Integer> requestBody) {
        LOGGER.info("Sorting " + requestBody.size() + " items in O(n^3).");
        SortingProcessor.sortInON3(requestBody);
        return new ResponseEntity<>(requestBody, HttpStatus.OK);
    }
}
