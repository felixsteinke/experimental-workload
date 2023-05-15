package org.experimental.app;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.util.ArrayList;

@RestController
public class SortingController {

    @PostMapping("/sort-on1")
    public ResponseEntity<ArrayList<Integer>> sortOn1(@RequestBody ArrayList<Integer> numbers) {
        SortingProcessor.sortInON1(numbers);
        return new ResponseEntity<>(numbers, HttpStatus.OK);
    }

    @PostMapping("/sort-on2")
    public ResponseEntity<ArrayList<Integer>> sortOn2(@RequestBody ArrayList<Integer> numbers) {
        SortingProcessor.sortInON2(numbers);
        return new ResponseEntity<>(numbers, HttpStatus.OK);
    }

    @PostMapping("/sort-on3")
    public ResponseEntity<ArrayList<Integer>> sortOn3(@RequestBody ArrayList<Integer> numbers) {
        SortingProcessor.sortInON3(numbers);
        return new ResponseEntity<>(numbers, HttpStatus.OK);
    }
}
