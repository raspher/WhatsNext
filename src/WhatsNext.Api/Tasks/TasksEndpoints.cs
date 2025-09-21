using WhatsNext.Api.Tasks.DTOs;

namespace WhatsNext.Api.Tasks;

public static class TasksEndpoints
{
    private const string BasePath = "/v1/tasks";

    public static void MapTasksEndpoints(this WebApplication app)
    {
        app.MapPost(BasePath, (CreateTaskRequest request) =>
        {
            var result = new TaskDetailsResponse
            {
                Id = Guid.NewGuid().ToString(),
                Title = request.Title,
                Description = request.Description
            };
            return TypedResults.Created(result.Id, result);
        });
    }
}