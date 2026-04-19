using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using SecureVault.Core;
using SecureVault.Algorithms;

namespace SecureVault
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DatabaseService db = new DatabaseService();
            RunApp(db);
        }

        static void RunApp(DatabaseService db)
        {
            while (true)
            {
                Console.Clear();
                PrintBlueHeader("SECURE VAULT v1.0 - MAIN MENU");

                Console.WriteLine("1. Encrypt File");
                Console.WriteLine("2. Decrypt File");
                Console.WriteLine("3. View History");
                Console.WriteLine("4. Exit");

                Console.Write("\nChoose action: ");
                int choice = ReadInt();

                if (choice == 4) break;

                if (choice == 3)
                {
                    db.ShowHistory();
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey();
                    continue;
                }

                // Algorithm Selection Screen
                Console.Clear();
                PrintBlueHeader("SELECT ENCRYPTION ALGORITHM");
                string[] algos = { "Caesar", "Vigenere", "Base64", "AES", "RSA", "DES" };
                for (int i = 0; i < algos.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + algos[i]);
                }

                Console.Write("\nEnter choice: ");
                int algoIdx = ReadInt();
                if (algoIdx < 1 || algoIdx > 6) continue;

                ICipher cipher = GetCipher(algoIdx);

                string key = "";
                if (algoIdx != 3 && algoIdx != 5)
                {
                    Console.Write("\nEnter security key: ");
                    key = Console.ReadLine();
                }

                Console.Clear();
                PrintBlueHeader("FILE SELECTION");
                Console.WriteLine("Opening File Explorer...");
                string inputPath = FileDialogHelper.SelectFile();

                if (string.IsNullOrEmpty(inputPath))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[X] Error: No file selected!");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    continue;
                }

                try
                {
                    ShowLoading("Processing Data");
                    byte[] data = File.ReadAllBytes(inputPath);
                    byte[] result = (choice == 1) ? cipher.Encrypt(data, key) : cipher.Decrypt(data, key);

                    Console.Write("\nSave as (filename only): ");
                    string name = Console.ReadLine();

                    Console.WriteLine("Choose folder to save...");
                    string savePath = FileDialogHelper.SaveFile();

                    if (!string.IsNullOrEmpty(savePath))
                    {
                        string dir = Path.GetDirectoryName(savePath);
                        string ext = Path.GetExtension(savePath);
                        string finalPath = Path.Combine(dir, name + ext);

                        File.WriteAllBytes(finalPath, result);

                        // Database/Log record
                        db.SaveRecord(choice == 1 ? "Encrypt" : "Decrypt", algos[algoIdx - 1], finalPath);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n[✔] SUCCESS: File processed and secured.");
                        Console.ResetColor();
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[ERROR]: " + ex.Message);
                    Console.ResetColor();
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static int ReadInt()
        {
            int val;
            while (!int.TryParse(Console.ReadLine(), out val))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid! Enter a number: ");
                Console.ResetColor();
            }
            return val;
        }

        static ICipher GetCipher(int choice)
        {
            switch (choice)
            {
                case 1: return new CaesarCipher();
                case 2: return new VigenereCipher();
                case 3: return new Base64Cipher();
                case 4: return new AesCipher();
                case 5: return new RsaCipher();
                case 6: return new DesCipher();
                default: throw new Exception("Invalid algorithm selection.");
            }
        }

        static void PrintBlueHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===============================");
            Console.WriteLine("      " + title);
            Console.WriteLine("===============================\n");
            Console.ResetColor();
        }

        static void ShowLoading(string msg)
        {
            Console.Write(msg);
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }
            Console.WriteLine();
        }
    }
}