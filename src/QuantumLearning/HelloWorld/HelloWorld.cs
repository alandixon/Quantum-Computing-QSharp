using Microsoft.Quantum.Simulation.Simulators;
using System;
using System.Threading.Tasks;

namespace QubitExample
{
    class Driver
    {
        static async Task Main(string[] args)
        {
            CallHelloQ();

            await CallMeasureQubitsAsyncPauliZ();

            await CallMeasureQubitsAsyncPauliX();
        }

        static void CallHelloQ()
        {
            using (var qsim = new QuantumSimulator())
            {
                HelloQ.Run(qsim).Wait();
            }
            Console.WriteLine("---------------------------------------------------");
        }

        static async Task CallMeasureQubitsAsyncPauliZ()
        {
            using var qsim = new QuantumSimulator();

            var repeats = 100;
            Console.WriteLine($"Running qubit measurement {repeats} times.");

            var results = await MeasureQubitsPauliZ.Run(qsim, repeats);
            Console.WriteLine($"Received {results} ones.");
            Console.WriteLine($"Received {repeats - results} zeros.");
            Console.WriteLine("---------------------------------------------------");
        }

        static async Task CallMeasureQubitsAsyncPauliX()
        {
            using var qsim = new QuantumSimulator();

            var repeats = 100;
            Console.WriteLine($"Running qubit measurement {repeats} times.");

            var results = await MeasureQubitsPauliX.Run(qsim, repeats);
            Console.WriteLine($"Received {results} ones.");
            Console.WriteLine($"Received {repeats - results} zeros.");
            Console.WriteLine("---------------------------------------------------");
        }


    }
}