namespace CleanArchitecture.Application.Features.Education.Command.Dtos;

public sealed class CreateEducationDto
{
    public int UserId { get; set; }
    public string Degree { get; set; }
    public string FieldOfStudy { get; set; }
    public string InstitutionName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Grade { get; set; }
    public string Description { get; set; }
}
