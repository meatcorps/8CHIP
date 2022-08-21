namespace Chip8Emulator.Core.Interfaces.Memory;

public interface IWithRegisterPointer<T>
{
    void SetPointer(IMemory<T> pointer);
}