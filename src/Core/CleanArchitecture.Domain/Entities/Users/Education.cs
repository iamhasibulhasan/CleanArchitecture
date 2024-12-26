using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities.Users;

public sealed class Education : BaseEntity
{
    public int UserId { get; private set; }
    public string Degree { get; private set; }
    public string FieldOfStudy { get; private set; }
    public string InstitutionName { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public string Grade { get; private set; }
    public string Description { get; private set; }

    public User User { get; set; }


    public static Education Create(User user, string degree, string fieldOfStudy, string institutionName, DateTime startDate, DateTime? enddate, string grade, string description)
    {
        Education education = new();
        education.UserId = user.Id;
        education.Degree = degree;
        education.FieldOfStudy = fieldOfStudy;
        education.InstitutionName = institutionName;
        education.StartDate = startDate;
        education.EndDate = enddate;
        education.Grade = grade;
        education.Description = description;

        return education;
    }

    public void Update(string degree, string fieldOfStudy, string institutionName, DateTime startDate, DateTime? enddate, string grade, string description)
    {
        Degree = degree;
        FieldOfStudy = fieldOfStudy;
        InstitutionName = institutionName;
        StartDate = startDate;
        EndDate = enddate;
        Grade = grade;
        Description = description;
    }
}
