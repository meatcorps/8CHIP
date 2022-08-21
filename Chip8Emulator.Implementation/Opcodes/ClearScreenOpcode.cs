using Chip8Emulator.Implementation.Extensions;
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

public class SkipInstructionIfConditionEqualsOpcode : OpcodeBase
{
    public SkipInstructionIfConditionEqualsOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x3000, true, false, false ,false);

    public override void Run(int opcode)
    {
        if (GetValueFromDataRegisterFromNibble(opcode, 2) == GetValueFromOpcode(opcode))
            SkipNextOpcode();
    }
}

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

public class SetDataRegisterOpcode : OpcodeBase
{
    public SetDataRegisterOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x6000, true, false, false ,false);

    public override void Run(int opcode)
    {
        SetValueFromDataRegisterFromNibble(opcode, 2);
    }
}

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

public class SetDataRegisterToRegisterOrOpcode : OpcodeBase
{
    public SetDataRegisterToRegisterOrOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x8001, true, false, false);

    public override void Run(int opcode)
    {
        var register1 = GetRegister(Convert.ToByte(opcode.Nibble(2, true)));
        var register2 = GetRegister(Convert.ToByte(opcode.Nibble(1, true)));
        register1.Set(register1.Get() | register2.Get());
    }
}

public class SetDataRegisterToRegisterAndOpcode : OpcodeBase
{
    public SetDataRegisterToRegisterAndOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x8002, true, false, false);

    public override void Run(int opcode)
    {
        var register1 = GetRegister(Convert.ToByte(opcode.Nibble(2, true)));
        var register2 = GetRegister(Convert.ToByte(opcode.Nibble(1, true)));
        register1.Set(register1.Get() & register2.Get());
    }
}

public class SetDataRegisterToRegisterXorOpcode : OpcodeBase
{
    public SetDataRegisterToRegisterXorOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x8003, true, false, false);

    public override void Run(int opcode)
    {
        var register1 = GetRegister(Convert.ToByte(opcode.Nibble(2, true)));
        var register2 = GetRegister(Convert.ToByte(opcode.Nibble(1, true)));
        register1.Set(register1.Get() ^ register2.Get());
    }
}

public class SetDataRegisterToRegisterAddOpcode : OpcodeBase
{
    public SetDataRegisterToRegisterAddOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x8004, true, false, false);

    public override void Run(int opcode)
    {
        var register1 = GetRegister(Convert.ToByte(opcode.Nibble(2, true)));
        var register2 = GetRegister(Convert.ToByte(opcode.Nibble(1, true)));
        var newValue = register1.Get() + register2.Get();
        GetRegister(0xF).Set(newValue > 0xFF ? 1 : 0);
        register1.Set(newValue & 0xFF);
    }
}

public class SetDataRegisterToRegisterSubtractOpcode : OpcodeBase
{
    public SetDataRegisterToRegisterSubtractOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x8005, true, false, false);

    public override void Run(int opcode)
    {
        var register1 = GetRegister(Convert.ToByte(opcode.Nibble(2, true)));
        var register2 = GetRegister(Convert.ToByte(opcode.Nibble(1, true)));
        var newValue = register1.Get() - register2.Get();
        GetRegister(0xF).Set(register1.Get() > register2.Get() ? 1 : 0);
        register1.Set(newValue & 0xFF);
    }
}

public class SetDataRegisterToRegisterShiftRightOpcode : OpcodeBase
{
    public SetDataRegisterToRegisterShiftRightOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x8006, true, false, false);

    public override void Run(int opcode)
    {
        var register1 = GetRegister(Convert.ToByte(opcode.Nibble(2, true)));
        GetRegister(0xF).Set(register1.Get() & 0x1);
        register1.Set(register1.Get() >> 1);
    }
}

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

public class SkipInstructionIfConditionNotEqualsOtherRegisterOpcode : OpcodeBase
{
    public SkipInstructionIfConditionNotEqualsOtherRegisterOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0x9000, true, false, false ,false);

    public override void Run(int opcode)
    {
        if (GetValueFromDataRegisterFromNibble(opcode, 2) != GetValueFromDataRegisterFromNibble(opcode, 1))
            SkipNextOpcode();
    }
}

public class SetMemoryAddressOpcode : OpcodeBase
{
    public SetMemoryAddressOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0xA000, true, false, false ,false);

    public override void Run(int opcode)
    {
        AddressRegister.Set(GetAddressFromOpcode(opcode));
    }
}

public class JumpMemoryAddressOpcode : OpcodeBase
{
    public JumpMemoryAddressOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0xA000, true, false, false ,false);

    public override void Run(int opcode)
    {
        AddressRegister.Set(GetRegister(0).Get() + GetAddressFromOpcode(opcode));
    }
}

public class RandomAndOpcode : OpcodeBase
{
    public RandomAndOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0xC000, true, false, false ,false);

    public override void Run(int opcode)
    {
        var register = GetRegister(Convert.ToByte(opcode.Nibble(2, true)));
        var random = Random.Shared.Next() % 255;
        var newValue = random & GetValueFromOpcode(opcode);
        register.Set(newValue & 0xFF);
    }
}

public class DrawOpcode : OpcodeBase
{
    public DrawOpcode(MemoryCollection memoryCollection) : base(memoryCollection)
    {
    }

    public override bool IsOpcode(int opcode)
        => opcode.IsEquals(0xD000, true, false, false ,false);

    public override void Run(int opcode)
    {
        const int WIDTH = 8;
        var height = opcode.Nibble(0, true);
        var posX = opcode.Nibble(2, true);
        var posY = opcode.Nibble(1, true);
        var register = GetRegister(0xF);
        register.Set(0);
        var tempPointer = new AddressRegister();
        Storage.SetPointer(tempPointer);
        
        for (var x = 0; x < WIDTH; x++)
        {
            tempPointer.Set(AddressRegister.Get() + x);
            var sprite = Storage.Get();
            
            for (var y = 0; y < height; y++)
            {
                if ((sprite & 0x80) > 0)
                {
                    var current = Display.Get(posX + x, posY + x);
                    Display.Set(posX + x, posY + x, !current);
                    if (!current) 
                        register.Set(1);
                }
                
                sprite <<= 1;
            } 
            
            
        }
        
        Storage.SetPointer(ProgramCounter);
    }
}