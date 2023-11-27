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
        string pattern = "is connected (id=([^']+))";
        string altPattern = "(id=([^']+)) has been disconnected";

        Match match = Regex.Match(input, pattern);
        Match altMatch = Regex.Match(input, altPattern);

        if (match.Success || altMatch.Success)
        {
            return (match.Success) ? match.Groups[1].Value : altMatch.Groups[1].Value;
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