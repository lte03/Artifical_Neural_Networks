using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artifical_Neural_Networks.Activation;

namespace Artifical_Neural_Networks
{
    public class Layer
    {
        private static Random random = new Random();
        private int numberofNeurons;
        private int inputSize;
        private List<Neuron> neurons;
        private IActivation activation;
        public Layer(int numberofNeurons, IActivation activation, int inputSize)
        {
            this.numberofNeurons = numberofNeurons;
            this.activation = activation;
            this.inputSize = inputSize;
            neurons = new List<Neuron>();
            for (int i = 0; i < numberofNeurons; i++)
            {
                neurons.Add(new Neuron(GenerateRandomWeight(), GenerateBias()));
            }
        }

        private List<double> GenerateRandomWeight()
        {
            List<double> firstWeights = new List<double>();
            for (int i = 0; i < inputSize; i++)
            {
                double weight = Generator();
                firstWeights.Add(weight);
            }
            return firstWeights;
        }
        private double Generator()
        {
            return random.NextDouble() * 2 - 1;
        }
        private double GenerateBias()
        {
            return Generator();
        }

        public List<Neuron> Neurons
        {
            get { return neurons; }
            set { neurons = value; }
        }

        public int NumberOfNeurons
        {
            get { return numberofNeurons; }
            set { numberofNeurons = value; }
        }

        public int InputSize
        {
            get { return inputSize; }
            set { inputSize = value; }
        }

        public IActivation Activation
        {
            get { return activation; }
            set { activation = value; }
        }
    }
}
