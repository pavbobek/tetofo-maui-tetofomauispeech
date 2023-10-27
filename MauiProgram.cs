using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using tetofo.Helper;

namespace tetofomauispeech;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.SetupService();
		builder.Services.SetupMediator();
		builder.Services.SetupUI();
		return builder.Build();
	}
}
