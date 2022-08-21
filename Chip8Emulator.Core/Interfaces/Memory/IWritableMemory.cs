namespace Chip8Emulator.Core.Interfaces.Memory;

public interface IWritableMemory<T> : IMemory<T>, IResettableMemory<T>
{
    void Set(T value);
}