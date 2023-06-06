using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace Test;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCompatibility()
			.ConfigureMauiHandlers((handlers) =>
			{
#if ANDROID
				handlers.AddHandler(typeof(Test.Controls.BorderedEntry), typeof(Test.Platforms.Android.Renderers.BorderedEntryRenderer));
#endif
			});
			//.ConfigureFonts(fonts =>
			//{
			//	fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			//	fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			//});

//#if DEBUG
//		builder.Logging.AddDebug();
//#endif

		return builder.Build();
	}
}
