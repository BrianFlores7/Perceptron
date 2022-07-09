using System;
using static Perceptron.Neurona;
using static Perceptron.Dataset;

namespace Perceptron
{
    class Program
    {
        static void Main(string[] args)
        {
            Dataset dataset = new Dataset("../../../dataset/iris.data");
            Random random = new Random();
            Neurona neurona = new Neurona(dataset.getInputs(), dataset.getOutputs(), random.NextDouble());
            List<double> finalWeights = neurona.Fit();
            Neurona newNeurona = new Neurona(finalWeights);
            Console.WriteLine("Entrada 1: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Entrada 2: ");
            double x2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Entrada 3: ");
            double x3 = double.Parse(Console.ReadLine());
            Console.WriteLine("Entrada 4: ");
            double x4 = double.Parse(Console.ReadLine());
            var flower = new List<double>()
                    {
                        1.0,
                        x1,x2,x3,x4
                    };
            newNeurona.predict(flower);
        }
    }
}