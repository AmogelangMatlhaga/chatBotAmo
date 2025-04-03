
using System;
using System.Drawing;
using System.IO;
namespace chatBotAmo
{
    public class ImageDisplay
    {
        private readonly string fullPath;

        //creating a contructor
        public ImageDisplay()
        {
            //get the full path of the image
            string pathProject = AppDomain.CurrentDomain.BaseDirectory;
            //the replace the bin\\debug\\
            string newPathProject = pathProject.Replace("bin\\Debug\\", "");
            //combine the path with the image name
            fullPath = Path.Combine(newPathProject, "logo.png");
        }

        public void imageHandler()
        {
            try
            {
                //then start working on the logo with the ascii
                Bitmap logo = new Bitmap(fullPath);
                logo = new Bitmap(logo, new Size(50, 50));
                for (int height = 0; height < logo.Height; height++)
                {
                    for (int width = 0; width < logo.Width; width++)
                    {
                        Color pixelColor = logo.GetPixel(width, height);
                        int color = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        char ASCII_Design = color > 200 ? '.' : color > 150 ? '*' : color > 100 ? '0' : color > 50 ? '#' : '@';
                        Console.Write(ASCII_Design);
                    }
                    Console.WriteLine();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}