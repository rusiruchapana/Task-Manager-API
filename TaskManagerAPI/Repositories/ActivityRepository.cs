using TaskManagerAPI.Data;
using TaskManagerAPI.DTO.Response;
using TaskManagerAPI.Models;
using TaskManagerAPI.Repositories.Interface;

namespace TaskManagerAPI.Repositories;

public class ActivityRepository: IActivityRepository
{
    private readonly ApplicationDbContext _context;

    public ActivityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ActivityDTOResponse> AddActivity(Activity activity)
    {
        var entry = _context.Activities.Add(activity);
        await _context.SaveChangesAsync();

        Activity addedActivity = entry.Entity;
        ActivityDTOResponse response = new ActivityDTOResponse(
            addedActivity.Id,
            addedActivity.Title,
            addedActivity.Description,
            addedActivity.IsCompleted
        );
        
        return response;
    }
}