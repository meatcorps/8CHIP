using Chip8Emulator.Core.Interfaces.Memory;
using Chip8Emulator.Implementation.Extensions;
using Chip8Emulator.Implementation.Memory;

namespace Chip8Emulator.Implementation.Opcodes.Base;

public abstract class OpcodeBase : IOpcode<int>
{
    private readonly MemoryCollection _memoryCollection;

    protected ProgramCounter ProgramCounter => _memoryCollection.ProgramCounter;
    protected AddressRegister AddressRegister => _memoryCollection.AddressRegister;
    protected StackMemory Stack => _memoryCollection.StackMemory;
    protected StorageMemory Storage => _memoryCollection.StorageMemory;
    protected DisplayMemory Display => _memoryCollection.DisplayMemory;
    
    public OpcodeBase(MemoryCollection memoryCollection)
    {
        _memoryCollection = memoryCollection;
    }

    public DataRegister GetRegister(byte number)
    {
        if (number > 15)
            throw new ArgumentOutOfRangeException(nameof(number), "Must be between 0 and 15");

        return _memoryCollection.DataRegisters[number];
    }
    
    public abstract bool IsOpcode(int opcode);
    public abstract void Run(int opcode);

    protected void SkipNextOpcode()
        => ProgramCounter.Set(ProgramCounter.Get() + 2);
    
    protected byte GetByteFromNibble(int opcode, int index)
        => Convert.ToByte(opcode.Nibble(index, true));
    
    protected int GetValueFromDataRegisterFromNibble(int opcode, int index)
        => GetRegister(Convert.ToByte(opcode.Nibble(index, true))).Get();
    
    protected void SetValueFromDataRegisterFromNibble(int opcode, int index)
        => GetRegister(Convert.ToByte(opcode.Nibble(index, true))).Set(GetValueFromOpcode(opcode));
    
    protected int GetAddressFromOpcode(int opcode)
        => opcode & 0x0FFF;
    
    protected int GetValueFromOpcode(int opcode)
        => opcode & 0x00FF;
    
}