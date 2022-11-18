namespace PhotonAuth.Models;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public bool IsDeleted { get; set; }
    public int Rank { get; set; }
    public DateTime LastSeen { get; set; } = DateTime.UtcNow;
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}