using Chip8Emulator.Implementation.Extensions;
using Chip8Emulator.Implementation.Memory;
using Chip8Emulator.Implementation.Opcodes.Base;

namespace Chip8Emulator.Implementation.Opcodes;

public class SkipInstructionIfConditionNotEqualsOpcode : OpcodeBase
{
    public SkipInstructionIfConditionNotEqualsOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x4000, true, false, false ,false);

    public override void Run(int opcode)
    {
        if (GetValueFromDataRegisterFromNibble(opcode, 2) != GetValueFromOpcode(opcode))
            SkipNextOpcode();
    }
}