namespace Chip8Emulator.Core.Interfaces.Memory;

public interface IRegister<TName, TType>
{
    TName Name { get; }
    TType Value { get; set; }
}