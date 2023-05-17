using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using sorting_api_dotnet;
using System.Net.Http.Json;
using Xunit.Abstractions;

namespace sorting_api_dotnet_test.Controllers;

public class SortingControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient client;
    private readonly ITestOutputHelper output;
    private readonly List<int> sampleArray;

    public SortingControllerTest(WebApplicationFactory<Program> factory, ITestOutputHelper outputHelper)
    {
        client = factory.CreateClient();
        output = outputHelper;
        sampleArray = new List<int> { 5, 3, 4, 1, 2 };
    }

    [Fact]
    public async Task SortOn1()
    {
        output.WriteLine($"Test Input: {JsonConvert.SerializeObject(sampleArray)}");
        // Act
        var response = await client.PostAsJsonAsync("/api/sort-on1", sampleArray);
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        // Assert
        sampleArray.Sort();
        Assert.Equal(JsonConvert.SerializeObject(sampleArray), responseString);
    }


    [Fact]
    public async Task SortOn2()
    {
        output.WriteLine($"Test Input: {JsonConvert.SerializeObject(sampleArray)}");
        // Act
        var response = await client.PostAsJsonAsync("/api/sort-on2", sampleArray);
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        // Assert
        sampleArray.Sort();
        Assert.Equal(JsonConvert.SerializeObject(sampleArray), responseString);
    }

    [Fact]
    public async Task SortOn3()
    {
        output.WriteLine($"Test Input: {JsonConvert.SerializeObject(sampleArray)}");
        // Act
        var response = await client.PostAsJsonAsync("/api/sort-on3", sampleArray);
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();
        // Assert
        sampleArray.Sort();
        Assert.Equal(JsonConvert.SerializeObject(sampleArray), responseString);
    }
}