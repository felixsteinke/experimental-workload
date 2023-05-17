package org.experimental.app.service;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertTrue;

class SortingProcessorTest {

    private ArrayList<Integer> sampleArray;

    private static boolean isSorted(List<Integer> array) {
        for (int i = 0; i < array.size() - 1; i++) {
            if (array.get(i) > array.get(i + 1)) {
                return false;
            }
        }
        return true;
    }

    @BeforeEach
    void prepareArray() {
        sampleArray = new ArrayList<>(List.of(5, 3, 4, 1, 2));
    }

    @Test
    void sortInON1() {
        // Act
        SortingProcessor.sortInON1(sampleArray);
        // Verify
        assertTrue(isSorted(sampleArray), "sample array is sorted");
    }

    @Test
    void sortInON2() {
        // Act
        SortingProcessor.sortInON2(sampleArray);
        // Verify
        assertTrue(isSorted(sampleArray), "sample array is sorted");
    }

    @Test
    void sortInON3() {
        // Act
        SortingProcessor.sortInON3(sampleArray);
        // Verify
        assertTrue(isSorted(sampleArray), "sample array is sorted");
    }
}
