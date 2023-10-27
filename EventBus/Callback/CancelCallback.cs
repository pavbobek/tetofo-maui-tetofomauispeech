using tetofo.EventBus.Event;
using tetofo.EventBus.Impl;
using tetofo.Service;
using tetofo.Service.Impl;
using tetofo.ViewModel;

namespace tetofo.EventBus.Callback;

public class CancelCallback : BaseCallback
{

    private readonly ISpeechToTextService _speechToTextService;
    private readonly MainViewModel _mainViewModel;

    public CancelCallback(ISpeechToTextService speechToTextService, MainViewModel mainViewModel) : base(typeof(CancelEvent)) {
        _speechToTextService = speechToTextService;
        _mainViewModel = mainViewModel;
    }

    public override void Callback(IEvent iEvent) {
        _speechToTextService.Cancel();
        _mainViewModel.RecognitionText = "Offline: click Listen to start.";
    }
}