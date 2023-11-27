using System;
using Renci.SshNet;
using System.Collections.Generic;

namespace CreateConnection;

public static class SSHCommands
{
	public static string GetInfoFromText(Connection connection, string pathFile)
	{
		try
		{
            using (var client = new SshClient(connection.IP, connection.Login, connection.Password))
            {
				client.Connect();

				if (client.IsConnected)
				{
					using (var sshCommand = client.CreateCommand($"type {pathFile}"))
					{
						string result = sshCommand.Execute();
						return result;
					}
				}
				else
				{
					return "Connection error!";
				}
			}
		}
		catch (Exception ex)
		{
			return "Error occured!";
		}
	}


	public static void WriteTextIntoFile(Connection connection, string pathFile, string input)
	{
        try
		{
            using(var client = new SshClient(connection.IP, connection.Login, connection.Password))
            {
                client.Connect();

                if (client.IsConnected)
                {
                    using (var sshCommand = client.CreateCommand($"echo '{input}' > {pathFile}"))
                    {
                        sshCommand.Execute();
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
        }
		catch (Exception ex)
		{
			return;
		}
    }

	/*
	public static void WriteIDToBanList(Connection connection, string pathFile, input)
	{
		try
		{
            using (var client = new SshClient(connection.IP, connection.Login, connection.Password))
            {
				client.Connect();

				if (client.IsConnected)
				{
					using (var sshCommand = client.CreateCommand($"echo '{FilterScripts.PlayerId}' > {pathFile}"))
				}
				else
				{
					return;
				}
            }
        }
		catch (Exception ex)
		{
			return;
		}
	}
	*/


	/*
	using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
	using (BufferedStream bs = new BufferedStream(fs))
	using (StreamReader sr = new StreamReader(bs))
	{
		string line;
		while ((line = sr.ReadLine()) != null)
		{

		}
	}
	*/


	/*
	******************************************************************************
	AdminLog started on 2023-11-27 at 07:43:00
	08:09:04 | Player "Survivor" is connected (id=F3lztjrbuQqvwkJ-YK6khioXVSqiPmH4eMOdj4nHc84=)
	08:14:29 | Player "Survivor"(id=F3lztjrbuQqvwkJ-YK6khioXVSqiPmH4eMOdj4nHc84=) has been disconnected
	*/
	public static Dictionary<string, string> GetAllTimePlayers(Connection connection, string pathToAdminLogs)
	{
		// ...
		return new Dictionary<string, string>();
	}
}

