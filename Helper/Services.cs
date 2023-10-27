namespace tetofo.Helper;

public static class Services {
        public static TService GetService<TService>()
        => Current.GetService<TService>();
        public static IEnumerable<TService> GetServices<TService>() => Current.GetServices<TService>();

    public static IServiceProvider Current
        =>
#if WINDOWS
			MauiWinUIApplication.Current.Services;
#elif ANDROID
            MauiApplication.Current.Services;
#elif IOS || MACCATALYST
			MauiUIApplicationDelegate.Current.Services;
#else
			null;
#endif
}