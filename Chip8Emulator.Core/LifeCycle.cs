using Autofac;
using Autofac.Core;
using Chip8Emulator.Core.Interfaces;
using Chip8Emulator.Core.Interfaces.Program;
using Microsoft.Extensions.Logging;

namespace Chip8Emulator;

public class LifeCycle : ILifeCycle, IDisposable
{
    private readonly IProgram _program;
    private readonly ILogger<LifeCycle> _logger;

    public LifeCycle(IProgram program, ILogger<LifeCycle> logger)
    {
        _program = program;
        _logger = logger;
    }

    public void Start(IContainer container)
    {
        _logger.LogInformation("Application started");
        
        using (container.BeginLifetimeScope()) {
            while (_program.Run())
            {
            }
        }
        container.Dispose();
        
    }

    public void Stop()
    {
        _logger.LogInformation("Application stopped");
    }

    public void Dispose()
    {
        Stop();
        GC.SuppressFinalize(this);
    }
}