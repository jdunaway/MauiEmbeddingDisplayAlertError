using CommunityToolkit.Maui.Views;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            //DisplayAlert("Test", $"Hello World!", "Okay");
            //var popup = new Popup
            //{
            //    Content = new VerticalStackLayout
            //    {
            //        Children =
            //        {
            //            new Label
            //            {
            //                Text = "This is a very important message!"
            //            }
            //        }
            //    }
            //};

            //this.ShowPopup(popup);
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            //DisplayAlert("Test", $"Hello World!", "Okay");

            var popup = new SimplePopup();

            this.ShowPopup(popup);

            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}