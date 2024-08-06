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

    [HttpGet($"{{{nameof(id)}:int}}", Name = "GetSingleJob")]
    public IActionResult GetJob(int id)
    {
        var job = jobsService.GetJob(id);
        return job is not null ? Ok(job) : NotFound();
    }

    [HttpPost]
    public ActionResult<Job> AddJob(Job job)
    {
        var lastId = jobsService.Jobs.Max(j => j.Id);
        job.Id = ++lastId;
        jobsService.AddJob(job);
        return CreatedAtAction(nameof(GetJob), new { Id = job.Id }, job);
    }

    [HttpPut]
    public IActionResult UpdateJob(Job job, int id = 0)
    {
        jobsService.UpdateJob(job);
        return NoContent();
    }

    [HttpDelete]
    public IActionResult DeleteJob(int id)
    {
        jobsService.DeleteJob(id);
        return NoContent();
    }
    
}