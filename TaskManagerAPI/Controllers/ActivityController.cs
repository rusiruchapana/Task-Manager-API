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
    //DI
    private readonly ActivityService _activityService;

    public ActivityController(ActivityService activityService)
    {
        _activityService = activityService;
    }

    
    //POST Rest API.
    [HttpPost]
    public async Task<ActionResult<ActivityDTOResponse>> AddActivity(ActivityDTORequest activityDtoRequest)
    {
        ActivityDTOResponse activityDtoResponse = await _activityService.AddActivity(activityDtoRequest);
        return Ok(activityDtoResponse);
    }

    
    //GET Rest API.
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActivityDTOResponse>>> GetAllActivities()
    {
        IEnumerable<ActivityDTOResponse> allActivityDtoResponse = await _activityService.GetAllActivities();
        return Ok(allActivityDtoResponse);
    }

    
    //GET Rest API for get one activity.
    [HttpGet("{id}")]
    public async Task<ActionResult<ActivityDTOResponse>> GetActivityById(int id)
    {
        ActivityDTOResponse activityDtoResponse = await _activityService.GetActivityById(id);
        return Ok(activityDtoResponse);
    }

    
    //UPDATE Rest API.
    [HttpPut("{id}")]
    public async Task<ActionResult<ActivityDTOResponse>> UpdateActivity(int id , ActivityDTORequest activityDtoRequest)
    {
        ActivityDTOResponse activityDtoResponse = await _activityService.UpdateActivity(id , activityDtoRequest);
        return Ok(activityDtoResponse);
    }

    
    //DELETE Rest API.
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActivity(int id)
    {
        bool isDeleted = await _activityService.DeleteActivity(id);

        if (isDeleted)
            return NoContent();
        else
            return NotFound();
    }
}