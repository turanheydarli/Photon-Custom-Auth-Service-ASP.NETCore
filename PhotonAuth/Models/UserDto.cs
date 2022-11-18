namespace PhotonAuth.Models;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public bool IsDeleted { get; set; }
    public int Rank { get; set; }
}