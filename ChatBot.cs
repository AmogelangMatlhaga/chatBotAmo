using System;
using System.Collections.Generic;
using System.Media;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace chatBotAmo
{
    public class ChatBot
    {
        private string name;
        private AudioPlayer audioHandler;
        private ImageDisplay imageHandler;
        private QuestionManager questionManager;
        private object consoleLock = new object();

        public ChatBot()
        {
            audioHandler = new AudioPlayer();
            imageHandler = new ImageDisplay();
            questionManager = new QuestionManager();
        }

        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            ShowLoading();
            imageHandler.imageHandler();

            // Calls the new method in AudioPlayer
            audioHandler.PlayAudio();
            WelcomeUser();
            ChatLoop();
        }

        private void ShowLoading(int seconds = 1)
        {
            Console.Write("ChatBot is loading");
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            Console.WriteLine();
        }

        private void WelcomeUser()
        {
            do
            {
                Console.Write("\nEnter your name: ");
                Console.ForegroundColor = ConsoleColor.White;
                name = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;

                if (!IsValidName(name))
                {
                    Console.WriteLine("Invalid input! Please enter letters only.");
                }
            }
            while (!IsValidName(name));

            Console.WriteLine($"Hello {name}! Welcome to ChatBot! " +
                "I'm here to help you with cybersecurity questions. " +
                "You can ask about Phishing, Password Safety & Safe Browsing.");
            Console.WriteLine("Type 'exit' to quit the program ");
        }

        private bool IsValidName(string input)
        {
            return !string.IsNullOrEmpty(input) && Regex.IsMatch(input, "^[A-Za-z]+$");
        }

        private void ChatLoop()
        {
            while (true)
            {
                Console.Write("\nUser: ");
                Console.ForegroundColor = ConsoleColor.White;
                string userInput = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Green;

                if (!IsValidInput(userInput))
                {
                    Console.WriteLine("\nBot: I didn't quite understand that. Please ask about Phishing, Password Safety, or Safe Browsing.");
                    continue;
                }

                if (userInput == "exit" || userInput == "exit")
                {
                    Console.WriteLine("\nBot: Goodbye! Stay safe online. Have a great day!");
                    break;
                }

                string[] questions = userInput.Split(new string[] { " and ", ", " }, StringSplitOptions.RemoveEmptyEntries);
                List<Task> tasks = new List<Task>();

                foreach (string question in questions)
                {
                    string trimmedQuestion = question.Trim();
                    tasks.Add(Task.Run(() => ProcessQuestion(trimmedQuestion)));
                }

                Task.WhenAll(tasks).Wait();
                Console.WriteLine("\nYou can also ask about Phishing, Password Safety, or Safe Browsing.");
            }
        }

        private void ProcessQuestion(string question)
        {
            string response = questionManager.GetResponses(question);
            SimulateTyping(response);
        }

        private void SimulateTyping(string message)
        {
            lock (consoleLock)
            {
                Console.Write("\nBot: ");
                foreach (char c in message)
                {
                    Console.Write(c);
                    Thread.Sleep(50);
                }
                Console.WriteLine();
            }
        }

        private bool IsValidInput(string input)
        {
            return !string.IsNullOrEmpty(input);
        }
    }
}
