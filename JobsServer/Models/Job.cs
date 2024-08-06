namespace JobsServer.Services;

public class Job
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Salary { get; set; }
    public Company Company { get; set; }
}