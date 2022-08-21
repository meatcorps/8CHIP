using Chip8Emulator.Implementation.Extensions;
using Chip8Emulator.Implementation.Memory;
using Chip8Emulator.Implementation.Opcodes.Base;

namespace Chip8Emulator.Implementation.Opcodes;

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