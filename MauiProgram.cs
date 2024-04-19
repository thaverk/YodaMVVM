using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;
using YodaMVVM.Configuration;
using YodaMVVM.Services;
using YodaMVVM.Services.Interface;
using YodaMVVM.ViewModels;
using YodaMVVM.Views;

namespace YodaMVVM
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.RegisterServices();
            builder.RegisterViewModels();
            builder.RegisterViews();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }


        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient< IYodaAI,YodaAI>();
            mauiAppBuilder.Services.AddTransient<ISettings, Settings>();
            return mauiAppBuilder;
        }
        
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<FactPageViewModel>();
            return mauiAppBuilder;
        }
        
        public static MauiAppBuilder RegisterViews (this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<FactPage>();
           
            return mauiAppBuilder;
        }
    }
}
