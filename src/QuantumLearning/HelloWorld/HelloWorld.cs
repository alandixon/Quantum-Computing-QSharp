using System;
using System.Threading.Tasks;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
 
namespace QubitExample
{
    class Driver
    {
        static async Task Main(string[] args)
        {
            CallHelloQ();

            await CallMeasureQubitsAsync();
        }

        static void CallHelloQ()
        {
            using (var qsim = new QuantumSimulator())
            {
                HelloQ.Run(qsim).Wait();
            }
            Console.WriteLine("---------------------------------------------------");
        }

        static async Task CallMeasureQubitsAsync()
        {
            using var qsim = new QuantumSimulator();

            var repeats = 100;
            Console.WriteLine($"Running qubit measurement {repeats} times.");

            var results = await MeasureQubits.Run(qsim, repeats);
            Console.WriteLine($"Received {results} ones.");
            Console.WriteLine($"Received {repeats - results} zeros.");
            Console.WriteLine("---------------------------------------------------");
        }


    }
}