using System.Text.Json;

namespace JobsServer.Services;

public class JobsService
{
    public List<Job> Jobs { get; private set; }
    
    private readonly string filePath;

    public JobsService(IWebHostEnvironment webHostEnvironment)
    {
        filePath = Path.Combine(webHostEnvironment.ContentRootPath, "Data", "jobs.json");
        
        var json = File.ReadAllText(filePath);
        Jobs = JsonSerializer.Deserialize<List<Job>>(json,new JsonSerializerOptions {PropertyNameCaseInsensitive = true})!;
    }

    public Job? GetJob(int id)
    {
        return Jobs.SingleOrDefault(j => j.Id == id);
    }

    public void AddJob(Job job)
    {
        Jobs.Add(job);
    }
}