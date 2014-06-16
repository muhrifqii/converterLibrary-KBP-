using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konverter
{
    /// <summary>
    /// Interface untuk yang dapat diukur
    /// </summary>
    /// <typeparam name="T">Type Parameter for ListSatuan</typeparam>
    public interface IMeasurable<T>
    {
        double Value { get; set; }
        T Satuan { get; set; }
        void ConvertTo(T tujuan);
    }

}
