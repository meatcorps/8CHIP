using Chip8Emulator.Core.Interfaces.Memory;

namespace Chip8Emulator.Implementation.Memory;

public class DataRegister : IWritableMemory<int>
{
    private int _value;

    public DataRegister()
    {
        Clear();
    }
    
    public int Get()
    {
        return _value;
    }

    public void Clear()
    {
        _value = 0;
    }

    public void Set(int value)
    {
        _value = value;
    }
}