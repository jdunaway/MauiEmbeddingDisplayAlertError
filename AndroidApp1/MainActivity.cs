using Android.App;
using Android.OS;
using Microsoft.Maui.Platform;
using Microsoft.Maui.Embedding;

namespace AndroidApp1
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public static MauiContext MauiContext;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Setup MauiBits
            var builder = MauiApp.CreateBuilder();              

            //Add Maui Controls
            builder.UseMauiEmbedding<MauiApp1.App>();

            //Using comet?
            //builder.UseComet();

            var mauiApp = builder.Build();

            //Create and save a Maui Context. This is needed for creating Platform UI
            MauiContext = new MauiContext(mauiApp.Services, this);

            //Create a Maui Page
            var myMauiPage = new MauiApp1.MainPage();

            //Turn the Maui page into an Android View
            var view = myMauiPage.ToPlatform(MauiContext);            

            //Use the Android View
            SetContentView(view);
        }
    }
}