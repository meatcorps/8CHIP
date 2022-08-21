using Chip8Emulator.Core.Interfaces.Memory;

namespace Chip8Emulator.Implementation.Memory;

public class StorageMemory : IWritableMemory<byte>, ILoadableMemory<byte>, IWithRegisterPointer<int>
{
    private IMemory<int>? _addressPointer;
    private readonly byte[] _values = new byte[4096];
    private readonly byte[] _defaultValues = new byte[4096];

    public byte Get()
    {
        if (_addressPointer is null)
            throw new NullReferenceException("Did you forget to set the pointer?");
        
        return _values[_addressPointer.Get()];
    }

    public void Clear()
    {
        for (var i = 0; i < 4096; i++)
            _values[i] = _defaultValues[i];
    }

    public void Set(byte value)
    {
        if (_addressPointer is null)
            throw new NullReferenceException("Did you forget to set the pointer?");
        
        _values[_addressPointer.Get()] = value;
    }

    public void Import(byte[] values)
    {
        if (values.Length != 4096)
            throw new ArgumentOutOfRangeException(nameof(values), "must be exact 4096 bytes long.");

        for (var i = 0; i < 4096; i++)
            _defaultValues[i] = values[i];
        
        Clear();
    }

    public void SetPointer(IMemory<int> pointer)
        => _addressPointer = pointer;
}