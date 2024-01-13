using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artifical_Neural_Networks.Dataset
{
    public class FileReader
    {
        private string filename;
        private char seperator;

        public FileReader(string filename, char seperator)
        {
            this.filename = filename;
            this.seperator = seperator;
        }

        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }
        public char Seperator
        {
            get { return seperator; }
            set { seperator = value; }
        }

        public Dataset Read()
        {
            if (seperator == '.')
            {
                throw new Exception("Ayırıcı karakter '.' olmamalıdır.");
            }
            Dataset dataset = new Dataset();
            try
            {
                List<List<double>> dataX = new List<List<double>>();
                List<double> dataY = new List<double>();
                List<List<double>> data = new List<List<double>>();
                StreamReader reader = new StreamReader(filename);
                string []firstLine = reader.ReadLine().Split(seperator);
                dataset.Labels = firstLine.ToList();
                while (!reader.EndOfStream)
                {
                    string[] row = reader.ReadLine().Split(seperator);
                    List<double> temp = new List<double>();
                    for(int i = 0; i < row.Length; i++)
                    {
                        temp.Add(Convert.ToDouble(row[i]));
                    }
                    data.Add(temp);
                }
                reader.Close();
                for(int i = 0;i < data.Count; i++)
                {
                    List<double> temp = new List<double>();
                    for(int j = 0; j < data[i].Count; j++)
                    {
                        if(j == data[i].Count - 1)
                        {
                            dataY.Add((double)data[i][j]);
                        }
                        else
                        {
                            temp.Add((double)data[i][j]);
                        }
                    }
                    dataX.Add(temp);
                }
                dataset.DataX = dataX;
                dataset.DataY = dataY;
                return dataset;
            }
            catch (IOException)
            {
                throw new Exception("Dosya okuma Başarısız");
            }
        }
    }
}
