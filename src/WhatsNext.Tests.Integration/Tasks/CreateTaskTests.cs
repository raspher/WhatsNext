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
}