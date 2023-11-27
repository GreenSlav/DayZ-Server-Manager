using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string logFilePath = "path to admins logs"; 
        string filteredLogFilePath = "path to new file with filtered logs"; 

        HashSet<string> uniqueEntries = new HashSet<string>(); 

        while (true)
        {
            try
            {
                using (FileStream fs = File.Open(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (BufferedStream bs = new BufferedStream(fs))
                using (StreamReader sr = new StreamReader(bs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(new[] { ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length >= 2)
                        {
                            string nickname = parts[0].Trim();
                            string playerId = parts[1].Trim();

                            string entry = $"{nickname} {playerId}";

                            if (!uniqueEntries.Contains(entry))
                            {
                                File.AppendAllText(filteredLogFilePath, entry + Environment.NewLine);
                                uniqueEntries.Add(entry);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured: " + ex.Message);
            }

            System.Threading.Thread.Sleep(5000);
        }
    }
}
