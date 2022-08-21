using Autofac;

namespace Chip8Emulator.Core.Interfaces.Program;

public interface ILifeCycle
{
    void Start(IContainer container);
    void Stop();
}