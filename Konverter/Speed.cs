using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konverter
{
    /// <summary>
    /// Tumpuan untuk satuan kecepatan dengan instance default berupa MeterPerSecond, namun dapat diubah-ubah
    /// </summary>
    public class Speed : IMeasurable<Speed.ListSatuan>
    {

        #region satuan kecepatan yang didefinisikan
        /// <summary>
        /// Satuan dari Kecepatan
        /// </summary>
        public enum ListSatuan
        {
            MeterPerSecond, MeterPerMinute, MeterPerHour, KilometerPerSecond, KilometerPerMinute, KilometerPerHour, MilePerHour, Knot, FeetPerSecond
        }
        #endregion

        #region deklarasi konstanta
        /// <summary>
        /// Epsilon, digunakan untuk membandingkan 2 bilangan real
        /// </summary>
        private const double EPS = 1e-9;

        /// <summary>
        /// mengubah 1 mile ke meter
        private const double cMile = 1609.34;

        /// <summary>
        ///  mengubah 1 knot ke meterpersecond
        /// </summary>
        private const double cKnot = 0.514444;

        /// <summary>
        /// mengubah 1 minute ke second
        /// </summary>
        private const double cMinute = 60;

        /// <summary>
        /// mengubah 1 hour ke second
        /// </summary>
        private const double cHour = 3600;

        /// <summary>
        /// mengubah 1 fts ke mps
        /// </summary>
        private const double fts = 0.3048;
        #endregion

        #region instance version

        private double _value;
        private ListSatuan _satuan;

        public Speed()
        {
            _value = 0;
            Satuan = ListSatuan.MeterPerSecond;
        }

        /// <summary>
        /// Initialize Velocity dengan properti value awal bersatuan MeterPerSecond
        /// </summary>
        /// <param name="value">Nilai mula-mula dari satuan yang akan dikonversi</param>
        public Speed(double val)
        {
            _value = val;
            Satuan = ListSatuan.MeterPerSecond;
        }

        /// <summary>
        /// Initialize Velocity dengan satuan yang ditentukan
        /// </summary>
        /// <param name="value">Nilai mula-mula dari satuan yang akan dikonversi</param>
        /// <param name="satuan">Satuan dari nilai mula-mula</param>
        public Speed(double val, ListSatuan satuan)
        {
            _value = val;
            Satuan = satuan;
        }

        /// <summary>
        /// Get or Set nilai dari kecepatan
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

        /// <summary>
        /// Get or Set satuan dari kecepatan
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
        /// Cetak string nilai dari kecepatan beserta satuannya
        /// </summary>
        /// <returns>Nilai dari kecepatan dan satuannya</returns>
        public string ValueToString()
        {
            return (Value.ToString() + " " + Satuan.ToString());
        }

        /// <summary>
        /// Konversi dari suatu satuan kecepatan ke satuan kecepatan yang lain
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
            Speed tmp = obj as Speed;
            return Speed.IsEqual(this, tmp);
        }

        #endregion
        
        #region static version
        ///// <summary>
        ///// Kalkulasi kecepatan
        ///// </summary>
        ///// <param name="length">panjang atau jarak</param>
        ///// <param name="time">waktu yang dilalui</param>
        ///// <returns>Velocity</returns>
        //public static Speed Calculate(Length length, Time time)
        //{
        //    Length tmpL = length;
        //    Time tmpT = time;
        //    tmpL.ConvertTo(Length.ListSatuan.meter);
        //    tmpT.ConvertTo(Time.ListSatuan.Seconds);

        //    return new Speed(tmpL.Value / tmpT.Value);
        //}

        //buat perpangkatan
        private static double pangkat(double power)
        {
            return (double)Math.Pow(10, power);
        }

        public static double ConvertFrom(double value, ListSatuan awal, ListSatuan tujuan)
        {
            double Value = value;
            try
            {
                switch (awal)
                {
                    #region dari MeterPerSecond
                    case ListSatuan.MeterPerSecond:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.MeterPerMinute:
                                    Value *= cMinute;
                                    break;
                                case ListSatuan.MeterPerHour:
                                    Value *= cHour;
                                    break;
                                case ListSatuan.KilometerPerSecond:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.KilometerPerMinute:
                                    Value *= cMinute * pangkat(-3);
                                    break;
                                case ListSatuan.KilometerPerHour:
                                    Value *= cHour * pangkat(-3);
                                    break;
                                case ListSatuan.MilePerHour:
                                    Value *= cHour / cMile;
                                    break;
                                case ListSatuan.Knot:
                                    Value /= cKnot;
                                    break;
                                case ListSatuan.FeetPerSecond:
                                    Value /= fts;
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari MeterPerMinute
                    case ListSatuan.MeterPerMinute:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.MeterPerSecond:
                                    Value /= cMinute;
                                    break;
                                case ListSatuan.MeterPerHour:
                                    Value *= cMinute;
                                    break;
                                case ListSatuan.KilometerPerSecond:
                                    Value /= pangkat(3) / cMinute;
                                    break;
                                case ListSatuan.KilometerPerMinute:
                                    Value *= pangkat(-3);
                                    break;
                                case ListSatuan.KilometerPerHour:
                                    Value *= cMinute * pangkat(-3);
                                    break;
                                case ListSatuan.MilePerHour:
                                    Value *= cMinute / cMile;
                                    break;
                                case ListSatuan.Knot:
                                    Value /= cKnot / cMinute;
                                    break;
                                case ListSatuan.FeetPerSecond:
                                    Value /= fts / cMinute;
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari MeterPerHour
                    case ListSatuan.MeterPerHour:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.MeterPerSecond:
                                    Value /= cHour;
                                    break;
                                case ListSatuan.MeterPerMinute:
                                    Value /= cMinute;
                                    break;
                                case ListSatuan.KilometerPerSecond:
                                    Value *= pangkat(-3) / cHour;
                                    break;
                                case ListSatuan.KilometerPerMinute:
                                    Value *= pangkat(-3) / cMinute;
                                    break;
                                case ListSatuan.KilometerPerHour:
                                    Value *= pangkat(-3);
                                    break;
                                case ListSatuan.MilePerHour:
                                    Value /= cMile;
                                    break;
                                case ListSatuan.Knot:
                                    Value /= cKnot / cHour;
                                    break;
                                case ListSatuan.FeetPerSecond:
                                    Value /= fts / cHour;
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari KilometerPerSecond
                    case ListSatuan.KilometerPerSecond:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.MeterPerSecond:
                                    Value *= pangkat(3);
                                    break;
                                case ListSatuan.MeterPerMinute:
                                    Value *= pangkat(3) * cMinute;
                                    break;
                                case ListSatuan.MeterPerHour:
                                    Value *= pangkat(3) * cHour;
                                    break;
                                case ListSatuan.KilometerPerMinute:
                                    Value *= cMinute;
                                    break;
                                case ListSatuan.KilometerPerHour:
                                    Value *= cHour;
                                    break;
                                case ListSatuan.MilePerHour:
                                    Value /= cMile * pangkat(3) * cHour;
                                    break;
                                case ListSatuan.Knot:
                                    Value /= cKnot * pangkat(3);
                                    break;
                                case ListSatuan.FeetPerSecond:
                                    Value /= fts * pangkat(3);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari KilometerPerMinute
                    case ListSatuan.KilometerPerMinute:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.MeterPerSecond:
                                    Value *= pangkat(3) / cMinute;
                                    break;
                                case ListSatuan.MeterPerMinute:
                                    Value *= pangkat(3);
                                    break;
                                case ListSatuan.MeterPerHour:
                                    Value *= pangkat(3) * cMinute;
                                    break;
                                case ListSatuan.KilometerPerSecond:
                                    Value /= cMinute;
                                    break;
                                case ListSatuan.KilometerPerHour:
                                    Value *= cMinute;
                                    break;
                                case ListSatuan.MilePerHour:
                                    Value /= cMile * pangkat(3) * cMinute;
                                    break;
                                case ListSatuan.Knot:
                                    Value /= cKnot * pangkat(3) / cMinute;
                                    break;
                                case ListSatuan.FeetPerSecond:
                                    Value /= fts * pangkat(3) / cMinute;
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari KilometerPerHour
                    case ListSatuan.KilometerPerHour:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.MeterPerSecond:
                                    Value *= pangkat(3) / cHour;
                                    break;
                                case ListSatuan.MeterPerMinute:
                                    Value *= pangkat(3) / cMinute;
                                    break;
                                case ListSatuan.MeterPerHour:
                                    Value *= pangkat(3);
                                    break;
                                case ListSatuan.KilometerPerSecond:
                                    Value /= cHour;
                                    break;
                                case ListSatuan.KilometerPerMinute:
                                    Value /= cMinute;
                                    break;
                                case ListSatuan.MilePerHour:
                                    Value /= cMile * pangkat(3);
                                    break;
                                case ListSatuan.Knot:
                                    Value /= cKnot * pangkat(3) / cHour;
                                    break;
                                case ListSatuan.FeetPerSecond:
                                    Value /= fts * pangkat(3) / cHour;
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari MilePerHour
                    case ListSatuan.MilePerHour:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.MeterPerSecond:
                                    Value *= cMile / cHour;
                                    break;
                                case ListSatuan.MeterPerMinute:
                                    Value *= cMile / cMinute;
                                    break;
                                case ListSatuan.MeterPerHour:
                                    Value *= cMile;
                                    break;
                                case ListSatuan.KilometerPerSecond:
                                    Value *= cMile / pangkat(3) / cHour ;
                                    break;
                                case ListSatuan.KilometerPerMinute:
                                    Value *= cMile / pangkat(3) / cMinute;
                                    break;
                                case ListSatuan.KilometerPerHour:
                                    Value *= cMile * pangkat(3);
                                    break;
                                case ListSatuan.Knot:
                                    Value *= cMile / cKnot / cHour;
                                    break;
                                case ListSatuan.FeetPerSecond:
                                    Value *= cMile / cHour / fts;
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari Knot
                    case ListSatuan.Knot:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.MeterPerSecond:
                                    Value *= cKnot;
                                    break;
                                case ListSatuan.MeterPerMinute:
                                    Value *= cKnot * cMinute;
                                    break;
                                case ListSatuan.MeterPerHour:
                                    Value *= cKnot * cHour;
                                    break;
                                case ListSatuan.KilometerPerSecond:
                                    Value *= cKnot / pangkat(3);
                                    break;
                                case ListSatuan.KilometerPerMinute:
                                    Value *= cKnot / pangkat(3) * cMinute;
                                    break;
                                case ListSatuan.KilometerPerHour:
                                    Value *= cMile / pangkat(3) * cHour;
                                    break;
                                case ListSatuan.MilePerHour:
                                    Value *= cKnot / cMile * cHour;
                                    break;
                                case ListSatuan.FeetPerSecond:
                                    Value *= cKnot / fts;
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari FeetPerSecond
                    case ListSatuan.FeetPerSecond:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.MeterPerSecond:
                                    Value *= fts;
                                    break;
                                case ListSatuan.MeterPerMinute:
                                    Value *= fts * cMinute;
                                    break;
                                case ListSatuan.MeterPerHour:
                                    Value *= fts * cHour;
                                    break;
                                case ListSatuan.KilometerPerSecond:
                                    Value *= fts / pangkat(3);
                                    break;
                                case ListSatuan.KilometerPerMinute:
                                    Value *= fts / pangkat(3) * cMinute;
                                    break;
                                case ListSatuan.KilometerPerHour:
                                    Value *= fts / pangkat(3) * cHour;
                                    break;
                                case ListSatuan.MilePerHour:
                                    Value *= fts / cMile * cHour;
                                    break;
                                case ListSatuan.Knot:
                                    Value *= fts / cKnot;
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
        /// Membandingkan apakah instance Speed bernilai sama atau beda
        /// </summary>
        /// <param name="a">Speed pertama yang dibandingkan</param>
        /// <param name="b">Speed kedua yang dibandingkan</param>
        /// <returns></returns>
        public static bool IsEqual(Speed a, Speed b)
        {
            if (a is Speed && b is Speed)
            {
                if (a.Satuan != b.Satuan)
                {
                    Speed tmp = new Speed(a.Value, a.Satuan);
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
