using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities.Users;


public sealed class User : BaseEntity
{
    public string UserCode { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    public static User Create(string userCode, string firstName, string lastName, DateTime dateOfBirth, string email, string phone)
    {
        User user = new User();
        user.UserCode = userCode;
        user.FirstName = firstName;
        user.LastName = lastName;
        user.DateOfBirth = dateOfBirth;
        user.Email = email;
        user.Phone = phone;
        return user;
    }

    public void Update(string userCode, string firstName, string lastName, DateTime dateOfBirth, string email, string phone)
    {
        UserCode = userCode;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Email = email;
        Phone = phone;
    }
}

