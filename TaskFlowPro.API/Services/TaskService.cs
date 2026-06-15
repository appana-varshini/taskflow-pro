using Microsoft.EntityFrameworkCore;
using TaskFlowPro.API.Data;
using TaskFlowPro.API.Models;

namespace TaskFlowPro.API.Services;

public class TaskService
{
    private readonly ApplicationDbContext _dbContext;

    public TaskService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TaskItem>> GetTasks()
    {
        return await _dbContext.Tasks.ToListAsync();
    }
    public async Task<TaskItem> CreateTask(TaskItem task)
    {
        _dbContext.Tasks.Add(task);

        await _dbContext.SaveChangesAsync();

        return task;
    }
    public async Task<TaskItem?> GetTaskById(int id)
    {
        return await _dbContext.Tasks
            .FirstOrDefaultAsync(t => t.Id == id);
    }
    public async Task<TaskItem?> UpdateTask(int id, TaskItem updatedTask)
    {
        var existingTask = await _dbContext.Tasks
            .FirstOrDefaultAsync(t => t.Id == id);

        if (existingTask == null)
        {
            return null;
        }

        existingTask.Title = updatedTask.Title;
        existingTask.Description = updatedTask.Description;
        existingTask.IsCompleted = updatedTask.IsCompleted;

        await _dbContext.SaveChangesAsync();

        return existingTask;
    }
    public async Task<bool> DeleteTask(int id)
    {
        var task = await _dbContext.Tasks
            .FirstOrDefaultAsync(t => t.Id == id);

        if (task == null)
        {
            return false;
        }

        _dbContext.Tasks.Remove(task);

        await _dbContext.SaveChangesAsync();

        return true;
    }
}