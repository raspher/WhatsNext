using System.ComponentModel.DataAnnotations;

namespace WhatsNext.Contracts.Tasks.DTOs;

public record CreateTaskRequest
{
    [Required] public required string Title { get; set; }

    [Required] public required string Description { get; set; }

    public double CompletedPercentage { get; set; } = 0;
    public DateTime? ExpiryDate { get; set; }
}