using Chip8Emulator.Implementation.Extensions;
using Chip8Emulator.Implementation.Memory;
using Chip8Emulator.Implementation.Opcodes.Base;

namespace Chip8Emulator.Implementation.Opcodes;

public class AddDataRegisterOpcode : OpcodeBase
{
    public AddDataRegisterOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x7000, true, false, false ,false);

    public override void Run(int opcode)
    {
        var register = GetRegister(Convert.ToByte(opcode.Nibble(2, true)));
        register.Set(register.Get() + GetValueFromOpcode(opcode));
    }
}