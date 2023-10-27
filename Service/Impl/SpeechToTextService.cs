using System.Globalization;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Media;
using Microsoft.Extensions.Logging;
using tetofo.DesignPattern;
using tetofo.EventBus;
using tetofo.EventBus.Event;
using tetofo.Model;

namespace tetofo.Service.Impl;

public class SpeechToTextService : ISpeechToTextService
{
    private CancellationTokenSource tokenSource = new CancellationTokenSource();
    private readonly IDataFactory _dataFactory;
    private readonly IEventBus _eventBus;
    private readonly ILogger<SpeechToTextService> _logger;
    private readonly ISpeechToText _speechToText;

    public SpeechToTextService(ILogger<SpeechToTextService> logger, IDataFactory dataFactory, IEventBus eventBus, ISpeechToText speechToText) {
        _dataFactory = dataFactory;
        _eventBus = eventBus;
        _logger = logger;
        _speechToText = speechToText;
    }

    public void Cancel()
    {
        tokenSource.Cancel();
    }

    public async Task Listen()
    {
        bool isGranted =  await _speechToText.RequestPermissions(tokenSource.Token);
        if (!isGranted)
        {
            _logger.LogError("Permission not granted");
            return;
        }
        tokenSource = new CancellationTokenSource();
        SpeechToTextResult speechToTextResult = await _speechToText.ListenAsync(
                                            CultureInfo.GetCultureInfo("en-us"),
                                             new Progress<string>(partialText => SendToken(partialText, _dataFactory, _eventBus, _logger)), tokenSource.Token);
        try {
            speechToTextResult.EnsureSuccess();
        } catch(Exception) {
            _logger.LogError("Listening ended.");
            return;
        }
        
    }

    private static void SendToken(string text, IDataFactory dataFactory, IEventBus eventBus, ILogger<SpeechToTextService> logger) {
        logger.LogInformation(text);
        eventBus.Event(new TokenEvent{
            Payload = dataFactory.Create((new HashSet<Tag>{Tag.STRING}, text, null))
        });
    }

}