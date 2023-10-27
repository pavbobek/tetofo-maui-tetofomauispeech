using CommunityToolkit.Maui.Media;
using tetofo.DesignPattern;
using tetofo.DesignPattern.Impl;
using tetofo.EventBus;
using tetofo.EventBus.Callback;
using tetofo.EventBus.Impl;
using tetofo.Model;
using tetofo.Service;
using tetofo.Service.DAO;
using tetofo.Service.DAO.Impl;
using tetofo.Service.FileSerializer;
using tetofo.Service.FileSerializer.Impl;
using tetofo.Service.Impl;
using tetofo.View;
using tetofo.ViewModel;

namespace tetofo.Helper;

public static class Setups {
    public static void SetupUI(this IServiceCollection services) {
        services.AddSingleton<MainPage>();
		services.AddSingleton<MainViewModel>();
    }
    public static void SetupMediator(this IServiceCollection services) {
        //callbacks
        services.AddTransient<ICallback, CancelCallback>();
        services.AddTransient<ICallback, ListenCallback>();
        services.AddTransient<ICallback, SaveCallback>();
        services.AddTransient<ICallback, UpdateUICallback>();
        //bus
        services.AddTransient<IEventBus, MauiEventBus>();
    }

    public static void SetupService(this IServiceCollection services) {
        //speech to text
        services.AddSingleton<ISpeechToTextService, SpeechToTextService>();
        services.AddSingleton<ISpeechToText>(SpeechToText.Default);
        //dao
        services.AddTransient<IAsyncDAO<IData, IData>, FileDAO>();
        //tetofo
        services.AddTransient<IDataFactory, DataFactory>();
        services.AddTransient<IAsyncFileSerializer, JSONFileSerializer>();
    }
}