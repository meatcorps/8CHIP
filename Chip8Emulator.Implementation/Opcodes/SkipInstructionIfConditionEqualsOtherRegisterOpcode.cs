using Chip8Emulator.Implementation.Extensions;
using Chip8Emulator.Implementation.Memory;
using Chip8Emulator.Implementation.Opcodes.Base;

namespace Chip8Emulator.Implementation.Opcodes;

public class SkipInstructionIfConditionEqualsOtherRegisterOpcode : OpcodeBase
{
    public SkipInstructionIfConditionEqualsOtherRegisterOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x5000, true, false, false ,false);

    public override void Run(int opcode)
    {
        if (GetValueFromDataRegisterFromNibble(opcode, 2) == GetValueFromDataRegisterFromNibble(opcode, 1))
            SkipNextOpcode();
    }
}