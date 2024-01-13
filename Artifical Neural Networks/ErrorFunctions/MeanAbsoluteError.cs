using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artifical_Neural_Networks.ErrorFunctions
{
    public class MeanAbsoluteError : IErrorFunction
    {
        public double CalculateError(List<double> yTrue, List<double> yPred)
        {
            if (yTrue.Count != yPred.Count)
            {
                throw new ArgumentException("Input dimensions do not match.");
            }

            double error = 0;

            for (int i = 0; i < yTrue.Count; i++)
            {
                error += Math.Abs(yTrue[i] - yPred[i]);
            }

            return error / yTrue.Count;
        }

        public double CalculateErrorDerivative(List<double> yTrue, List<double> yPred)
        {
            if (yTrue.Count != yPred.Count)
            {
                throw new ArgumentException("Input dimensions do not match.");
            }

            // Derivative of Mean Absolute Error is calculated as:
            // (y_pred - y_true) / abs(y_pred - y_true)

            double derivativeSum = 0;

            for (int i = 0; i < yTrue.Count; i++)
            {
                double diff = yPred[i] - yTrue[i];
                derivativeSum += diff / Math.Abs(diff);
            }

            return derivativeSum / yTrue.Count;
        }
    }
}
