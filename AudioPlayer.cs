using System;
using System.IO;
using System.Media;

namespace chatBotAmo
{
    // Class responsible for handling audio playback
    public class AudioPlayer
    {
        // Public method to start the audio playback process
        public void PlayAudio()
        {
            // Calls the private method that plays the voice greeting audio
            PlayVoiceGreeting();
        }

        // Private method to play a specific greeting audio file
        private void PlayVoiceGreeting()
        {
            try
            {
                // Get the base directory where the application is running
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // Navigate up three levels to reach the main project directory
                string mainDirectory = Directory.GetParent(projectDirectory).Parent.Parent.FullName;

                // Combine the main directory with the audio file name to get the full path
                string fullPath = Path.Combine(mainDirectory, "VoiceGreeting.wav");

                // Print the full path to the console (useful for debugging)
                Console.WriteLine($" {fullPath}");

                // Check if the audio file exists at the specified location
                if (File.Exists(fullPath))
                {
                    // Use a SoundPlayer to play the audio file synchronously (waits until done)
                    using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(fullPath))
                    {
                        player.PlaySync();
                    }
                }
                else
                {
                    // Display error if the file was not found
                    Console.WriteLine($"audio file not found");
                }
            }
            catch (Exception ex)
            {
                // Display any errors that occur during the file lookup or playback
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
