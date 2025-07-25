using CommunityToolkit.Maui;
using Maui.FreakyControls.Extensions;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using Material.Components.Maui.Extensions;

namespace BahanaLautan
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
            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("materialicons.ttf", "MaterialIcons");
            });
            builder.ConfigureSyncfusionCore();
            builder.UseMaterialComponents();
            builder.InitializeFreakyControls(useSkiaSharp: true, useFreakyEffects: true);
            try
            {
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzUyMTk5OEAzMjM3MmUzMDJlMzBidlpmaDZSOXRaVlg3MWRMOUlZdXRIZXd3OS92VTNIN3plOFZDNFUxeFRzPQ==");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"License registration failed: {ex.Message}");
            }

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
