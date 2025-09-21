using System.Net;
using System.Net.Http.Json;

namespace WhatsNext.Api.Tests.Tasks;

public class CreateTaskTests : IClassFixture<WhatsNextApiFactory>
{
    private readonly HttpClient _client;

    public CreateTaskTests()
    {
        var factory = new WhatsNextApiFactory();
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task should_return_201_when_task_is_created()
    {
        var request = new { Title = "Test Task", Description = "Test Description" };
        var response = await _client.PostAsJsonAsync("/v1/tasks", request);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task should_return_400_when_creating_task_with_invalid_data()
    {
        var request = new { Invalid = "Data" };
        var response = await _client.PostAsJsonAsync("/v1/tasks", request);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var request2 = new { Title = "InvalidData" };
        response = await _client.PostAsJsonAsync("/v1/tasks", request2);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var request3 = new { Title = "InvalidData", Description = true };
        response = await _client.PostAsJsonAsync("/v1/tasks", request3);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}