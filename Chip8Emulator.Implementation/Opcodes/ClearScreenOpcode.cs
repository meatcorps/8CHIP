using Chip8Emulator.Implementation.Memory;
using Chip8Emulator.Implementation.Opcodes.Base;

namespace Chip8Emulator.Implementation.Opcodes;

public class ClearScreenOpcode : OpcodeBase
{
    public ClearScreenOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode == 0x00E0;

    public override void Run(int opcode)
    {
        Display.Clear();
    }
}