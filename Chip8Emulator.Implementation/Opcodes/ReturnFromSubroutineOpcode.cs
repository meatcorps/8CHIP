using Chip8Emulator.Implementation.Memory;
using Chip8Emulator.Implementation.Opcodes.Base;

namespace Chip8Emulator.Implementation.Opcodes;

public class ReturnFromSubroutineOpcode : OpcodeBase
{
    public ReturnFromSubroutineOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode == 0x00EE;

    public override void Run(int opcode)
    {
        ProgramCounter.Set(Stack.Get());
    }
}