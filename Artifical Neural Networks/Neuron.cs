using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artifical_Neural_Networks
{
    public class Neuron
    {
        private List<double> weights;
        private double bias;

        public Neuron(List<double> weights, double bias)
        {
            this.weights = weights;
            this.bias = bias;
        }

        public List<double> Weights
        {
            get { return weights; }
            set { weights = value; }
        }

        public double Bias
        {
            get { return bias; }
            set { bias = value; }
        }

        public List<double> Inputs { get; set; }
        public double Output { get; set; }
    }
}
