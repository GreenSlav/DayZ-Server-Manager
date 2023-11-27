using System;
namespace FilterScripts;

public class Player
{
	public string ID { get; set; }
	public string Nickname { get; set; }

	public Player(string id, string nickname)
	{
		ID = id;
		Nickname = nickname;
	}
}

