namespace CleanArchitecture.Application.Features.Education.Queries.Dtos;

public sealed class GetByIdEducationDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Degree { get; set; }
    public string FieldOfStudy { get; set; }
    public string InstitutionName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Grade { get; set; }
    public string Description { get; set; }
    public int StatusId { get; set; }
}
