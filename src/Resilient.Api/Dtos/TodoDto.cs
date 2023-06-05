namespace Resilient.Api.Dtos;

public sealed class TodoDto
{
    public int UserId { get; set; }

    public int Id { get; set; }

    public string Title { get; set; }

    public bool Completed { get; set; }
}
