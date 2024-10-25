namespace TaskManagerAPI.DTO.Response;

public class ActivityDTOResponse
{
    public int Id{ get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }

    public ActivityDTOResponse()
    {
    }

    public ActivityDTOResponse(int id, string? title, string? description, bool isCompleted)
    {
        Id = id;
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
    }
}