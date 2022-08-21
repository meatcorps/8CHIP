using Chip8Emulator.Core.Interfaces.Memory;

namespace Chip8Emulator.Implementation.Memory;

public class DisplayMemory: IGridMemory<bool>, IResettableMemory<bool>
{
    const int WIDTH = 64;
    const int HEIGHT = 32;
        
    private bool[] _displayMemory = new bool[2048]; 
    
    public bool Get(int x, int y)
        => _displayMemory[Convert(x, y)];

    public void Set(int x, int y, bool value)
        => _displayMemory[Convert(x, y)] = value;

    private static int Convert(int x, int y)
    {
        x %= WIDTH;
        y %= HEIGHT;
        return x + y * WIDTH;
    }

    public bool Get()
    {
        return false;
    }

    public void Clear()
    {
        for (var i = 0; i < 2048; i++)
            _displayMemory[i] = false;
    }
}