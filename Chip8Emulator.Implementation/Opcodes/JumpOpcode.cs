using Chip8Emulator.Implementation.Extensions;
using Chip8Emulator.Implementation.Memory;
using Chip8Emulator.Implementation.Opcodes.Base;

namespace Chip8Emulator.Implementation.Opcodes;

public class JumpOpcode : OpcodeBase
{
    public JumpOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x1000, true, false, false ,false);

    public override void Run(int opcode)
        => ProgramCounter.Set(opcode & 0x0FFF);
}