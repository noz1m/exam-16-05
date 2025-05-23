namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public DateTime RegistrationDate { get; set; }
}
