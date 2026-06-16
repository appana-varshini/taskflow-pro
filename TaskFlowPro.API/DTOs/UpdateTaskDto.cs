using System.ComponentModel.DataAnnotations;

namespace TaskFlowPro.API.DTOs;

public class UpdateTaskDto
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    public bool IsCompleted { get; set; }
}