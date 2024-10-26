using TaskManagerAPI.DTO.Request;
using TaskManagerAPI.DTO.Response;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Repositories.Interface;

public interface IActivityRepository
{
    
    Task<IEnumerable<Activity>> GetAllActivities();
    Task<Activity> GetActivityById(int id);
    Task<Activity> UpdateActivity(int id, ActivityDTORequest activityDtoRequest);
    Task<bool> DeleteActivity(int id);
    Task<Activity> AddActivity(ActivityDTORequest activityDtoRequest);
    
}