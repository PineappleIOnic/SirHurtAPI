﻿using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SirHurtAPI
{
    public class SirHurtAPI
    {
        private static bool Injected = false;
        private static bool firstLaunch = true;
        private readonly static string DllName = "[SirHurtAPI]";

        [DllImport("SirHurtInjector.dll")]
        private static extern int Inject();
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr FindWindowA(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        private static uint _injectionResult;
        public static bool DownloadDll()
        {
            bool returnval;
            if (!File.Exists("SirHurtInjector.dll"))
            {
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile("https://asshurthosting.pw/asshurt/update/v4/SirHurtInjector.dll", "SirHurtInjector.dll");
                        Console.WriteLine(DllName + "Downloaded SirHurtInjector.dll");
                    } // Code from SirHurt Bootstrapper.
                    returnval = true;
                }
                catch (Exception ex)
                {
                    string reason;
                    if (ex.ToString().Contains("Timed out"))
                    {
                        reason = "Connection timed out.";
                    }
                    else
                    {
                        reason = "Unknown, please give log and create a issue in SirHurtAPI Github.";
                    }
                    Console.WriteLine(DllName + "Couldn't download SirHurtInjector.dll, " + "Reason: " + reason + "\nLog:\n" + ex.ToString());
                    returnval = false;
                }
            }
            else
                returnval = true;
            if (File.Exists("sirh.dat"))
            {
                if (File.Exists(File.ReadAllText("sirh.dat")))
                {
                    File.Delete(File.ReadAllText("sirh.dat"));
                }
                File.Delete("sirh.dat");
            }
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile("https://asshurthosting.pw/asshurt/update/v4/SirHurt.dll", "SirHurt.dll");
                    Console.WriteLine(DllName + "Downloaded SirHurt.dll");
                } // Code from SirHurt Bootstrapper.
                returnval = true;
            }
            catch (Exception ex)
            {
                string reason;
                if (ex.ToString().Contains("Timed out"))
                {
                    reason = "Connection timed out.";
                }
                else
                {
                    reason = "Unknown, please give log.";
                }
                Console.WriteLine(DllName + "Couldn't download SirHurt.dll, " + "Reason: " + reason + "\nLog:\n" + ex.ToString());
                returnval = false;
            }
            return returnval;
        }
        public static bool LaunchExploit() //Why LaunchExploit? because some ppl are used to make exploit using weareretarded api so yea.
        {
            bool returnval;
            if (!Injected)
            {
                returnval = DownloadDll();
                IntPtr intPtr = FindWindowA("WINDOWSCLIENT", "Roblox");
                if (Injected || intPtr == IntPtr.Zero)
                {
                    return true;
                }
                int num = 0;
                try
                {
                    num = Inject();
                    returnval = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DllName+string.Format("An error occured with injecting SirHurt: %s"+ ex.Message));
                    returnval = false;
                    return false;
                }
                if (num != 0)
                {
                    Console.WriteLine(DllName + "Sucessfully injected SirHurt V4.");
                    Injected = true;
                    returnval = true;
                }
                GetWindowThreadProcessId(intPtr, out _injectionResult);
                Injected = true;
                returnval = true;
                if (firstLaunch)
                {
                    injectionCheckerThreadHandler();
                    firstLaunch = false;
                }
            }
            else
                returnval = true;
            return returnval;
        }

        private static void injectionCheckerThreadHandler()
        {
            for (; ; )
            {
                Application.DoEvents();
                Thread.Sleep(100);
                IntPtr intPtr = FindWindowA("WINDOWSCLIENT", "Roblox");
                uint num = 0U;
                GetWindowThreadProcessId(intPtr, out num);
                if ((intPtr == IntPtr.Zero && Injected) || (_injectionResult != 0U && num != _injectionResult))
                {
                    Execute("");
                    Injected = false;
                }
            }
        }

        public static bool Execute(string script)
        {
            if (Injected)
            {
                try
                {
                    File.WriteAllText("sirhurt.dat", script);
                    Console.WriteLine(DllName + "Sucessfully write to sirhurt.dat");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DllName + "Cannot write to sirhurt.dat: " + ex);
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public static bool ExecuteFromFile() //@am ikea#1337 as you wish :|
        {
            var FileDg = new OpenFileDialog();
            FileDg.Filter = "txt (*.txt)|*.txt|lua (*.lua)|*.lua|All files (*.*)|*.*";
            FileDg.InitialDirectory = Environment.CurrentDirectory;
            FileDg.Title = "SirHurtAPI File Executor";
            if (FileDg.ShowDialog() == DialogResult.OK)
            {
                string file;
                try
                {
                    using (StreamReader reader = new StreamReader(FileDg.OpenFile()))
                    {
                        file = reader.ReadToEnd();
                    }
                    Console.WriteLine(DllName + "Sucessfully read " + Path.GetFullPath(FileDg.FileName));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(DllName+"Failed to read file.\nLog:", ex);
                    return false;
                }
                if (Execute(file))
                    return true;
                else
                    return false;
            }
            return true;
        }
    }
}
