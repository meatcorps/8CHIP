namespace Chip8Emulator.Implementation.Memory;

public class MemoryCollection
{
    public readonly DisplayMemory DisplayMemory;
    public readonly ProgramCounter ProgramCounter;
    public readonly AddressRegister AddressRegister;
    public readonly DataRegister[] DataRegisters;
    public readonly StackMemory StackMemory;
    public readonly StorageMemory StorageMemory;

    public MemoryCollection(DisplayMemory displayMemory, ProgramCounter programCounter, AddressRegister addressRegister, IEnumerable<DataRegister> dataRegisters, StackMemory stackMemory, StorageMemory storageMemory)
    {
        DisplayMemory = displayMemory;
        ProgramCounter = programCounter;
        AddressRegister = addressRegister;
        DataRegisters = dataRegisters.ToArray();
        StackMemory = stackMemory;
        StorageMemory = storageMemory;
    }
}