using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.DTO.Request;
using TaskManagerAPI.DTO.Response;
using TaskManagerAPI.Models;
using TaskManagerAPI.Repositories.Interface;

namespace TaskManagerAPI.Repositories;

public class ActivityRepository: IActivityRepository
{
    //DI
    private readonly ApplicationDbContext _context;

    public ActivityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    //POST Rest API.
    public async Task<Activity> AddActivity(ActivityDTORequest activityDtoRequest)
    {
        Activity activity = new Activity
        (
            activityDtoRequest.Title,
            activityDtoRequest.Description,
            activityDtoRequest.IsCompleted
        );
        
        _context.Activities.Add(activity);
        await _context.SaveChangesAsync();
        
        return activity;
    }

    //GET Rest API.
    public async Task<IEnumerable<Activity>> GetAllActivities()
    {
         IEnumerable<Activity> activities = await _context.Activities.ToListAsync();
         return activities;
    }

    //GET Rest API for get one activity.
    public async Task<Activity> GetActivityById(int id)
    {
        Activity activity = await _context.Activities.FindAsync(id);
        return activity;
    }

    //UPDATE Rest API.
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

    
    //DELETE Rest API.
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