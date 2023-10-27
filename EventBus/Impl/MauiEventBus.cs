using Microsoft.Extensions.Logging;

namespace tetofo.EventBus.Impl;

public class MauiEventBus : IEventBus {
    public void Event<S>(S s) where S : IEvent
    {
        IEnumerable<ICallback> callbacks = tetofo.Helper.Services.GetServices<ICallback>();
        foreach(ICallback callback in callbacks)
        {
            if (callback.WhiteList == null)
            {
                callback.Callback(s);
                continue;
            }
            if(callback.WhiteList.Count == 0)
            {
                callback.Callback(s);
                continue; 
            }
            if (callback.WhiteList.Contains(s.GetType()))
            {
                callback.Callback(s);
            }
        }
    }
}