namespace TaskManagerAPI.DTO.Request;

public class ActivityDTORequest
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
}