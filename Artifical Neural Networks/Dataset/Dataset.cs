using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artifical_Neural_Networks.Dataset
{
    public class Dataset
    {
        private List<List<double>> dataX;
        private List<double> dataY;
        private List<string> labels;

        public List<List<double>> DataX
        {
            get { return dataX; }
            set { dataX = value; }
        }

        public List<double> DataY
        {
            get { return dataY; }
            set { dataY = value; }
        }

        public List<string> Labels
        {
            get { return labels; }
            set { labels = value; }
        }
    }
}
