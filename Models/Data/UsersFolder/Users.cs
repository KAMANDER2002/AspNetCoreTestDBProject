namespace CompMarketReal.Models.Data.UsersFolder
{
    public class Users
    {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    public string? age { get; set; }
    public string? Regions { get; set; }
    public string? Email { get; set;  }
    public string? Image { get; set; }
    public string? Phone { get; set; }
    public virtual Role? Role { get; set; }  
    }
}
