using Autofac;
using Chip8Emulator.Core.Services.Base;
using Chip8Emulator.Services;

namespace Chip8Emulator.Core.Modules;

public class SimpleProgramModule : ProgramModuleBase
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<SimpleProgram>().AsImplementedInterfaces();
        base.Load(builder);
    }
}