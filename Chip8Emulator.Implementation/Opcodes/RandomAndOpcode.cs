using Chip8Emulator.Implementation.Extensions;
using Chip8Emulator.Implementation.Memory;
using Chip8Emulator.Implementation.Opcodes.Base;

namespace Chip8Emulator.Implementation.Opcodes;

public class RandomAndOpcode : OpcodeBase
{
    public RandomAndOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0xC000, true, false, false ,false);

    public override void Run(int opcode)
    {
        var register = GetRegister(Convert.ToByte(opcode.Nibble(2, true)));
        var random = Random.Shared.Next() % 255;
        var newValue = random & GetValueFromOpcode(opcode);
        register.Set(newValue & 0xFF);
    }
}