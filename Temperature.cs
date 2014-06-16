using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konverter
{
    /// <summary>
    /// Tumpuan untuk satuan Temperature dengan instance default berupa celcius, namun dapat diubah-ubah
    /// </summary>
    public class Temperature : IMeasurable<Temperature.ListSatuan>
    {
        #region constant declaration
        /// <summary>
        /// Epsilon, digunakan untuk membandingkan 2 bilangan real
        /// </summary>
        public const double EPS = 1e-9;
        #endregion
        #region satuan suhu yang didefinisikan
        /// <summary>
        /// satuan dari suhu
        /// </summary>
        public enum ListSatuan
        {
            kelvin, 
            celcius, 
            reamur, 
            fahrenheit
        }
        #endregion

        #region instance version

        private double _value;
        private ListSatuan _satuan;

        ///<summary>
        ///Get or Set satuan temperature
        ///</summary>
        public ListSatuan Satuan
        {   
            get { return _satuan; }
            set
            {
                if(value != _satuan)
                {
                    _satuan = value;
                }
            }
        }

        ///<summary>
        /// Get atau Set nilai dari temperature
        ///</summary>
        public double Value{
            get { return _value; }
            set
            {
                if(value != _value)
                {
                    _value = value;
                }
            }
        }

        public Temperature()
        {
            _value = 0;
            _satuan = ListSatuan.celcius;
        }

        /// <summary>
        /// Initialize Temperature dengan properti value awal bersatuan celcius
        /// </summary>
        /// <param name="val">Nilai mula-mula dari satuan yang akan dikonversi</param>
        public Temperature (double val)
        {
            _value = val;
            _satuan = ListSatuan.celcius;
        }

        /// <summary>
        /// Initialize Temperature dengan satuan yang ditentukan
        /// </summary>
        /// <param name="val">Nilai mula-mula dari satuan yang akan dikonversi</param>
        /// <param name="satuan">Satuan dari nilai mula-mula</param>
        public Temperature(double val, ListSatuan satuan)
        {
            _value = val;
            _satuan = satuan;
        }

        /// <summary>
        /// Cetak string nilai dari temperature beserta satuannya
        /// </summary>
        /// <returns>Nilai dari temperature dan satuannya</returns>
        public override string ToString()
        {
            return (Value.ToString() + " " + Satuan.ToString());
        }

        ///<summary>
        /// Ubah value ke bentuk string
        ///</summary>
        /// <returns> Nilai dari temperature dan satuannya</returns>
        public string ValueToString()
        {
            return(Value.ToString());
        }

        /// <summary>
        /// Konversi dari suatu satuan temperature ke satuan suhu yang lain
        /// </summary>
        /// <param name="tujuan">Satuan tujuan konversi</param>
        public void ConvertTo(ListSatuan tujuan)
        {
            Value = ConvertFrom(Value, Satuan, tujuan);
            Satuan = tujuan;
        }

        /// <summary>
        /// Membandingkan dengan objek lain
        /// </summary>
        /// <param name="obj">Object yang dibandingkan</param>
        /// <returns>membandingkan </returns>
        public override bool Equals(object obj)
        {
            if (obj is Temperature)
            {
                Temperature tmp = obj as Temperature;
                return Temperature.IsEqual(this, tmp);
            }
            else return false;

        }
        
        #endregion

        #region static version
        
     
        /// <summary>
        /// Konversi suhu langsung panggil
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
                    #region dari celcius
                    case ListSatuan.celcius:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.kelvin:
                                    Value += 273;
                                    break;
                                case ListSatuan.reamur:
                                    Value = value * 4 / 5;
                                    break;
                                case ListSatuan.fahrenheit:
                                    Value = (value * 9 / 5) + 32;
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari kelvin
                    case ListSatuan.kelvin:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.celcius:
                                    Value -= 273;
                                    break;
                                case ListSatuan.reamur:
                                    Value = (value - 273) * 4 / 5;
                                    break;
                                case ListSatuan.fahrenheit:
                                    Value = ((value - 273) * 9 / 5) + 32;
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari reamur
                    case ListSatuan.reamur:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.celcius:
                                    Value = value * 5 / 4;
                                    break;
                                case ListSatuan.kelvin:
                                    Value = (value * 5 / 4) + 273;
                                    break;
                                case ListSatuan.fahrenheit:
                                    Value = (value * 9 / 4) + 32;
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari fahrenheit
                    case ListSatuan.fahrenheit:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.celcius:
                                    Value = (value - 32) * 5 / 9;
                                    break;
                                case ListSatuan.kelvin:
                                    Value = (value - 273 - 32) * 5 / 9;
                                    break;
                                case ListSatuan.reamur:
                                    Value = (value - 273) * 4 / 9;
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
        /// Membandingkan apakah instance Temperature bernilai sama atau beda
        /// </summary>
        /// <param name="a">Temperature pertama yang dibandingkan</param>
        /// <param name="b">Temperature kedua yang dibandingkan</param>
        /// <returns></returns>
        public static bool IsEqual(Temperature a, Temperature b)
        {
            if (a.Satuan != b.Satuan)
            {
                Temperature tmp = new Temperature(a.Value, a.Satuan);
                tmp.ConvertTo(b.Satuan);

                if (Math.Abs(tmp.Value - b.Value) < EPS) return true;
                else return false;
            }
            else
            {
                return (Math.Abs(a.Value - b.Value) < EPS);
            }
        }

        #endregion 
    }
}
