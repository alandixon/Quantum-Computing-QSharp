using Microsoft.Quantum.Simulation.Simulators;
using System;
using System.Threading.Tasks;


// Quantum Computing for Computer Scientists, Microsoft Research, 2018
// page: https://www.microsoft.com/en-us/research/video/quantum-computing-computer-scientists/
// video: https://www.youtube.com/watch?v=F_Riqjdh2oM
// slides: https://www.microsoft.com/en-us/research/uploads/prod/2018/05/40655.compressed.pdf

namespace QC4CS
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CallStateMachine();
        }

        static async Task CallStateMachine()
        {
            using var qsim = new QuantumSimulator();

            Console.WriteLine($"Running state machine.");
            Console.WriteLine("---------------------------------------------------");

            var results = await StateMachine.Run(qsim);
            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine($"Received {results}.");
            Console.WriteLine("---------------------------------------------------");
        }


    }
}
