using JobsServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobsServer.Controllers;

[ApiController]
[Route("[controller]")]
public class JobsController(JobsService jobsService) : ControllerBase
{
    [HttpGet]
    public List<Job> GetJobs()
    {
        return jobsService.Jobs;
    }

    [HttpGet($"{{{nameof(id)}:int}}")]
    public Job? GetJob(int id)
    {
        return jobsService.GetJob(id);
    }
    
}