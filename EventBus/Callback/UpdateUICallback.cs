using tetofo.EventBus.Event;
using tetofo.EventBus.Impl;
using tetofo.Service;
using tetofo.Service.Impl;
using tetofo.ViewModel;

namespace tetofo.EventBus.Callback;

public class UpdateUICallback : BaseCallback
{

    public readonly MainViewModel _mainViewModel;

    public UpdateUICallback(MainViewModel mainViewModel) : base(typeof(TokenEvent)) {
        _mainViewModel = mainViewModel;
    }

    public override void Callback(IEvent iEvent) => _mainViewModel.RecognitionText = iEvent?.Payload?.Payload??"";
}