using System;
using System.IO;
using System.Media;


namespace chatBotAmo
{
    public class AudioPlayer
    {
        //creating the method to play the audio
        public void PlayAudio()
        {
            PlayVoiceGreeting();
        }
        private void PlayVoiceGreeting()
        {
            try
            {
                string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string mainDirectory = Directory.GetParent(projectDirectory).Parent.Parent.FullName;
                string fullPath = Path.Combine(mainDirectory, "VoiceGreeting.wav");

                Console.WriteLine($" {fullPath}");

                if (File.Exists(fullPath))
                {
                    using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(fullPath))
                    {
                        player.PlaySync();
                    }
                }
                else
                {
                    Console.WriteLine($"audio file not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
    