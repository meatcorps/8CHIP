using Chip8Emulator.Implementation.Extensions;
using Chip8Emulator.Implementation.Memory;
using Chip8Emulator.Implementation.Opcodes.Base;

namespace Chip8Emulator.Implementation.Opcodes;

public class CallSubroutineOpcode : OpcodeBase
{
    public CallSubroutineOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x2000, true, false, false ,false);

    public override void Run(int opcode)
    {
        Stack.Set(ProgramCounter.Get());
        ProgramCounter.Set(opcode & 0x0FFF);
    }
}