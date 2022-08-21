using Chip8Emulator.Implementation.Extensions;
using Chip8Emulator.Implementation.Memory;
using Chip8Emulator.Implementation.Opcodes.Base;

namespace Chip8Emulator.Implementation.Opcodes;

public class SetDataRegisterOpcode : OpcodeBase
{
    public SetDataRegisterOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x6000, true, false, false ,false);

    public override void Run(int opcode)
    {
        SetValueFromDataRegisterFromNibble(opcode, 2);
    }
}