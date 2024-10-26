using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.DTO.Request;
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

    public async Task<IEnumerable<Activity>> GetAllActivities()
    {
         IEnumerable<Activity> activities = await _context.Activities.ToListAsync();
         return activities;
    }

    public async Task<Activity> GetActivityById(int id)
    {
        Activity activity = await _context.Activities.FindAsync(id);
        return activity;
    }

    public async Task<Activity> UpdateActivity(int id, ActivityDTORequest activityDtoRequest)
    {
        Activity oldActivity = await _context.Activities.FindAsync(id);
        oldActivity.Title = activityDtoRequest.Title;
        oldActivity.Description = activityDtoRequest.Description;
        oldActivity.IsCompleted = activityDtoRequest.IsCompleted;

        _context.Activities.Update(oldActivity);
        await _context.SaveChangesAsync();
        
        return oldActivity;
    }

    public async Task<bool> DeleteActivity(int id)
    {
        Activity activity = await _context.Activities.FindAsync(id);
        
        if (activity == null)
        {
            return false;
        }
        else
        {
            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}