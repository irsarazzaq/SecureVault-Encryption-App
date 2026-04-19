using System;
using System.IO;

namespace SecureVault
{
    public class DatabaseService
    {
        private string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "history.txt");

        public DatabaseService()
        {
            if (!File.Exists(logPath))
            {
                File.WriteAllText(logPath, ""); // Khali file banayein
            }
        }

        public void SaveRecord(string op, string algo, string path)
        {
            try
            {
                string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm} | {op} | {algo} | {Path.GetFileName(path)}";
                File.AppendAllLines(logPath, new[] { entry });

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n[✔] History updated successfully.");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[X] Log Error: " + ex.Message);
                Console.ResetColor();
            }
        }

        public void ShowHistory()
        {
            Console.Clear();
            PrintHeader("USER ACTIVITY HISTORY");

            if (File.Exists(logPath))
            {
                string[] lines = File.ReadAllLines(logPath);

                // Table Header
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0,-18} | {1,-10} | {2,-10} | {3,-20}", "Date/Time", "Action", "Method", "File Name");
                Console.WriteLine(new string('-', 75));
                Console.ResetColor();

                if (lines.Length == 0)
                {
                    Console.WriteLine("No records found yet.");
                }

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        Console.WriteLine("{0,-18} | {1,-10} | {2,-10} | {3,-20}",
                            parts[0].Trim(), parts[1].Trim(), parts[2].Trim(), parts[3].Trim());
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n" + new string('=', 75));
            Console.ResetColor();
        }

        private void PrintHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===========================================================================");
            Console.WriteLine("      " + title);
            Console.WriteLine("===========================================================================\n");
            Console.ResetColor();
        }
    }
}