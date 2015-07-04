using System;
using System.Diagnostics;
using CLAP;

internal class ConsoleBase
{
    [Error]
    public void Error( ExceptionContext context )
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine( context.Exception.Message );
        Console.ResetColor();
    }

    [Empty]
    [Help( Aliases = "h,?" )]
    public void Help( string help )
    {
        Console.WriteLine( help );
    }

    [Global]
    public void Debug()
    {
        Debugger.Launch();
    }
}