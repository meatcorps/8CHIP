namespace Chip8Emulator.Core.Interfaces.Memory;

public interface IResettableMemory<T>: IMemory<T>
{
    void Clear();
}