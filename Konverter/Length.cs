using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konverter
{
    /// <summary>
    /// Tumpuan untuk satuan panjang dengan instance default berupa meter, namun dapat diubah-ubah
    /// </summary>
    public class Length : IMeasurable<Length.ListSatuan>
    {
        #region constant declaration
        /// <summary>
        /// Epsilon, digunakan untuk membandingkan 2 bilangan real
        /// </summary>
        public const double EPS = 1e-9;

        /// <summary>
        /// Konstanta mengubah mile ke meter
        /// </summary>
        private const double cMile = 1609.34;

        /// <summary>
        /// Konstanta mengubah yard ke centimeter
        /// </summary>
        private const double cYard = 91.44;

        /// <summary>
        /// Konstanta mengubah feet ke centimeter
        /// </summary>
        private const double cFeet = 30.48;

        /// <summary>
        /// Konstanta mengubah inch ke centimeter
        /// </summary>
        private const double cInch = 2.54;
        #endregion

        #region satuan panjang yg didefinisikan
        /// <summary>
        /// satuan dari panjang
        /// </summary>
        public enum ListSatuan
        {
            picometer, 
            nanometer, 
            mikrometer, 
            milimeter, 
            centimeter, 
            desimeter, 
            meter, 
            dekameter, 
            hektometer, 
            kilometer, 
            feet, 
            miles, 
            yard, 
            inch
        }
        #endregion

        #region instance version

        private double _value;
        private ListSatuan _satuan;

        /// <summary>
        /// Get or Set satuan panjang
        /// </summary>
        public ListSatuan Satuan
        {
            get { return _satuan; }
            set
            {
                if (value != _satuan)
                {
                    _satuan = value;
                }
            }
        }

        /// <summary>
        /// Get atau Set nilai dari panjang
        /// </summary>
        public double Value
        {
            get { return _value; }
            set
            {
                if (value != _value)
                {
                    _value = value;
                }
            }
        }

        public Length()
        {
            _value = 0;
            _satuan = ListSatuan.meter;
        }

        /// <summary>
        /// Initialize Length dengan properti value awal bersatuan meter
        /// </summary>
        /// <param name="val">Nilai mula-mula dari satuan yang akan dikonversi</param>
        public Length(double val)
        {
            _value = val;
            _satuan = ListSatuan.meter;
        }

        /// <summary>
        /// Initialize Length dengan satuan yang ditentukan
        /// </summary>
        /// <param name="val">Nilai mula-mula dari satuan yang akan dikonversi</param>
        /// <param name="satuan">Satuan dari nilai mula-mula</param>
        public Length(double val, ListSatuan satuan)
        {
            _value = val;
            _satuan = satuan;
        }

        /// <summary>
        /// Cetak string nilai dari panjang beserta satuannya
        /// </summary>
        /// <returns>Nilai dari panjang dan satuannya</returns>
        public override string ToString()
        {
            return (Value.ToString() + " " + Satuan.ToString());
        }
  
        /// <summary>
        /// Ubah value ke bentuk string
        /// </summary>
        /// <returns>Nilai dari panjang dan satuannya</returns>
        public string ValueToString()
        {
            return (Value.ToString());
        }

        /// <summary>
        /// Konversi dari suatu satuan panjang ke satuan panjang yang lain
        /// </summary>
        /// <param name="tujuan">Satuan tujuan konversi</param>
        public void ConvertTo(ListSatuan tujuan)
        {
            Value = ConvertFrom(_value, Satuan, tujuan);
            Satuan = tujuan;
        }

        /// <summary>
        /// Membandingkan dengan objek lain
        /// </summary>
        /// <param name="obj">Object yang dibandingkan</param>
        /// <returns>membandingkan </returns>
        public override bool Equals(object obj)
        {
            if (obj is Length)
            {
                Length tmp = obj as Length;
                return Length.IsEqual(this, tmp);
            }
            else return false;
            
        }

        //public bool Equals(Length comparation)
        //{
        //    return Length.IsEqual(this, comparation);
        //}

        #endregion

        #region static version
        //buat perpangkatan
        private static double pangkat(double power)
        {
            return (double)Math.Pow(10, power);
        }

        /// <summary>
        /// Konversi panjang langsung panggil
        /// </summary>
        /// <param name="value">Nilai yang akan dikonversikan</param>
        /// <param name="awal">Satuan mula-mula</param>
        /// <param name="tujuan">Satuan tujuan konversi</param>
        /// <returns>Hasil konversi</returns>
        public static double ConvertFrom(double value, ListSatuan awal, ListSatuan tujuan)
        {
            double Value = value;
            try
            {
                switch (awal)
                {
                    #region dari picometer
                    case ListSatuan.picometer:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.nanometer:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.mikrometer:
                                    Value /= pangkat(6);
                                    break;
                                case ListSatuan.milimeter:
                                    Value /= pangkat(9);
                                    break;
                                case ListSatuan.centimeter:
                                    Value /= pangkat(10);
                                    break;
                                case ListSatuan.desimeter:
                                    Value /= pangkat(11);
                                    break;
                                case ListSatuan.meter:
                                    Value /= pangkat(12);
                                    break;
                                case ListSatuan.dekameter:
                                    Value /= pangkat(13);
                                    break;
                                case ListSatuan.hektometer:
                                    Value /= pangkat(14);
                                    break;
                                case ListSatuan.kilometer:
                                    Value /= pangkat(15);
                                    break;
                                case ListSatuan.feet:
                                    break;
                                case ListSatuan.miles:
                                    Value /= cMile * pangkat(12);
                                    break;
                                case ListSatuan.yard:
                                    break;
                                case ListSatuan.inch:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari nanometer
                    case ListSatuan.nanometer:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picometer:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.mikrometer:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.milimeter:
                                    Value /= pangkat(6);
                                    break;
                                case ListSatuan.centimeter:
                                    Value /= pangkat(7);
                                    break;
                                case ListSatuan.desimeter:
                                    Value /= pangkat(8);
                                    break;
                                case ListSatuan.meter:
                                    Value /= pangkat(9);
                                    break;
                                case ListSatuan.dekameter:
                                    Value /= pangkat(10);
                                    break;
                                case ListSatuan.hektometer:
                                    Value /= pangkat(11);
                                    break;
                                case ListSatuan.kilometer:
                                    Value /= pangkat(12);
                                    break;
                                case ListSatuan.feet:
                                    break;
                                case ListSatuan.miles:
                                    Value /= cMile * pangkat(9);
                                    break;
                                case ListSatuan.yard:
                                    break;
                                case ListSatuan.inch:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari mikrometer
                    case ListSatuan.mikrometer:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picometer:
                                    Value /= pangkat(-6);
                                    break;
                                case ListSatuan.nanometer:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.milimeter:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.centimeter:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.desimeter:
                                    Value /= pangkat(5);
                                    break;
                                case ListSatuan.meter:
                                    Value /= pangkat(6);
                                    break;
                                case ListSatuan.dekameter:
                                    Value /= pangkat(7);
                                    break;
                                case ListSatuan.hektometer:
                                    Value /= pangkat(8);
                                    break;
                                case ListSatuan.kilometer:
                                    Value /= pangkat(9);
                                    break;
                                case ListSatuan.feet:
                                    break;
                                case ListSatuan.miles:
                                    Value /= cMile * pangkat(6);
                                    break;
                                case ListSatuan.yard:
                                    break;
                                case ListSatuan.inch:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari milimeter
                    case ListSatuan.milimeter:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picometer:
                                    Value /= pangkat(-9);
                                    break;
                                case ListSatuan.nanometer:
                                    Value /= pangkat(-6);
                                    break;
                                case ListSatuan.mikrometer:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.centimeter:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.desimeter:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.meter:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.dekameter:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.hektometer:
                                    Value /= pangkat(5);
                                    break;
                                case ListSatuan.kilometer:
                                    Value /= pangkat(6);
                                    break;
                                case ListSatuan.feet:
                                    break;
                                case ListSatuan.miles:
                                    Value /= cMile * pangkat(3);
                                    break;
                                case ListSatuan.yard:
                                    break;
                                case ListSatuan.inch:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari centimeter
                    case ListSatuan.centimeter:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picometer:
                                    Value /= pangkat(-10);
                                    break;
                                case ListSatuan.nanometer:
                                    Value /= pangkat(-7);
                                    break;
                                case ListSatuan.mikrometer:
                                    Value /= pangkat(-4);
                                    break;
                                case ListSatuan.milimeter:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.desimeter:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.meter:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.dekameter:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.hektometer:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.kilometer:
                                    Value /= pangkat(5);
                                    break;
                                case ListSatuan.feet:
                                    break;
                                case ListSatuan.miles:
                                    Value /= cMile * pangkat(2);
                                    break;
                                case ListSatuan.yard:
                                    break;
                                case ListSatuan.inch:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari desimeter
                    case ListSatuan.desimeter:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picometer:
                                    Value /= pangkat(-11);
                                    break;
                                case ListSatuan.nanometer:
                                    Value /= pangkat(-8);
                                    break;
                                case ListSatuan.mikrometer:
                                    Value /= pangkat(-5);
                                    break;
                                case ListSatuan.milimeter:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.centimeter:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.meter:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.dekameter:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.hektometer:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.kilometer:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.feet:
                                    break;
                                case ListSatuan.miles:
                                    Value /= cMile * pangkat(1);
                                    break;
                                case ListSatuan.yard:
                                    break;
                                case ListSatuan.inch:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari meter
                    case ListSatuan.meter:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picometer:
                                    Value /= pangkat(-12);
                                    break;
                                case ListSatuan.nanometer:
                                    Value /= pangkat(-9);
                                    break;
                                case ListSatuan.mikrometer:
                                    Value /= pangkat(-6);
                                    break;
                                case ListSatuan.milimeter:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.centimeter:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.desimeter:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.dekameter:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.hektometer:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.kilometer:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.feet:
                                    break;
                                case ListSatuan.miles:
                                    Value /= cMile;
                                    break;
                                case ListSatuan.yard:
                                    break;
                                case ListSatuan.inch:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari dekameter
                    case ListSatuan.dekameter:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picometer:
                                    Value /= pangkat(-13);
                                    break;
                                case ListSatuan.nanometer:
                                    Value /= pangkat(-10);
                                    break;
                                case ListSatuan.mikrometer:
                                    Value /= pangkat(-7);
                                    break;
                                case ListSatuan.milimeter:
                                    Value /= pangkat(-4);
                                    break;
                                case ListSatuan.centimeter:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.desimeter:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.meter:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.hektometer:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.kilometer:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.feet:
                                    break;
                                case ListSatuan.miles:
                                    Value /= cMile * pangkat(-1);
                                    break;
                                case ListSatuan.yard:
                                    break;
                                case ListSatuan.inch:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari hektometer
                    case ListSatuan.hektometer:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picometer:
                                    Value /= pangkat(-14);
                                    break;
                                case ListSatuan.nanometer:
                                    Value /= pangkat(-11);
                                    break;
                                case ListSatuan.mikrometer:
                                    Value /= pangkat(-8);
                                    break;
                                case ListSatuan.milimeter:
                                    Value /= pangkat(-5);
                                    break;
                                case ListSatuan.centimeter:
                                    Value /= pangkat(-4);
                                    break;
                                case ListSatuan.desimeter:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.meter:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.dekameter:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.kilometer:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.feet:
                                    break;
                                case ListSatuan.miles:
                                    Value /= cMile * pangkat(-2);
                                    break;
                                case ListSatuan.yard:
                                    break;
                                case ListSatuan.inch:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari kilometer
                    case ListSatuan.kilometer:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picometer:
                                    Value /= pangkat(-15);
                                    break;
                                case ListSatuan.nanometer:
                                    Value /= pangkat(-12);
                                    break;
                                case ListSatuan.mikrometer:
                                    Value /= pangkat(-9);
                                    break;
                                case ListSatuan.milimeter:
                                    Value /= pangkat(-6);
                                    break;
                                case ListSatuan.centimeter:
                                    Value /= pangkat(-5);
                                    break;
                                case ListSatuan.desimeter:
                                    Value /= pangkat(-4);
                                    break;
                                case ListSatuan.meter:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.dekameter:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.hektometer:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.feet:
                                    break;
                                case ListSatuan.miles:
                                    Value /= cMile * pangkat(-3);
                                    break;
                                case ListSatuan.yard:
                                    break;
                                case ListSatuan.inch:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari feet
                    case ListSatuan.feet:
                        {
                            Value = value * cFeet;
                            switch (tujuan)
                            {
                                case ListSatuan.picometer:
                                    Value /= pangkat(-10);
                                    break;
                                case ListSatuan.nanometer:
                                    Value /= pangkat(-7);
                                    break;
                                case ListSatuan.mikrometer:
                                    Value /= pangkat(-4);
                                    break;
                                case ListSatuan.milimeter:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.centimeter:
                                    Value /= pangkat(0);
                                    break;
                                case ListSatuan.desimeter:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.meter:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.dekameter:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.hektometer:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.kilometer:
                                    Value /= pangkat(5);
                                    break;
                                case ListSatuan.miles:
                                    Value /= cMile * pangkat(2);
                                    break;
                                case ListSatuan.yard:
                                    break;
                                case ListSatuan.inch:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari mile
                    case ListSatuan.miles:
                        {
                            Value = value * cMile;
                            switch (tujuan)
                            {
                                case ListSatuan.picometer:
                                    Value /= pangkat(-12);
                                    break;
                                case ListSatuan.nanometer:
                                    Value /= pangkat(-9);
                                    break;
                                case ListSatuan.mikrometer:
                                    Value /= pangkat(-6);
                                    break;
                                case ListSatuan.milimeter:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.centimeter:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.desimeter:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.meter:
                                    Value /= pangkat(0);
                                    break;
                                case ListSatuan.dekameter:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.hektometer:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.kilometer:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.feet:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.yard:
                                    break;
                                case ListSatuan.inch:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari yard
                    case ListSatuan.yard:
                        {
                            Value = value * cYard;
                            switch (tujuan)
                            {
                                case ListSatuan.picometer:
                                    Value /= pangkat(-10);
                                    break;
                                case ListSatuan.nanometer:
                                    Value /= pangkat(-7);
                                    break;
                                case ListSatuan.mikrometer:
                                    Value /= pangkat(-4);
                                    break;
                                case ListSatuan.milimeter:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.centimeter:
                                    Value /= pangkat(0);
                                    break;
                                case ListSatuan.desimeter:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.meter:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.dekameter:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.hektometer:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.kilometer:
                                    Value /= pangkat(5);
                                    break;
                                case ListSatuan.miles:
                                    Value /= cMile * pangkat(2);
                                    break;
                                case ListSatuan.inch:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari inch
                    case ListSatuan.inch:
                        {
                            Value = value * cInch;
                            switch (tujuan)
                            {
                                case ListSatuan.picometer:
                                    Value /= pangkat(-10);
                                    break;
                                case ListSatuan.nanometer:
                                    Value /= pangkat(-7);
                                    break;
                                case ListSatuan.mikrometer:
                                    Value /= pangkat(-4);
                                    break;
                                case ListSatuan.milimeter:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.centimeter:
                                    Value /= pangkat(0);
                                    break;
                                case ListSatuan.desimeter:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.meter:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.dekameter:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.hektometer:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.kilometer:
                                    Value /= pangkat(5);
                                    break;
                                case ListSatuan.miles:
                                    Value /= cMile * pangkat(2);
                                    break;
                                case ListSatuan.yard:
                                    break;
                            }
                        }
                        break;
                    #endregion
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Value = 0;
            }
            return Value;
        }

        /// <summary>
        /// Membandingkan apakah instance Length bernilai sama atau beda
        /// </summary>
        /// <param name="a">Length pertama yang dibandingkan</param>
        /// <param name="b">Length kedua yang dibandingkan</param>
        /// <returns></returns>
        public static bool IsEqual(Length a, Length b)
        {
            if (a is Length && b is Length)
            {
                if (a.Satuan != b.Satuan)
                {
                    Length tmp = new Length(a.Value, a.Satuan);
                    tmp.ConvertTo(b.Satuan);

                    if (Math.Abs(tmp.Value - b.Value) < EPS) return true;
                    else return false;
                }
                else
                {
                    return (Math.Abs(a.Value - b.Value) < EPS);
                }
            }
            else throw new Exception("object harus sesuai dengan classnya");
        }

        #endregion
    }
}