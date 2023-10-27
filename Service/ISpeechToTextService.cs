namespace tetofo.Service;

public interface ISpeechToTextService {
    Task Listen();
    void Cancel();
}