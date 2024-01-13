using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artifical_Neural_Networks.Activation;
using Artifical_Neural_Networks.ErrorFunctions;

namespace Artifical_Neural_Networks
{
    public class NeuralNetwork
    {
        private static Random random = new Random();
        private List<Layer> layers;
        private int epochs;
        private IErrorFunction errorFunction;
        private double learningRate;
        public NeuralNetwork(List<Layer> layers, int epochs, IErrorFunction errorFunction, double learningRate)
        {
            this.layers = layers;
            this.epochs = epochs;
            this.errorFunction = errorFunction;
            this.learningRate = learningRate;
        }

        public void Train(List<List<double>> dataX, List<double> dataY)
        {
            if (dataX.Count != dataY.Count)
            {
                throw new Exception("Verilerin Satır sayıları aynı olmalı");
            }
            if(dataX == null || dataY == null)
            {
                throw new Exception();
            }
            for (int epoch = 0;epoch < epochs;epoch++)
            {
                ShuffleData(dataX, dataY);
                for (int dataIndex = 0; dataIndex < dataX.Count; dataIndex++)
                {
                    ForwardPropagation(dataX[dataIndex]);
                    BackwardPropogation(dataY[dataIndex]);
                }
            }
        }

        private void ShuffleData(List<List<double>> dataX, List<double> dataY)
        {
            int n = dataX.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                List<double> tempX = dataX[k];
                dataX[k] = dataX[n];
                dataX[n] = tempX;
                double tempY = dataY[k];
                dataY[k] = dataY[n];
                dataY[n] = tempY;
            }
        }

        private void ForwardPropagation(List<double> inputs)
        {
            foreach (Neuron neuron in layers[0].Neurons)
            {
                neuron.Inputs = inputs;
            }
            for (int i = 0; i < layers.Count; i++)
            {
                List<double> outToIn = new List<double>();
                foreach (Neuron neuron in layers[i].Neurons)
                {
                    neuron.Output = CalculateOutputs(neuron.Inputs, neuron.Weights, neuron.Bias, layers[i].Activation);
                    outToIn.Add(neuron.Output);
                }
                if (i < layers.Count - 1)
                {
                    foreach (Neuron nextNeuron in layers[i + 1].Neurons)
                    {
                        nextNeuron.Inputs = outToIn;
                    }
                }
            }
        }

        private void BackwardPropogation(double dataY)
        {
            Layer outputLayer = layers.Last();
            List<double> outputGradients = new List<double>();
            for (int i = 0; i < outputLayer.Neurons.Count; i++)
            {
                Neuron neuron = outputLayer.Neurons[i];
                double derivative = outputLayer.Activation.DerivativeFunction(neuron.Output);
                double error = errorFunction.CalculateErrorDerivative(new List<double> { dataY }, new List<double> { neuron.Output });
                double gradient = error * derivative;
                outputGradients.Add(gradient);
                for (int j = 0; j < neuron.Weights.Count; j++)
                {
                    neuron.Weights[j] -= learningRate * gradient * neuron.Inputs[j];
                }
                neuron.Bias -= learningRate * gradient;
            }
            for (int i = layers.Count - 2; i >= 0; i--)
            {
                Layer hiddenLayer = layers[i];
                List<double> hiddenGradients = new List<double>();
                for (int j = 0; j < hiddenLayer.Neurons.Count; j++)
                {
                    Neuron neuron = hiddenLayer.Neurons[j];
                    double derivative = hiddenLayer.Activation.DerivativeFunction(neuron.Output);
                    double sumGradient = 0;
                    for (int k = 0; k < layers[i + 1].Neurons.Count; k++)
                    {
                        Neuron nextNeuron = layers[i + 1].Neurons[k];
                        sumGradient += outputGradients[k] * nextNeuron.Weights[j];
                    }
                    double gradient = sumGradient * derivative;
                    hiddenGradients.Add(gradient);
                    for (int k = 0; k < neuron.Weights.Count; k++)
                    {
                        neuron.Weights[k] -= learningRate * gradient * neuron.Inputs[k];
                    }
                    neuron.Bias += learningRate * gradient;
                }
                outputGradients = hiddenGradients;
            }
        }

        private double CalculateOutputs(List<double> inputs, List<double> weights, double bias, IActivation activation)
        {
            double result = 0;
            for (int i = 0; i < inputs.Count; i++)
            {
                result += inputs[i] * weights[i];
            }
            result += bias;
            return activation.Function(result);
        }

        public List<List<double>> Predict(List<List<double>> dataXTest)
        {
            if(dataXTest == null)
            {
                throw new Exception();
            }
            List<List<double>> predicted = new List<List<double>>();
            for (int dataIndex = 0; dataIndex < dataXTest.Count; dataIndex++)
            {
                ForwardPropagation(dataXTest[dataIndex]);
                List<double> outputs = new List<double>();
                foreach (Neuron lastLayerNeuron in layers.Last().Neurons)
                {
                    outputs.Add(lastLayerNeuron.Output);
                }
                predicted.Add(outputs);
            }
            return predicted;
        }

        public List<Layer> Layers
        {
            get { return layers; }
            set { layers = value; }
        }

        public int Epochs
        {
            get { return epochs; }
            set { epochs = value; }
        }

        public IErrorFunction ErrorFunction
        {
            get { return errorFunction; }
            set { errorFunction = value; }
        }

        public double LearningRate
        {
            get { return learningRate; }
            set { learningRate = value; }
        }
    }
}
