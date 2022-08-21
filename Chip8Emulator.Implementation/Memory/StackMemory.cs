using Chip8Emulator.Core.Interfaces.Memory;

namespace Chip8Emulator.Implementation.Memory;

public class StackMemory : IWritableMemory<int>
{
    private readonly Queue<int> _queueValues = new();

    public StackMemory()
    {
        Clear();
    }

    public void Clear()
    {
        _queueValues.Clear();
    }

    public int Get()
    {
        if (_queueValues.Count == 0)
            throw new NotSupportedException("It's empty!");
            
        return _queueValues.Dequeue();
    }

    public void Set(int value)
    {
        if (_queueValues.Count >= 12)
            throw new OutOfMemoryException("Max stack size is 12 items");
        
        _queueValues.Enqueue(value);
    }
}