using System;
namespace CreateConnection;

public class Connection
{
	public string IP { get; set; }
	public string Login { get; set; }
	public string Password { get; set; }

	public Connection(string ip, string login, string password)
	{
		IP = ip;
		Login = login;
		Password = password;
	}
}

