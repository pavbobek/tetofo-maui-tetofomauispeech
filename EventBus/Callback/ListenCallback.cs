using tetofo.EventBus.Event;
using tetofo.EventBus.Impl;
using tetofo.Service;
using tetofo.Service.Impl;
using tetofo.ViewModel;

namespace tetofo.EventBus.Callback;

public class ListenCallback : BaseCallback
{

    private readonly ISpeechToTextService _speechToTextService;
    private readonly MainViewModel _mainViewModel;

    public ListenCallback(ISpeechToTextService speechToTextService, MainViewModel mainViewModel) : base(typeof(ListenEvent)) {
        _speechToTextService = speechToTextService;
        _mainViewModel = mainViewModel;
    }

    public override void Callback(IEvent iEvent) {
        _speechToTextService.Listen();
        _mainViewModel.RecognitionText = "Online: Say something to me.";
    }
}