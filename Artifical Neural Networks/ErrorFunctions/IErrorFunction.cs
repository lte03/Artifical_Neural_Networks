using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artifical_Neural_Networks.ErrorFunctions
{
    public interface IErrorFunction
    {
        public double CalculateError(List<double> Target, List<double> NeuralOutput);
        public double CalculateErrorDerivative(List<double> Target, List<double> NeuralOutput);
    }
}
