using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artifical_Neural_Networks.ErrorFunctions
{
    public class MeanSquarredError : IErrorFunction
    {
        public double CalculateError(List<double> Target, List<double> NeuralOutput)
        {
            if (Target.Count != NeuralOutput.Count) throw new Exception("Hedef ve Çıktı Aynı Boyutta olmak zorunda");
            double error = 0;
            for (int i = 0; i < Target.Count; i++)
            {
                error += Math.Pow(Target[i] - NeuralOutput[i], 2);
            }
            return error / (Target.Count);
        }

        public double CalculateErrorDerivative(List<double> Target, List<double> NeuralOutput)
        {
            if (Target.Count != NeuralOutput.Count) throw new Exception("Hedef ve Çıktı Aynı Boyutta olmak zorunda");
            double error = 0;
            for (int i = 0; i < Target.Count; i++)
            {
                error += Target[i] - NeuralOutput[i];
            }
            return 2*error / Target.Count;
        }
    }
}
