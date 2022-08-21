namespace Chip8Emulator.Core.Interfaces.Memory;

public interface ILoadableMemory<T>
{
    void Import(T[] value);
}