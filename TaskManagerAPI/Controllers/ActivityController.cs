using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Data;
using TaskManagerAPI.DTO.Request;
using TaskManagerAPI.DTO.Response;
using TaskManagerAPI.Models;
using TaskManagerAPI.Services;

namespace TaskManagerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivityController: ControllerBase
{
    private readonly ActivityService _activityService;

    public ActivityController(ActivityService activityService)
    {
        _activityService = activityService;
    }

    [HttpPost]
    public async Task<ActionResult<ActivityDTOResponse>> AddActivity(ActivityDTORequest activityDtoRequest)
    {
        var createdActivity = await _activityService.AddActivity(activityDtoRequest);
        return Ok(createdActivity);
    }

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActivityDTOResponse>>> GetAllActivities()
    {
        IEnumerable<ActivityDTOResponse> allActivityDtoResponse = await _activityService.GetAllActivities();
        return Ok(allActivityDtoResponse);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ActivityDTOResponse>> GetActivityById(int id)
    {
        ActivityDTOResponse activityDtoResponse = await _activityService.GetActivityById(id);
        return Ok(activityDtoResponse);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ActivityDTOResponse>> UpdateActivity(int id , ActivityDTORequest activityDtoRequest)
    {
        ActivityDTOResponse activityDtoResponse = await _activityService.UpdateActivity(id , activityDtoRequest);
        return Ok(activityDtoResponse);
    }
    



}