using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using tetofo.EventBus;
using tetofo.EventBus.Event;

namespace tetofo.ViewModel;

public partial class MainViewModel : ObservableObject {

    private readonly IEventBus _eventBus;
    [ObservableProperty]
    private string recognitionText = "Offline: click Listen to start.";

    public MainViewModel(IEventBus eventBus) {
        _eventBus = eventBus;
    }

    [RelayCommand]
    public void Listen() => _eventBus.Event(new ListenEvent());
    [RelayCommand]
    public void ListenCancel() => _eventBus.Event(new CancelEvent());

}