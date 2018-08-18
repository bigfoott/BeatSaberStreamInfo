using ChatSharp;
using ChatSharp.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeatSaberStreamInfo.UI.Bot
{
    public partial class Bot : Form
    {
        private static string botName = "x";
        private static string channelName = "x";
        private static string oauth = "x";

        private StreamWriter _writer;
        private bool _retry;
        private bool _exit;

        private BeatSaver bs;

        private Thread BotThread;

        public Bot()
        {
            InitializeComponent();
        }

        private void Bot_Load(object sender, EventArgs e)
        {
            bs = new BeatSaver();
        }

        private void button_connect_Click(object sender, EventArgs ev)
        {
            BotThread = new Thread(Init);
            BotThread.Start();
        }

        private void button_disconnect_Click(object sender, EventArgs e)
        {

        }

        private void Log(string s)
        {
            if (log.Text != "")
                log.AppendText(Environment.NewLine + "[" + DateTime.Now.ToString("hh:mm:ss tt") + "] " + s);
            else
                log.AppendText("[" + DateTime.Now.ToString("hh:mm:ss tt") + "] " + s);
        }
        
        private void Init()
        {
            //_logger.Debug("Twitch bot starting...");
            var retryCount = 0;
            do
            {
                try
                {
                    using (var irc = new TcpClient("irc.chat.twitch.tv", 6667))
                    using (var stream = irc.GetStream())
                    using (var reader = new StreamReader(stream))
                    using (var writer = new StreamWriter(stream))
                    {
                        // Set a global Writer
                        _writer = writer;

                        // Login Information for the irc client
                        //_logger.Debug("Connection to twitch server established. Beginning Login.");
                        SendMessage("PASS " + oauth);
                        SendMessage("NICK " + botName);
                        SendMessage("JOIN #" + channelName);

                        // Adding Capabilities Requests so that we can parse Viewer information
                        SendMessage("CAP REQ :twitch.tv/membership");
                        SendMessage("CAP REQ :twitch.tv/commands");
                        SendMessage("CAP REQ :twitch.tv/tags");

                        //_logger.Debug("Login complete Beat bot online.");
                        //_logger.Debug(_config.Username);

                        string[] cmds = { "!search", "!nowplaying", "!np" };

                        while (!_exit)
                        {
                            string inputLine;
                            while ((inputLine = reader.ReadLine()) != null || _exit)
                            {
                                //_logger.Debug(inputLine);

                                if (inputLine == null) continue;

                                var splitInput = inputLine.Split(' ');
                                if (splitInput[0] == "PING")
                                {
                                    //_logger.Info("Responded to twitch ping.");
                                    SendMessage("PONG " + splitInput[1]);
                                }

                                splitInput = inputLine.Split(':');

                                if (2 >= splitInput.Length) continue;

                                var msg = splitInput[2];
                                if (cmds.Contains(msg.Split(' ')[0]))
                                    ProcessCommand(msg);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    //_logger.Debug(e.ToString());
                    _retry = ++retryCount <= 20;
                    if (_exit)
                    {
                        _retry = false;
                    }
                    else
                    {
                        Thread.Sleep(5000);
                    }
                }
            } while (_retry);
        }

        private void SendMessage(String message)
        {
            if (message.Contains("PASS") || message.Contains("NICK") || message.Contains("JOIN #") || message.Contains("CAP REQ") || message.Contains("PONG"))
            {
                _writer.WriteLine(message);
            }
            else
                _writer.WriteLine("PRIVMSG #" + channelName + " :" + message);

            _writer.Flush();
        }

        private void ProcessCommand(string msg)
        {
            Console.WriteLine(msg);
            string[] split = msg.Split(new[] { ' ' }, 2);
            string command = split[0];
            string args = "";
            if (split.Length == 2)
                args = split[1];
            if (command == "!search")
            {
                Console.WriteLine(args);
                if (args != "")
                {
                    Console.WriteLine("bepis");
                    var results = bs.Search(args);
                    string response = "";
                    Console.WriteLine(results.Count());
                    if (results.Count == 0)
                        response = $"🚫 No BeatSaver results for: \"" + args + "\"";
                    else
                    {
                        string s = "s";
                        if (results.Count == 1)
                            s = "";
                        string[] EmojiList = new[] { "1️⃣", "2️⃣", "3️⃣" };
                        response = $"✅ BeatSaver result" + s + " for: \"" + args + "\": " + EmojiList[0] + " " + results[0];
                        if (results.Count > 1)
                        {
                            for (int i = 1; i < results.Count(); i++)
                                response += " || " + EmojiList[i] + " " + results[i];
                        }
                    }
                    
                    Console.WriteLine(response);
                    SendMessage(response);
                }
            }
        }
    }
}
