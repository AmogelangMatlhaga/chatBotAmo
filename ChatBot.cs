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
        private object consoleLock = new object(); // Lock for thread-safe console output

        private string lastTopic = ""; // Stores the most recent topic discussed

        // Memory to store user inputs and check repeated topics
        private Dictionary<string, string> memory = new Dictionary<string, string>();
        private List<string> topicHistory = new List<string>(); // List to track topic history

        public ChatBot()
        {
            // Initialize helper classes
            audioHandler = new AudioPlayer();
            imageHandler = new ImageDisplay();
            questionManager = new QuestionManager();
        }

        // Entry point to start the chatbot
        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            ShowLoading(); // Show loading animation
            imageHandler.imageHandler(); // Display ASCII image

            audioHandler.PlayAudio(); // Play welcome audio
            WelcomeUser(); // Ask for and validate user's name
            ChatLoop(); // Begin main chat interaction loop
        }

        // Loading animation before chatbot starts
        private void ShowLoading(int seconds = 1)
        {
            Console.Write("Amo ChatBot is loading");
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(500); // Wait half a second per dot
            }
            Console.WriteLine();
        }

        // Welcomes user and validates name input
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

            // Store the name in memory dictionary
            memory["userName"] = name;

            // Display welcome message and chatbot instructions
            Console.WriteLine($"Hello {name}! Welcome to ChatBot! " +
                "I'm here to help you with cybersecurity questions. " +
                "You can ask about Phishing, Password Safety & Safe Browsing.");
            Console.WriteLine("Type 'exit' to quit the program ");
        }

        // Validates name (letters only, non-empty)
        private bool IsValidName(string input)
        {
            return !string.IsNullOrEmpty(input) && Regex.IsMatch(input, "^[A-Za-z]+$");
        }

        // Main loop where chatbot interacts with user
        private void ChatLoop()
        {
            string userName = memory["userName"]; // Retrieve user name from memory

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"\n{userName}: ");
                Console.ForegroundColor = ConsoleColor.White;
                string userInput = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Green;

                // Validate user input
                if (!IsValidInput(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Amo Bot: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("I didn't quite understand that. Please ask about Phishing, Password Safety, or Safe Browsing.");
                    continue;
                }

                // Exit the program
                if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Amo Bot: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nGoodbye {userName}! Stay safe online. Have a great day!");
                    break;
                }

                // Allow multiple questions separated by "and" or comma
                string[] questions = userInput.Split(new string[] { " and ", ", " }, StringSplitOptions.RemoveEmptyEntries);
                List<Task> tasks = new List<Task>();

                foreach (string question in questions)
                {
                    string trimmedQuestion = question.Trim();

                    // Check if the same question has already been asked
                    if (memory.ContainsKey(trimmedQuestion))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Amo Bot: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You've already asked about that earlier. Here's a quick reminder:");
                    }
                    else
                    {
                        memory[trimmedQuestion] = "asked"; // Mark as asked
                    }

                    // Run each question processing in a separate task
                    tasks.Add(Task.Run(() => ProcessQuestion(trimmedQuestion)));
                }

                Task.WhenAll(tasks).Wait(); // Wait for all question responses

                // Offer to continue talking about the last topic
                if (!string.IsNullOrEmpty(lastTopic))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Amo Bot: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Earlier, you asked about {lastTopic}, would you like to know more about {lastTopic}?");
                }

                Console.WriteLine("\nYou can also ask about Phishing, Password Safety, or Safe Browsing.");
            }
        }

        // Process a single question and generate a response
        private void ProcessQuestion(string question)
        {
            string response = questionManager.GetResponses(question); // Get response from manager
            SimulateTyping(response); // Simulate typing animation

            // Update last topic based on question keyword
            if (question.Contains("phishing"))
                lastTopic = "Phishing";
            else if (question.Contains("password"))
                lastTopic = "Password Safety";
            else if (question.Contains("browsing"))
                lastTopic = "Safe Browsing";

            // Track topic history to avoid redundancy
            if (!topicHistory.Contains(lastTopic))
            {
                topicHistory.Add(lastTopic);
            }
        }

        // Simulates the bot typing character-by-character
        private void SimulateTyping(string message)
        {
            lock (consoleLock) // Prevent console output clashes
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\nAmo Bot: ");
                Console.ForegroundColor = ConsoleColor.Green;

                foreach (char c in message)
                {
                    Console.Write(c);
                    Thread.Sleep(50); // Type delay
                }
                Console.WriteLine();
            }
        }

        // Checks if input is not null or empty
        private bool IsValidInput(string input)
        {
            return !string.IsNullOrEmpty(input);
        }
    }
}