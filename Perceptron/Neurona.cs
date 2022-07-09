using System;

namespace Perceptron
{
    internal class Neurona
    {
        private List<double> weights;
        private List<List<double>> inputs;
        private List<int> outputs;
        private double learningRate;

        public Neurona(List<double> weights)
        {
            this.weights = weights;
        }
        public Neurona(List<List<double>> inputs, List<int> outputs, double learningRate)
        {
            weights = generateInitialWeights(inputs[0]);
            this.inputs = inputs;
            this.outputs = outputs;
            this.learningRate = learningRate;
        }
        private List<double> generateInitialWeights(List<double> input)
        {
            Random r = new();
            List<double> weights = new();
            for (int i = 0; i < input.Count; i++)
            {
                weights.Add(r.NextDouble());
            }

            return weights;
        }

        public List<double> Fit()
        {
            int count = 0;
            while (count < this.inputs.Count)
            {
                double y = weightedSum(this.inputs[count], this.weights);
                if (y >= 0)
                {
                    y = 1;
                }
                else
                {
                    y = -1;
                }
                double error = this.outputs[count] - y;
                if (error == 0)
                {
                    count++;
                }
                else
                {
                    List<double> newWeights = new();
                    for (int j = 0; j < this.weights.Count; j++)
                    {
                        double newWeight = this.weights[j] + (this.learningRate * error * this.inputs[count][j]);
                        newWeights.Add(newWeight);
                    }
                    count = 0;
                    this.weights = newWeights;

                }
            }

            return this.weights;
        }

        public double predict(List<double> input)
        {
            double result = 0;
            result = weightedSum(input, this.weights);
            if (result >= 0)
            {
                result = 1;
            }
            else
            {
                result = -1;
            }
            Console.WriteLine("La flor es una: ");
            if (result == 1)
            {
                Console.WriteLine("Iris-setosa");
            }
            else
            {
                Console.WriteLine("Iris-versicolor");
            }
            return result;
        }

        private double weightedSum(List<double> input, List<double> weights)
        {
            double sumRes = 0;
            for (int i = 0; i < weights.Count; i++)
            {
                sumRes += (input[i] * weights[i]);
            }
            return sumRes;
        }
    }
}