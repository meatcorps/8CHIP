using Chip8Emulator.Core.Interfaces;
using Chip8Emulator.Core.Interfaces.Program;
using Microsoft.Extensions.Logging;

namespace Chip8Emulator.Services;

public class SimpleProgram : IProgram
{
    private readonly ILogger<SimpleProgram> _logger;

    public SimpleProgram(ILogger<SimpleProgram> logger)
    {
        _logger = logger;
        _logger.LogInformation("Program started");
    }

    public bool Run()
    {
        return Console.ReadKey().Key != ConsoleKey.Spacebar;
    }
}