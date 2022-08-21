using Chip8Emulator.Implementation.Extensions;
using Chip8Emulator.Implementation.Memory;
using Chip8Emulator.Implementation.Opcodes.Base;

namespace Chip8Emulator.Implementation.Opcodes;

public class SetDataRegisterToRegisterSubtractReverseOpcode : OpcodeBase
{
    public SetDataRegisterToRegisterSubtractReverseOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x8007, true, false, false);

    public override void Run(int opcode)
    {
        var register1 = GetRegister(Convert.ToByte(opcode.Nibble(2, true)));
        var register2 = GetRegister(Convert.ToByte(opcode.Nibble(1, true)));
        var newValue = register2.Get() - register1.Get();
        GetRegister(0xF).Set(register2.Get() > register1.Get() ? 1 : 0);
        register1.Set(newValue & 0xFF);
    }
}