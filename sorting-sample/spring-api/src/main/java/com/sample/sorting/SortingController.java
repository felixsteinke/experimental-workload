package com.sample.sorting;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.util.Arrays;

@RestController
public class SortingController {

    @PostMapping("/sort-on1")
    public ResponseEntity<int[]> sortOn1(@RequestBody int[] numbers) {
        // Sort the input array using O(n*log(n)) algorithm
        Arrays.sort(numbers);
        return new ResponseEntity<>(numbers, HttpStatus.OK);
    }

    @PostMapping("/sort-on2")
    public ResponseEntity<int[]> sortOn2(@RequestBody int[] numbers) {
        // Sort the input array using O(n^2) algorithm
        for (int i = 0; i < numbers.length; i++) {
            for (int j = i + 1; j < numbers.length; j++) {
                if (numbers[j] < numbers[i]) {
                    int temp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;
                }
            }
        }
        return new ResponseEntity<>(numbers, HttpStatus.OK);
    }

    @PostMapping("/sort-on3")
    public ResponseEntity<int[]> sortOn3(@RequestBody int[] numbers) {
        // Sort the input array using O(n^3) algorithm
        for (int i = 0; i < numbers.length; i++) {
            for (int j = i + 1; j < numbers.length; j++) {
                for (int k = j + 1; k < numbers.length; k++) {
                    if (numbers[i] > numbers[j]) {
                        int temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                    if (numbers[j] > numbers[k]) {
                        int temp = numbers[j];
                        numbers[j] = numbers[k];
                        numbers[k] = temp;
                    }
                }
            }
        }
        return new ResponseEntity<>(numbers, HttpStatus.OK);
    }
}
