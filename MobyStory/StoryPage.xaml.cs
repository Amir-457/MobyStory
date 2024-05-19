using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using System.IO;
using Plugin.Maui.Audio;

namespace MobyStory
{
    public partial class StoryPage : ContentPage
    {
        private int currentPage = 1;
        private int maxPages;
        private string storyName;
        private bool isToggled = false;
        

        public StoryPage(string storyName)
        {
            InitializeComponent();
            this.storyName = storyName;
            maxPages = GetMaxPages(storyName);
            UpdatePage();
        }

        private void UpdatePage()
        {
            pageNumberLabel.Text = $"الصفحة {currentPage}";
            storyImage.Source = ImageSource.FromFile($"C:\\Users\\User\\source\\repos\\MobyStory\\MobyStory\\Resources\\Images\\{storyName}\\{storyName}_{currentPage}.jpg");
            previousButton.IsEnabled = currentPage > 1;
            nextButton.IsEnabled = currentPage < maxPages;
            
            string audioFilePath = $"C:\\Users\\User\\source\\repos\\MobyStory\\MobyStory\\Resources\\Raw\\{storyName}_{currentPage}.mp3";
            ME.Source = audioFilePath;
           
            
            if (File.Exists(audioFilePath))
            {
                
                if (isToggled)
                {
                    ME.Play();
                }
            }
            else
            {
                Console.WriteLine("Audio file does not exist");
            }
        }

        private void ToggleButton_Clicked(object sender, EventArgs e)
        {
                isToggled = !isToggled;

                if (isToggled)
                {
                    ((Button)sender).BackgroundColor = Colors.Green;
                    ME.Play();
                }
                else
                {
                    ((Button)sender).BackgroundColor = Colors.Red;
                    ME.Stop();
                }
           

        }

        private int GetMaxPages(string storyName)
        {
            return storyName switch
            {
                "wss" => 17,
                "paf" => 26,
                "bab" => 8,
                _ => 0,
            };
        }

        private void PreviousButton_Clicked(object sender, EventArgs e)
        {
            isToggled = false;
            toggleButton.BackgroundColor = Colors.Red;
            if (currentPage > 1)
            {
                currentPage--;
                UpdatePage();
            }
        }

        private void HomeButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            isToggled = false;
            toggleButton.BackgroundColor = Colors.Red;
            if (currentPage < maxPages)
            {
                currentPage++;
                UpdatePage();
            }
        }
    }
}