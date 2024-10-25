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

}