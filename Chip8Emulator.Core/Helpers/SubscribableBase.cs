namespace Chip8Emulator.Core.Helpers;

public class SubscribableBase : IDisposable
{
    protected readonly CancellationTokenRegistration SubscriptionToken = new();

    protected virtual void DoDispose()
    {
    }
    
    public void Dispose()
    {
        DoDispose();
        SubscriptionToken.Dispose();
        GC.SuppressFinalize(this);
    }
}