// See https://aka.ms/new-console-template for more information

using Autofac;
using Chip8Emulator.Core.Interfaces;
using Chip8Emulator.Core.Interfaces.Program;
using Chip8Emulator.Core.Modules;


var builder = new ContainerBuilder();

builder.RegisterModule(new NLogModule());
builder.RegisterModule(new SimpleProgramModule());

var container = builder.Build();
container.Resolve<ILifeCycle>().Start(container);

