using TaskManagerAPI.DTO.Request;
using TaskManagerAPI.DTO.Response;
using TaskManagerAPI.Models;
using TaskManagerAPI.Repositories.Interface;

namespace TaskManagerAPI.Services;

public class ActivityService
{
    //DI
    private readonly IActivityRepository _activityRepository;

    public ActivityService(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }
    
    //POST Rest API.
    public async Task<ActivityDTOResponse> AddActivity(ActivityDTORequest activityDtoRequest)
    {
        Activity activity = await _activityRepository.AddActivity(activityDtoRequest);

        ActivityDTOResponse activityDtoResponse = new ActivityDTOResponse
        (
            activity.Id,
            activity.Title,
            activity.Description,
            activity.IsCompleted
        );
        
        return activityDtoResponse;
    }

    
    //GET Rest API.
    public async Task<IEnumerable<ActivityDTOResponse>> GetAllActivities()
    {
        IEnumerable<Activity> activities = await _activityRepository.GetAllActivities();

        IEnumerable<ActivityDTOResponse> activityDtoResponses = activities.Select(activity => new ActivityDTOResponse
            {
                Id = activity.Id,
                Title = activity.Title,
                Description = activity.Description,
                IsCompleted = activity.IsCompleted
            }
        );
        
        return activityDtoResponses;
    }

    //GET Rest API for get one activity.
    public async Task<ActivityDTOResponse> GetActivityById(int id)
    {
        Activity activity = await _activityRepository.GetActivityById(id);
        ActivityDTOResponse activityDtoResponse = new ActivityDTOResponse
        (
            activity.Id,
            activity.Title,
            activity.Description,
            activity.IsCompleted
        );
        return activityDtoResponse;
    }

    //UPDATE Rest API.
    public async Task<ActivityDTOResponse> UpdateActivity(int id, ActivityDTORequest activityDtoRequest)
    {
        Activity activity = await _activityRepository.UpdateActivity(id, activityDtoRequest);
        ActivityDTOResponse activityDtoResponse = new ActivityDTOResponse
        (
            activity.Id,
            activity.Title,
            activity.Description,
            activity.IsCompleted
        );
        
        return activityDtoResponse;
    }

    //DELETE Rest API.
    public async Task<bool> DeleteActivity(int id)
    {
        bool check = await _activityRepository.DeleteActivity(id);
        return check;
    }

    
}