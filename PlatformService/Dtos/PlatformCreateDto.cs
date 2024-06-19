using System.ComponentModel.DataAnnotations;

public record PlatformCreateDto
(
    [Required]
    string Name,
    [Required]
    string Publisher,
    [Required]
    string Cost
);