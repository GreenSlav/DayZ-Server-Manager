using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Renci.SshNet;

class Program
{
    static void Main()
    {

        string pathDayzADminLogFile = "...";
        
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
            return "Error occured!";
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
            return "Error occured!";
        }
    }
}
