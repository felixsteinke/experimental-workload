package com.sample.sorting;

import org.junit.jupiter.api.Test;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;

import java.util.Arrays;

import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;
import static org.springframework.test.web.servlet.setup.MockMvcBuilders.standaloneSetup;

@WebMvcTest(SortingController.class)
public class SortingControllerTest {

    private final MockMvc mockMvc = standaloneSetup(new SortingController()).build();

    @Test
    public void testSortOn1() throws Exception {
        int[] input = {3, 2, 1};
        int[] expectedOutput = {1, 2, 3};
        String inputJson = Arrays.toString(input);

        mockMvc.perform(MockMvcRequestBuilders.post("/sort-on1")
                        .contentType(MediaType.APPLICATION_JSON_VALUE)
                        .content(inputJson))
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.content().json(Arrays.toString(expectedOutput)));
    }

    @Test
    public void testSortOn2() throws Exception {
        int[] input = {3, 2, 1};
        int[] expectedOutput = {1, 2, 3};
        String inputJson = Arrays.toString(input);

        mockMvc.perform(MockMvcRequestBuilders.post("/sort-on2")
                        .contentType(MediaType.APPLICATION_JSON_VALUE)
                        .content(inputJson))
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.content().json(Arrays.toString(expectedOutput)));
    }

    @Test
    public void testSortOn3() throws Exception {
        int[] input = {3, 2, 1};
        int[] expectedOutput = {1, 2, 3};
        String inputJson = Arrays.toString(input);

        mockMvc.perform(MockMvcRequestBuilders.post("/sort-on3")
                        .contentType(MediaType.APPLICATION_JSON_VALUE)
                        .content(inputJson))
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.content().json(Arrays.toString(expectedOutput)));
    }
}
