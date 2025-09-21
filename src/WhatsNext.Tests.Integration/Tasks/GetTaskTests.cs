using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace WhatsNext.Api.Tests.Tasks;

public class GetTaskTests
{
    private readonly HttpClient _client;

    public GetTaskTests()
    {
        var factory = new WhatsNextApiFactory();
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ShouldBeAbleToGetTask_AfterSuccessfulCreate()
    {
        var request = new
            { Title = nameof(ShouldBeAbleToGetTask_AfterSuccessfulCreate), Description = "Some Description" };
        var createResponse = await _client.PostAsJsonAsync("/v1/tasks", request);
        Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

        var getResponse = await _client.GetAsync($"/v1/tasks/{createResponse.Headers.Location}");
        Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
        var getResponseObject =
            JsonSerializer.Deserialize<GetTaskResponse>(await getResponse.Content.ReadAsStringAsync());
        Assert.NotNull(getResponseObject);
        Assert.Equal(request.Title, getResponseObject.Title);
        Assert.Equal(request.Description, getResponseObject.Description);
    }

    private class GetTaskResponse
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}