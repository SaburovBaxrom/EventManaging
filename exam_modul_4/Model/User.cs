namespace exam_modul_4.Model;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Username{ get; set; }
    public string Password { get; set; }
    public Extensions.Extensions.Role role { get; set; }
    public string CompanyName{ get; set; }

    public User(int id, string fullName = "", string username = "", string password="", Extensions.Extensions.Role role=0, string companyName = "")
    {
        Id = id;
        FullName = fullName;
        Username = username;
        Password = password;
        this.role = role;
        CompanyName = companyName;
    }
    public User()
    {

    }
}
