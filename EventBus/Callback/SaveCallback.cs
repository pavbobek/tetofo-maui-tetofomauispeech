using Microsoft.Extensions.Logging;
using tetofo.EventBus.Event;
using tetofo.EventBus.Impl;
using tetofo.Model;
using tetofo.Service;
using tetofo.Service.DAO;
using tetofo.Service.DAO.Exception;
using tetofo.Service.Impl;
using tetofo.ViewModel;

namespace tetofo.EventBus.Callback;

public class SaveCallback : BaseCallback
{
    private readonly IAsyncDAO<IData, IData> _dao;
    private readonly ILogger<SaveCallback> _logger;

    public SaveCallback(IAsyncDAO<IData, IData> dao, ILogger<SaveCallback> logger) : base(typeof(TokenEvent)) {
        _dao = dao;
        _logger = logger;
    }

    public override async void Callback(IEvent iEvent) {
        if (iEvent.Payload?.Payload==null) {
            _logger.LogWarning("Trying to save empty token.");
            return;
        }
        try {
            await _dao.SaveAsync(iEvent.Payload);
        }
        catch(DAOException e) {
            _logger.LogError("Token was not saved.", e);
        }
    }
}