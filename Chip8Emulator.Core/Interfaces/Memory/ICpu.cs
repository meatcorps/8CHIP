namespace Chip8Emulator.Core.Interfaces.Memory;

public interface ICpu
{
    void Start();
    void Pause();
    void Reset();
    void Stop();
}