using System;
using System.Drawing;
using System.IO;

namespace chatBotAmo
{
    // Class responsible for loading and displaying an image as ASCII art in the console
    public class ImageDisplay
    {
        private readonly string fullPath;

        // Constructor initializes the full path to the image file
        public ImageDisplay()
        {
            // Get the base directory of the application (usually ends in bin\Debug\)
            string pathProject = AppDomain.CurrentDomain.BaseDirectory;

            // Remove the bin\Debug\ part to get the project root directory
            string newPathProject = pathProject.Replace("bin\\Debug\\", "");

            // Combine the root path with the image file name to get the full path
            fullPath = Path.Combine(newPathProject, "logo.png");
        }

        // Method to handle loading and displaying the image as ASCII characters
        public void imageHandler()
        {
            try
            {
                // Load the image file from the specified path
                Bitmap logo = new Bitmap(fullPath);

                // Resize the image to 200x200 pixels for better console fit
                logo = new Bitmap(logo, new Size(110, 100));

                // Loop through each pixel row
                for (int height = 0; height < logo.Height; height++)
                {
                    // Loop through each pixel column
                    for (int width = 0; width < logo.Width; width++)
                    {
                        // Get the color of the current pixel
                        Color pixelColor = logo.GetPixel(width, height);

                        // Calculate the brightness (grayscale) of the pixel
                        int color = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                        // Map the grayscale value to an ASCII character
                        char ASCII_Design = color > 200 ? '.' :
                                            color > 150 ? '*' :
                                            color > 100 ? '0' :
                                            color > 50 ? '#' : '@';

                        // Display the character in the console
                        Console.Write(ASCII_Design);
                    }

                    // Move to the next line after finishing a row
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during image loading or processing
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}