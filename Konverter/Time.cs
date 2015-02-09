using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konverter
{
    /// <summary>
    /// Tumpuan untuk satuan waktu dengan instance default berupa second, namun dapat diubah-ubah
    /// </summary>
    public class Time : IMeasurable<Time.ListSatuan>
    {
        #region constant declaration
        /// <summary>
        /// Epsilon, digunakan untuk membandingkan 2 bilangan real
        /// </summary>
        public const double EPS = 1e-9;

        #endregion

        #region satuan waktu yang didefinisikan
        /// <summary>
        /// Satuan dari waktu
        /// </summary>
        public enum ListSatuan
        {
            miliseconds, Seconds, Minutes, Hours
        }
        #endregion

        #region instance version

        private double _value;
        private ListSatuan _satuan;

        public Time()
        {
            _value = 0;
            Satuan = ListSatuan.Seconds;
        }

        /// <summary>
        /// Initialize Time dengan properti awal bersatuan second
        /// </summary>
        /// <param name="val">Nilai mula-mula dari satuan yang akan dikonversi</param>
        public Time(double val)
        {
            _value = val;
            _satuan = ListSatuan.Seconds;
        }

        /// <summary>
        /// Initialize Time dengan satuan yang ditentukan
        /// </summary>
        /// <param name="val">Nilai mula-mula dari satuan yang akan dikonversi</param>
        /// <param name="satuan">Satuan dari nilai mula-mula</param>
        public Time(double val, ListSatuan satuan)
        {
            _value = val;
            _satuan = satuan;
        }

        /// <summary>
        /// Get or Set satuan waktu
        /// </summary>
        public ListSatuan Satuan
        {
            get { return _satuan; }
            set
            {
                if (value != _satuan) _satuan = value; 
            }
        }

        /// <summary>
        /// Get or Set nilai dari waktu
        /// </summary>
        public double Value
        {
            get { return _value; }
            set
            {
                if (value != _value) _value = value;
            }
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
        /// <returns>Nilai dari waktu dan satuannya</returns>
        public string ValueToString()
        {
            return (Value.ToString());
        }

        /// <summary>
        /// Konversi dari suatu satuan waktu ke satuan waktu yang lain
        /// </summary>
        /// <param name="tujuan">Satuan tujuan konversi</param>
        public void ConvertTo(ListSatuan tujuan)
        {
            _value = ConvertFrom(Value, Satuan, tujuan);
            _satuan = tujuan;
        }

        /// <summary>
        /// Membandingkan dengan objek lain
        /// </summary>
        /// <param name="obj">Object yang dibandingkan</param>
        /// <returns>membandingkan </returns>
        public override bool Equals(object obj)
        {
            if (obj is Time)
            {
                Time tmp = obj as Time;
                return Time.IsEqual(this, tmp);
            }
            else return false;

        }

        #endregion

        #region static version
        /// <summary>
        /// Konversi waktu langsung panggil
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
                    #region dari milisecond
                    case ListSatuan.miliseconds:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.Seconds:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.Minutes:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.Hours:
                                    Value /= pangkat(3);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari second
                    case ListSatuan.Seconds:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.miliseconds:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.Minutes:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.Hours:
                                    Value /= pangkat(2);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari minute
                    case ListSatuan.Minutes:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.miliseconds:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.Seconds:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.Hours:
                                    Value /= pangkat(1);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari hour
                    case ListSatuan.Hours:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.miliseconds:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.Seconds:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.Minutes:
                                    Value /= pangkat(-1);
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
            }
            return Value;
        }

        //buat perpangkatan
        private static double pangkat(double power)
        {
            return (double)Math.Pow(60, power);
        }

        /// <summary>
        /// Membandingkan apakah instance Time bernilai sama atau beda
        /// </summary>
        /// <param name="a">Time pertama yang dibandingkan</param>
        /// <param name="b">Time kedua yang dibandingkan</param>
        /// <returns></returns>
        public static bool IsEqual(Time a, Time b)
        {
            if (a is Time && b is Time)
            {
                if (a.Satuan != b.Satuan)
                {
                    Time tmp = new Time(a.Value, a.Satuan);
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
