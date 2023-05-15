package org.experimental.app;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;

import java.util.ArrayList;
import java.util.List;

import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;
import static org.springframework.test.web.servlet.setup.MockMvcBuilders.standaloneSetup;

@WebMvcTest(SortingController.class)
public class SortingControllerTest {

    private final MockMvc mockMvc = standaloneSetup(new SortingController()).build();
    private ArrayList<Integer> sampleArray;

    @BeforeEach
    void prepareArray() {
        sampleArray = new ArrayList<>(List.of(5, 3, 4, 1, 2));
    }

    @Test
    public void testSortOn1() throws Exception {
        String request = sampleArray.toString();
        sampleArray.sort(Integer::compareTo);
        String expectedResponse = sampleArray.toString();

        mockMvc.perform(MockMvcRequestBuilders.post("/api/sort-on1")
                        .contentType(MediaType.APPLICATION_JSON_VALUE)
                        .content(request))
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.content()
                        .json(expectedResponse));
    }

    @Test
    public void testSortOn2() throws Exception {
        String request = sampleArray.toString();
        sampleArray.sort(Integer::compareTo);
        String expectedResponse = sampleArray.toString();

        mockMvc.perform(MockMvcRequestBuilders.post("/api/sort-on2")
                        .contentType(MediaType.APPLICATION_JSON_VALUE)
                        .content(request))
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.content()
                        .json(expectedResponse));
    }

    @Test
    public void testSortOn3() throws Exception {
        String request = sampleArray.toString();
        sampleArray.sort(Integer::compareTo);
        String expectedResponse = sampleArray.toString();

        mockMvc.perform(MockMvcRequestBuilders.post("/api/sort-on3")
                        .contentType(MediaType.APPLICATION_JSON_VALUE)
                        .content(request))
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.content()
                        .json(expectedResponse));
    }
}
