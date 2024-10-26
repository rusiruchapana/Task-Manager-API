using TaskManagerAPI.DTO.Request;
using TaskManagerAPI.DTO.Response;
using TaskManagerAPI.Models;
using TaskManagerAPI.Repositories.Interface;

namespace TaskManagerAPI.Services;

public class ActivityService
{
    private readonly IActivityRepository _activityRepository;

    public ActivityService(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<ActivityDTOResponse> AddActivity(ActivityDTORequest activityDtoRequest)
    {
        Activity activity = new Activity(
            activityDtoRequest.Title,
            activityDtoRequest.Description,
            activityDtoRequest.IsCompleted
        );
        
        ActivityDTOResponse activityDtoResponse = await _activityRepository.AddActivity(activity);
        return activityDtoResponse;
    }


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
}