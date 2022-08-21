using Autofac;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Chip8Emulator.Core.Modules;

public class NLogModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var loggerFactory = new LoggerFactory();
        loggerFactory.AddProvider(new NLogLoggerProvider());
        builder.RegisterInstance(loggerFactory).As<ILoggerFactory>().SingleInstance();
        builder.RegisterGeneric(typeof(Logger<>)).As(typeof(ILogger<>)).SingleInstance();
    }
}