using Chip8Emulator.Implementation.Extensions;
using Chip8Emulator.Implementation.Memory;
using Chip8Emulator.Implementation.Opcodes.Base;

namespace Chip8Emulator.Implementation.Opcodes;

public class SetDataRegisterToRegisterOpcode : OpcodeBase
{
    public SetDataRegisterToRegisterOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x8000, true, false, false);

    public override void Run(int opcode)
    {
        var register1 = GetRegister(Convert.ToByte(opcode.Nibble(2, true)));
        var register2 = GetRegister(Convert.ToByte(opcode.Nibble(1, true)));
        register1.Set(register2.Get());
    }
}