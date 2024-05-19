using Microsoft.Maui.Controls;
using System;

namespace MobyStory
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Layla_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StoryPage("wss"));
        }

        private void Arnab_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StoryPage("paf"));
        }

        private void Namla_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StoryPage("bab"));
        }
    }
}
