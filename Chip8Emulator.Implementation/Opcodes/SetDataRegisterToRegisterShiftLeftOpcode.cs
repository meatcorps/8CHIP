using Chip8Emulator.Implementation.Extensions;
using Chip8Emulator.Implementation.Memory;
using Chip8Emulator.Implementation.Opcodes.Base;

namespace Chip8Emulator.Implementation.Opcodes;

public class SetDataRegisterToRegisterShiftLeftOpcode : OpcodeBase
{
    public SetDataRegisterToRegisterShiftLeftOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x800E, true, false, false);

    public override void Run(int opcode)
    {
        var register1 = GetRegister(Convert.ToByte(opcode.Nibble(2, true)));
        var register2 = GetRegister(0xF);
        register2.Set(register1.Get() & 0x80);
        register1.Set(register1.Get() << 1);
    }
}