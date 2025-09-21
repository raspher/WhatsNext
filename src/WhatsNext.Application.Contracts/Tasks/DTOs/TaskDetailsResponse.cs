using System.ComponentModel.DataAnnotations;

namespace WhatsNext.Contracts.Tasks.DTOs;

public record TaskDetailsResponse
{
    [Required] public required string Id { get; set; }

    [Required] public required string Title { get; set; }

    [Required] public required string Description { get; set; }

    public double CompletedPercentage { get; set; } = 0;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? ExpiryDate { get; set; }
}