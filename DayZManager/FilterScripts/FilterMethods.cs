using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FilterScripts;

public static class FilterMethods
{
    public static string GetUserIdFromString(string text)
    {
        int index = text.IndexOf("id");

        return text.Substring(index, 44);
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

    public static string EjectSteamID(string input)
    {
        string pattern = @"steamID=(\d+)";

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