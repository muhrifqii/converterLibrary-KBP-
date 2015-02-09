using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//jeneng library seng awakdewe gawe
using Konverter;

namespace kbp
{
    class Program
    {
        private static void luasPersegi(Length a, Length b)
        {
            a.ConvertTo(Length.ListSatuan.picometer);
            b.ConvertTo(Length.ListSatuan.milimeter);
        }

        static void Main(string[] args)
        {
            //Mass a = new Mass();
            //a.Satuan = Mass.ListSatuan.kilogram;
            //a.Value = 10;
            //a.ConvertTo(Mass.ListSatuan.centigram);

            //Mass b = new Mass();
            //b.Satuan = Mass.ListSatuan.gram;
            //b.Value = 10000;

            //bool nyebai = Mass.Equals(a, b);

            //Console.WriteLine(nyebai);

            Length x = new Length();
            x.Satuan = Length.ListSatuan.centimeter;
            x.Value = 2300;
            x.ConvertTo(Length.ListSatuan.meter);

            Length y = new Length();
            y.Value = 2.3;
            y.Satuan = Length.ListSatuan.dekameter;
            y.ConvertTo(Length.ListSatuan.meter);

            bool bol = true;
            bol = Length.IsEqual(x, y);
            
            Console.WriteLine(bol);
            Console.WriteLine(x.ToString());
            Console.WriteLine(y.ValueToString());

            Console.ReadLine();
        }
        //Base x = new Base();
    }
}
