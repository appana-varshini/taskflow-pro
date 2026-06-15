using Microsoft.AspNetCore.Mvc;
using TaskFlowPro.API.Models;
using TaskFlowPro.API.Services;
//using TaskFlowPro.Models;

namespace TaskFlowPro.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskService _taskService;
      
    public TasksController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TaskItem>>> GetTasks()
    {
        var tasks = await _taskService.GetTasks();

        return Ok(tasks);
    }

    [HttpPost]
    public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
    {
        var createdTask = await _taskService.CreateTask(task);

        return CreatedAtAction(
            nameof(GetTasks),
            new { id = createdTask.Id },
            createdTask);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> GetTaskById(int id)
    {
        var task = await _taskService.GetTaskById(id);

        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TaskItem>> UpdateTask(int id, TaskItem task)
    {
        var updatedTask = await _taskService.UpdateTask(id, task);

        if (updatedTask == null)
        {
            return NotFound();
        }

        return Ok(updatedTask);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTask(int id)
    {
        var deleted = await _taskService.DeleteTask(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}