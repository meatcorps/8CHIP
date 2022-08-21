using Autofac;

namespace Chip8Emulator.Core.Services.Base;

public abstract class ProgramModuleBase : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<LifeCycle>()
            .AsImplementedInterfaces();
        base.Load(builder);
    }
}