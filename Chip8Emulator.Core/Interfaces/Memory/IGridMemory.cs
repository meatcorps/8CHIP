namespace Chip8Emulator.Core.Interfaces.Memory;

public interface IGridMemory<T>
{
    T Get(int x, int y);
    void Set(int x, int y, T value);
}