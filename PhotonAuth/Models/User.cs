namespace PhotonAuth.Models;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public bool IsDeleted { get; set; }
    public string RefreshToken { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime LastSeen { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}