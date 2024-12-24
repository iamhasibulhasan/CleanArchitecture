namespace CleanArchitecture.Application.Features.Users.Queries.Dtos;

public sealed class GetAllUserDto
{
    public int Id { get; set; }
    public string UserCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
