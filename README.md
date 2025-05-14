# chatBotAmo

*ChatBotAmo - Cybersecurity Chatbot*

# Description

*ChatBotAmo is a simple console-based chatbot designed to educate users about cybersecurity. It can answer questions about phishing, password safety, and safe browsing.*

# Features

* Interactive console chatbot
* Audio greeting
* Displays ASCII art of the logo
* Provides cybersecurity advice
* Supports multi-threaded response handling
* **Keyword Recognition**: Identifies specific cybersecurity terms like “password,” “scam,” and “privacy” to offer targeted advice.
* **Randomized Responses**: Delivers varied answers using arrays/lists to keep the conversation engaging.
* **Conversation Flow**: Maintains context in follow-up questions, especially on cybersecurity topics.
* **Memory and Recall**: Remembers user details (like name or favorite topic) for personalized responses.
* **Sentiment Detection**: Adjusts responses based on detected user emotions such as worry or confusion.
* **Error Handling and Edge Cases**: Provides fallback responses for unrecognized inputs without crashing.
* **Code Optimization**: Implements efficient structures like dictionaries and modular code for maintainability.

# Installation

* Clone the repository or download the files.
* Ensure you have .NET installed on your system.
* Compile and run the program using:

```bash
dotnet run
```

# Usage

* Run the application.
* Enter your name when prompted.
* Ask questions about cybersecurity (e.g., "What is phishing?").
* Type 'exit' to quit the chatbot.

# File Structure

* Program.cs: Entry point
* ChatBot.cs: Core chatbot logic
* AudioPlayer.cs: Handles audio playback
* ImageDisplay.cs: Displays an ASCII logo
* QuestionManager.cs: Manages predefined responses

# Future Improvements

* Add a GUI version
* Implement a machine-learning response system

# License

*MIT License*

