using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Perceptron
{
    internal class Dataset
    {
        private List<List<double>> inputs;
        private List<int> outputs;
        public Dataset(string filename)
        {
            this.inputs = extractInputs(filename);
            
        }

        private List<List<double>> extractInputs(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            List<List<double>> inputs = new();
            foreach (string line in lines)
            {
                string[] elements = line.Split(',');
                List<double> tempInput = new();
                tempInput.Add(1.0);
                for (int i = 0; i < elements.Length; i++)
                {
                    if (i != elements.Length - 1)
                    {
                        tempInput.Add(double.Parse(elements[i]));
                    }
                }
                inputs.Add(tempInput);
            }

            return inputs;
        }



    }
}
