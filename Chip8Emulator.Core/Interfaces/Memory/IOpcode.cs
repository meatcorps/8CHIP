namespace Chip8Emulator.Core.Interfaces.Memory;

public interface IOpcode<T>
{
    bool IsOpcode(T opcode);
    void Run(T opcode);
}