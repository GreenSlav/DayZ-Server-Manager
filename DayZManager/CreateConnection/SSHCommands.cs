using System;
using Renci.SshNet;
using System.Collections.Generic;
using CustomExceptions;

namespace CreateConnection;

public static class SSHCommands
{
	// neccessary script to create filtered logs on ypur server (run only once)
	public static void CreateFilteredTextFile(Connection connection, string pathDayZServer = @"C:\Program Files (x86)\Steam\steamapps\common\DayZServer")
	{
		using (var client = new SshClient(connection.IP, connection.Login, connection.Password))
		{
			pathDayZServer = @"" + pathDayZServer;
			try
			{
				client.Connect();

				if (client.IsConnected)
				{
                    string command = $"test -f {pathDayZServer + @"\filtered-logs.txt"} && echo 'File exists' || echo 'File not found'";
					var cmd = client.RunCommand(command);
					string result = cmd.Result.Trim();
                    if (result == "File not found")
                    {
						using (var sshCommand = client.CreateCommand($"type nul > {pathDayZServer + @"\filtered-logs.txt"}"))
						{
							sshCommand.Execute();
							return;
						}
                    }
					return;
                }
                else
				{
					throw new CustomEx("Failed to connect to client!");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}


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
					throw new CustomEx("Connection error");
				}
			}
		}
		catch (Exception ex)
		{
			throw new CustomEx(ex.Message);
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
					throw new CustomEx("Failed to connect!");
                }
            }
        }
		catch (Exception ex)
		{
			throw new CustomEx(ex.Message);
		}
    }

	
	public static Dictionary<string, string> GetAllTimePlayers(Connection connection, string pathToAdminLogs)
	{
		// ...
		return new Dictionary<string, string>();
	}
}

