package org.experimental.function;

import java.util.ArrayList;

public abstract class SortingProcessor {

    /**
     * O(n*log(n)) sorting algorithm
     *
     * @param numbers as mutable array to be sorted
     */
    public static void sortInON1(ArrayList<Integer> numbers) {
        numbers.sort(Integer::compare);
    }

    /**
     * O(n^2) sorting algorithm
     *
     * @param numbers as mutable array to be sorted
     */
    public static void sortInON2(ArrayList<Integer> numbers) {
        for (int i = 0; i < numbers.size(); i++) {
            for (int j = i + 1; j < numbers.size(); j++) {
                if (numbers.get(j) < numbers.get(i)) {
                    int temp = numbers.get(i);
                    numbers.set(i, numbers.get(j));
                    numbers.set(j, temp);
                }
            }
        }
    }

    /**
     * O(n^3) sorting algorithm
     *
     * @param numbers as mutable array to be sorted
     */
    public static void sortInON3(ArrayList<Integer> numbers) {
        for (int i = 0; i < numbers.size(); i++) {
            for (int j = i + 1; j < numbers.size(); j++) {
                for (int k = j + 1; k < numbers.size(); k++) {
                    if (numbers.get(i) > numbers.get(j)) {
                        Integer temp = numbers.get(i);
                        numbers.set(i, numbers.get(j));
                        numbers.set(j, temp);
                    }
                    if (numbers.get(j) > numbers.get(k)) {
                        Integer temp = numbers.get(j);
                        numbers.set(j, numbers.get(k));
                        numbers.set(k, temp);
                    }
                }
            }
        }
    }
}


