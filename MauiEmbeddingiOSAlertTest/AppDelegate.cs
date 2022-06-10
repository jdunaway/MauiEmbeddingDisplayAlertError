using Microsoft.Maui.Platform;
using Microsoft.Maui.Embedding;
using UIKit;
using Foundation;
using CommunityToolkit.Maui;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace MauiEmbeddingiOSAlertTest
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public static MauiContext MauiContext;

        public override UIWindow? Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // create a new window instance based on the screen size
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            // create a UIViewController with a single UILabel
            var vc = new UIViewController();
            vc.View!.AddSubview(new UILabel(Window!.Frame)
            {
                BackgroundColor = UIColor.SystemBackground,
                TextAlignment = UITextAlignment.Center,
                Text = "Hello, iOS!",
                AutoresizingMask = UIViewAutoresizing.All,
            });
            Window.RootViewController = vc;

            // make the window visible
            Window.MakeKeyAndVisible();

            ///Your normal iOS registration

            //Setup MauiBits
            var builder = MauiApp.CreateBuilder()                
                .UseMauiEmbedding<MauiApp1.App>()
                .UseMauiCommunityToolkit();
          

            //Using comet?
            //builder.UseComet();

            //iOS/Mac need to register the Window

            builder.Services.Add(new Microsoft.Extensions.DependencyInjection.ServiceDescriptor(typeof(UIKit.UIWindow), Window));

            var mauiApp = builder.Build();

            //Create and save a Maui Context. This is needed for creating Platform UI
            MauiContext = new MauiContext(mauiApp.Services);

            var mauiPage = new MauiApp1.MainPage();

            vc.View = mauiPage.ToPlatform(MauiContext);
            
            return true;
        }
    }
}