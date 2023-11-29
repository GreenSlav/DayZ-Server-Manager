using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string pathToLogFile = @"C:\Program Files (x86)\Steam\steamapps\common\DayZServer\Profilese\DayZServer_x64.ADM";
        string pathToFilteredLogFile = @"C:\Program Files (x86)\Steam\steamapps\common\DayZServer\filteredlogs.txt";

        while(true)
        {
            Dictionary<string, string> filteredDictionary = new Dictionary<string, string>();

            try
            {
                // creating a dictionary from a filtered logs
                using (FileStream fs = File.Open(pathToFilteredLogFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (BufferedStream bs = new BufferedStream(fs))
                using (StreamReader sr = new StreamReader(bs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(' ');
                        if (parts.Length >= 2)
                        {
                            string id = parts[0];
                            string nickname = parts[1];

                            filteredDictionary[id] = nickname;
                        }
                    }
                }

                // reading logs file and writing it into filtered dictionary
                using (FileStream fs = File.Open(pathToLogFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (BufferedStream bs = new BufferedStream(fs))
                using (StreamReader sr = new StreamReader(bs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string id = EjectPlayerID(line);
                        string nick = EjectPlayerNickname(line);

                        if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(nick))
                        {
                            filteredDictionary[id] = nick;
                        }
                    }
                }

                // writing dictionary into filtered.txt
                File.WriteAllText(pathToFilteredLogFile, string.Empty);
                using (StreamWriter sw = File.CreateText(pathToFilteredLogFile))
                {
                    foreach (var pair in filteredDictionary)
                    {
                        // Запись в файл в формате "key value"
                        sw.WriteLine($"{pair.Key} {pair.Value}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    public static string EjectPlayerID(string input)
    {
        string pattern = @"id=([^)]+)\)";

        Match match = Regex.Match(input, pattern);

        if (match.Success)
        {
            return match.Groups[1].Value;
        }
        else
        {
            return "";
        }
    }


    public static string EjectPlayerNickname(string input)
    {
        string pattern = "Player \"([^']+)\"";

        Match match = Regex.Match(input, pattern);

        if (match.Success)
        {
            return match.Groups[1].Value;
        }
        else
        {
            return "";
        }
    }
}
