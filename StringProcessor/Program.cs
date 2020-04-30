#region Using Statements

using StringProcessorLib;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace StringProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Configuration

            // Setup Dependency Injection.
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IStringConverter, StringConverter>()
                .BuildServiceProvider();

            #endregion

            // Get converter (demonstrates how DI could be used for loose coupling).
            var converter = serviceProvider.GetService<IStringConverter>();

            List<string> inputStrings = new List<string>();

            inputStrings.Add("AAAc91%cWwWkLq$1ci3_848v3d__K");

            List<string> outputStrings = converter.ConvertStrings(inputStrings);

            Console.WriteLine();
            
            foreach (string s in outputStrings)
            {
                Console.WriteLine($"Output String: {s}");
            }

            Console.ReadLine();
        }
    }
}