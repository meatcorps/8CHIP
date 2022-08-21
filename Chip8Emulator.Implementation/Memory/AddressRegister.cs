using Chip8Emulator.Core.Interfaces.Memory;

namespace Chip8Emulator.Implementation.Memory;

public class AddressRegister : IWritableMemory<int>
{
    private int _value;

    public AddressRegister()
    {
        Clear();
    }
    
    public int Get()
    {
        return _value;
    }

    public void Clear()
    {
        _value = 0x200;
    }

    public void Set(int value)
    {
        if (value > 4096)
            throw new ArgumentOutOfRangeException(nameof(value), "must be between zero and 4096");
        
        _value = value;
    }
}