using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskFlowPro.API.DTOs;
using TaskFlowPro.API.Helpers;
using TaskFlowPro.API.Models;
using TaskFlowPro.API.Services;
//using TaskFlowPro.Models;

namespace TaskFlowPro.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TasksController : ControllerBase
{
    private readonly TaskService _taskService;
      
    public TasksController(TaskService taskService)
    {
        _taskService = taskService;
    }
    private int GetLoggedInUserId()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        return int.Parse(userId!);
    }

    [HttpGet]
    public async Task<ActionResult<List<TaskItem>>> GetTasks()
    {
        var tasks = await _taskService.GetTasks();

        return Ok(new ApiResponse<IEnumerable<TaskItem>>(
        true,
        "Tasks retrieved successfully.",
        tasks
        ));
    }

    [HttpPost]
    public async Task<ActionResult<TaskItem>> CreateTask(CreateTaskDto createTaskDto)
    {
        var userId = GetLoggedInUserId();

        var task = new TaskItem
        {
            Title = createTaskDto.Title,
            Description = createTaskDto.Description,
            IsCompleted = createTaskDto.IsCompleted,
            UserId = userId
        };

        var createdTask = await _taskService.CreateTask(task);

        return CreatedAtAction(
        nameof(GetTaskById),
        new { id = createdTask.Id },
        new ApiResponse<TaskItem>(
        true,
        "Task created successfully.",
        createdTask
    )
    );  
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> GetTaskById(int id)
    {
        var task = await _taskService.GetTaskById(id);

        if (task == null)
        {
            return NotFound(new ApiResponse<object>(
             false,
            "Task not found.",
            null
            ));
        }

        return Ok(new ApiResponse<TaskItem>(
        true,
        "Task retrieved successfully.",
        task
        ));
    }

    [HttpGet("mytasks")]
    public async Task<IActionResult> GetMyTasks()
    {
        var userId = GetLoggedInUserId();

        var tasks = await _taskService.GetTasksByUser(userId);

        return Ok(new ApiResponse<List<TaskDto>>(
            true,
            "Tasks retrieved successfully.",
            tasks
        ));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TaskItem>> UpdateTask(int id, UpdateTaskDto updateTaskDto)
    {
        var userId = GetLoggedInUserId();

        var task = new TaskItem
        {
            Title = updateTaskDto.Title,
            Description = updateTaskDto.Description,
            IsCompleted = updateTaskDto.IsCompleted,
            UserId = userId
        };

        var updatedTask = await _taskService.UpdateTask(id, task);

        if (updatedTask == null)
        {
            return NotFound(new ApiResponse<object>(
            false,
            "Task not found.",
            null
            ));
        }

        return Ok(new ApiResponse<TaskItem>(
        true,
        "Task updated successfully.",
        updatedTask
        ));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTask(int id)
    {
        var userId = GetLoggedInUserId();

        var deleted = await _taskService.DeleteTask(id, userId);

        if (!deleted)
        {
            return NotFound(new ApiResponse<object>(
            false,
            "Task not found.",
            null
            ));
        }

        return Ok(new ApiResponse<object>(
        true,
        "Task deleted successfully.",
        null
        ));
    }
}