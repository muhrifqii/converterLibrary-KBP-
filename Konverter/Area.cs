using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konverter
{
    /// <summary>
    /// Tumpuan untuk satuan luas dengan instance default berupa meter2, namun dapat diubah-ubah
    /// </summary>
    public class Area : IMeasurable<Area.LisSatuan>
    {
        #region constant declaration
        /// <summary>
        /// Epsilon, digunakan untuk membandingkan 2 bilangan real
        /// </summary>
        private const double EPS = 1e-9;
        #endregion

        #region satuan luas yg didefinisikan
        /// <summary>
        /// satuan dari luas
        /// </summary>
        public enum LisSatuan
        {
            picometer2, nanometer2, mikrometer2, milimeter2, centimeter2, desimeter2, meter2, dekameter2, hektometer2, kilometer2
        }
        #endregion

        #region instance version

        private double _value;
        private LisSatuan _satuan;

        /// <summary>
        /// Get or Set satuan luas
        /// </summary>
        public LisSatuan Satuan
        {
            get { return _satuan; }
            set
            {
                if (_satuan != value) _satuan = value;
            }
        }

        /// <summary>
        /// Get or Set nilai dari luas
        /// </summary>
        public double Value
        {
            get { return _value; }
            set
            {
                if (value != value) _value = value;
            }
        }

        public Area()
        {
            _satuan = LisSatuan.meter2;
            _value = 0;
        }
        /// <summary>
        /// Initialize Area dengan properti value awal bersatuan meter2
        /// </summary>
        /// <param name="val">Nilai mula-mula dari satuan yang akan dikonversi</param>
        public Area(double val)
        {
            _value = val;
            _satuan = LisSatuan.meter2;
        }
        /// <summary>
        /// Initialize Area dengan satuan yang ditentukan
        /// </summary>
        /// <param name="val">Nilai mula-mula dari satuan yang akan dikonversi</param>
        /// <param name="satuan">Satuan dari nilai mula-mula</param>
        public Area(double val, LisSatuan satuan)
        {
            _value = val;
            _satuan = satuan;
        }

        /// <summary>
        /// Konversi dari suatu satuan luas ke satuan luas yang lain
        /// </summary>
        /// <param name="tujuan">Satuan tujuan konversi</param>
        public void ConvertTo(LisSatuan tujuan)
        {
            Value = ConvertFrom(Value, Satuan, tujuan);
            Satuan = tujuan;
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
        /// Membandingkan dengan objek lain
        /// </summary>
        /// <param name="obj">Object yang dibandingkan</param>
        /// <returns>membandingkan </returns>
        public override bool Equals(object obj)
        {
            if (obj is Length)
            {
                Area tmp = obj as Area;
                return Area.IsEqual(this, tmp);
            }
            else return false;

        }

        #endregion

        #region static version
        //buat perpangkatan
        private static double pangkat(double power)
        {
            return (double)Math.Pow(100, power);
        }

        /// <summary>
        /// Konversi luas langsung panggil
        /// </summary>
        /// <param name="value">Nilai yang akan dikonversikan</param>
        /// <param name="awal">Satuan mula-mula</param>
        /// <param name="tujuan">Satuan tujuan konversi</param>
        /// <returns>Hasil konversi</returns>
        public static double ConvertFrom(double value, LisSatuan awal, LisSatuan tujuan)
        {
            double Value = value;
            try
            {
                switch (awal)
                {
                    #region dari picometer2
                    case LisSatuan.picometer2:
                        {
                            switch (tujuan)
                            {
                                case LisSatuan.nanometer2:
                                    Value /= pangkat(6);
                                    break;
                                case LisSatuan.mikrometer2:
                                    Value /= pangkat(12);
                                    break;
                                case LisSatuan.milimeter2:
                                    Value /= pangkat(18);
                                    break;
                                case LisSatuan.centimeter2:
                                    Value /= pangkat(20);
                                    break;
                                case LisSatuan.desimeter2:
                                    Value /= pangkat(22);
                                    break;
                                case LisSatuan.meter2:
                                    Value /= pangkat(24);
                                    break;
                                case LisSatuan.dekameter2:
                                    Value /= pangkat(26);
                                    break;
                                case LisSatuan.hektometer2:
                                    Value /= pangkat(28);
                                    break;
                                case LisSatuan.kilometer2:
                                    Value /= pangkat(30);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari nanometer2
                    case LisSatuan.nanometer2:
                        {
                            switch (tujuan)
                            {
                                case LisSatuan.picometer2:
                                    Value /= pangkat(-6);
                                    break;
                                case LisSatuan.mikrometer2:
                                    Value /= pangkat(6);
                                    break;
                                case LisSatuan.milimeter2:
                                    Value /= pangkat(12);
                                    break;
                                case LisSatuan.centimeter2:
                                    Value /= pangkat(14);
                                    break;
                                case LisSatuan.desimeter2:
                                    Value /= pangkat(16);
                                    break;
                                case LisSatuan.meter2:
                                    Value /= pangkat(18);
                                    break;
                                case LisSatuan.dekameter2:
                                    Value /= pangkat(20);
                                    break;
                                case LisSatuan.hektometer2:
                                    Value /= pangkat(22);
                                    break;
                                case LisSatuan.kilometer2:
                                    Value /= pangkat(24);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari mikrometer2
                    case LisSatuan.mikrometer2:
                        {
                            switch (tujuan)
                            {
                                case LisSatuan.picometer2:
                                    Value /= pangkat(-12);
                                    break;
                                case LisSatuan.nanometer2:
                                    Value /= pangkat(-6);
                                    break;
                                case LisSatuan.milimeter2:
                                    Value /= pangkat(6);
                                    break;
                                case LisSatuan.centimeter2:
                                    Value /= pangkat(8);
                                    break;
                                case LisSatuan.desimeter2:
                                    Value /= pangkat(10);
                                    break;
                                case LisSatuan.meter2:
                                    Value /= pangkat(12);
                                    break;
                                case LisSatuan.dekameter2:
                                    Value /= pangkat(14);
                                    break;
                                case LisSatuan.hektometer2:
                                    Value /= pangkat(16);
                                    break;
                                case LisSatuan.kilometer2:
                                    Value /= pangkat(18);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari milimeter2
                    case LisSatuan.milimeter2:
                        {
                            switch (tujuan)
                            {
                                case LisSatuan.picometer2:
                                    Value /= pangkat(-18);
                                    break;
                                case LisSatuan.nanometer2:
                                    Value /= pangkat(-12);
                                    break;
                                case LisSatuan.mikrometer2:
                                    Value /= pangkat(-6);
                                    break;
                                case LisSatuan.centimeter2:
                                    Value /= pangkat(2);
                                    break;
                                case LisSatuan.desimeter2:
                                    Value /= pangkat(4);
                                    break;
                                case LisSatuan.meter2:
                                    Value /= pangkat(6);
                                    break;
                                case LisSatuan.dekameter2:
                                    Value /= pangkat(8);
                                    break;
                                case LisSatuan.hektometer2:
                                    Value /= pangkat(10);
                                    break;
                                case LisSatuan.kilometer2:
                                    Value /= pangkat(12);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari centimeter2
                    case LisSatuan.centimeter2:
                        {
                            switch (tujuan)
                            {
                                case LisSatuan.picometer2:
                                    Value /= pangkat(-20);
                                    break;
                                case LisSatuan.nanometer2:
                                    Value /= pangkat(-14);
                                    break;
                                case LisSatuan.mikrometer2:
                                    Value /= pangkat(-8);
                                    break;
                                case LisSatuan.milimeter2:
                                    Value /= pangkat(-2);
                                    break;
                                case LisSatuan.desimeter2:
                                    Value /= pangkat(2);
                                    break;
                                case LisSatuan.meter2:
                                    Value /= pangkat(4);
                                    break;
                                case LisSatuan.dekameter2:
                                    Value /= pangkat(6);
                                    break;
                                case LisSatuan.hektometer2:
                                    Value /= pangkat(8);
                                    break;
                                case LisSatuan.kilometer2:
                                    Value /= pangkat(10);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari desimeter2
                    case LisSatuan.desimeter2:
                        {
                            switch (tujuan)
                            {
                                case LisSatuan.picometer2:
                                    Value /= pangkat(-22);
                                    break;
                                case LisSatuan.nanometer2:
                                    Value /= pangkat(-16);
                                    break;
                                case LisSatuan.mikrometer2:
                                    Value /= pangkat(-10);
                                    break;
                                case LisSatuan.milimeter2:
                                    Value /= pangkat(-4);
                                    break;
                                case LisSatuan.centimeter2:
                                    Value /= pangkat(-2);
                                    break;
                                case LisSatuan.meter2:
                                    Value /= pangkat(2);
                                    break;
                                case LisSatuan.dekameter2:
                                    Value /= pangkat(4);
                                    break;
                                case LisSatuan.hektometer2:
                                    Value /= pangkat(6);
                                    break;
                                case LisSatuan.kilometer2:
                                    Value /= pangkat(8);
                                    break;
                                //case Satuan.feet:
                                //    break;
                                //case Satuan.miles:
                                //    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari meter2
                    case LisSatuan.meter2:
                        {
                            switch (tujuan)
                            {
                                case LisSatuan.picometer2:
                                    Value /= pangkat(-24);
                                    break;
                                case LisSatuan.nanometer2:
                                    Value /= pangkat(-18);
                                    break;
                                case LisSatuan.mikrometer2:
                                    Value /= pangkat(-12);
                                    break;
                                case LisSatuan.milimeter2:
                                    Value /= pangkat(-6);
                                    break;
                                case LisSatuan.centimeter2:
                                    Value /= pangkat(-4);
                                    break;
                                case LisSatuan.desimeter2:
                                    Value /= pangkat(-2);
                                    break;
                                case LisSatuan.dekameter2:
                                    Value /= pangkat(2);
                                    break;
                                case LisSatuan.hektometer2:
                                    Value /= pangkat(4);
                                    break;
                                case LisSatuan.kilometer2:
                                    Value /= pangkat(6);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari dekameter2
                    case LisSatuan.dekameter2:
                        {
                            switch (tujuan)
                            {
                                case LisSatuan.picometer2:
                                    Value /= pangkat(-26);
                                    break;
                                case LisSatuan.nanometer2:
                                    Value /= pangkat(-20);
                                    break;
                                case LisSatuan.mikrometer2:
                                    Value /= pangkat(-14);
                                    break;
                                case LisSatuan.milimeter2:
                                    Value /= pangkat(-8);
                                    break;
                                case LisSatuan.centimeter2:
                                    Value /= pangkat(-6);
                                    break;
                                case LisSatuan.desimeter2:
                                    Value /= pangkat(-4);
                                    break;
                                case LisSatuan.meter2:
                                    Value /= pangkat(-2);
                                    break;
                                case LisSatuan.hektometer2:
                                    Value /= pangkat(2);
                                    break;
                                case LisSatuan.kilometer2:
                                    Value /= pangkat(4);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari hektometer2
                    case LisSatuan.hektometer2:
                        {
                            switch (tujuan)
                            {
                                case LisSatuan.picometer2:
                                    Value /= pangkat(-28);
                                    break;
                                case LisSatuan.nanometer2:
                                    Value /= pangkat(-22);
                                    break;
                                case LisSatuan.mikrometer2:
                                    Value /= pangkat(-16);
                                    break;
                                case LisSatuan.milimeter2:
                                    Value /= pangkat(-10);
                                    break;
                                case LisSatuan.centimeter2:
                                    Value /= pangkat(-8);
                                    break;
                                case LisSatuan.desimeter2:
                                    Value /= pangkat(-6);
                                    break;
                                case LisSatuan.meter2:
                                    Value /= pangkat(-4);
                                    break;
                                case LisSatuan.dekameter2:
                                    Value /= pangkat(-2);
                                    break;
                                case LisSatuan.kilometer2:
                                    Value /= pangkat(2);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari kilometer2
                    case LisSatuan.kilometer2:
                        {
                            switch (tujuan)
                            {
                                case LisSatuan.picometer2:
                                    Value /= pangkat(-30);
                                    break;
                                case LisSatuan.nanometer2:
                                    Value /= pangkat(-24);
                                    break;
                                case LisSatuan.mikrometer2:
                                    Value /= pangkat(-18);
                                    break;
                                case LisSatuan.milimeter2:
                                    Value /= pangkat(12);
                                    break;
                                case LisSatuan.centimeter2:
                                    Value /= pangkat(-10);
                                    break;
                                case LisSatuan.desimeter2:
                                    Value /= pangkat(-8);
                                    break;
                                case LisSatuan.meter2:
                                    Value /= pangkat(-6);
                                    break;
                                case LisSatuan.dekameter2:
                                    Value /= pangkat(-4);
                                    break;
                                case LisSatuan.kilometer2:
                                    Value /= pangkat(-2);
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
        public static bool IsEqual(Area a, Area b)
        {
            if (a is Area && b is Area)
            {
                if (a.Satuan != b.Satuan)
                {
                    Area tmp = new Area(a.Value, a.Satuan);
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

        ///// <summary>
        ///// Membuat Luas dari dua class Length
        ///// </summary>
        ///// <param name="length1">length acuan pertama</param>
        ///// <param name="length2">length acuan kedua</param>
        ///// <param name="ListSatuan">satuan luas yang diinginkan</param>
        ///// <returns>Area baru yang didapat</returns>
        //public static Area CalculateFrom(Length length1, Length length2, LisSatuan satuan)
        //{
        //    Area areaBaru;

        //    if (length1.Satuan == length2.Satuan)
        //    {
        //        areaBaru = new Area(length1.Value * length2.Value, length1.Satuan);
        //        areaBaru.ConvertTo(satuan);
        //    }
        //    else
        //    {
        //        Length tmp = new Length(length1.Value, length1.Satuan);
        //        tmp.ConvertTo(length2.Satuan);

        //        areaBaru = new Area(tmp.Value * length2.Value, length2.Satuan);
        //        areaBaru.ConvertTo(satuan);
        //    }

        //    return areaBaru;
        //}

        ///// <summary>
        ///// Membuat Luas dari panjang sisi nya
        ///// </summary>
        ///// <param name="value1">sisi pertama</param>
        ///// <param name="value2">sisi kedua</param>
        ///// <param name="satuan1">satuan sisi pertama</param>
        ///// <param name="satuan2">satuan sisi kedua</param>
        ///// <param name="satuanLuas">satuan luas yang diinginkan</param>
        ///// <returns></returns>
        //public static Area CalculateFrom(double value1, double value2, Length.ListSatuan satuan1, Length.ListSatuan satuan2, LisSatuan satuanLuas)
        //{
        //    Area areaBaru;

        //    if (satuan1 == satuan2)
        //    {
        //        areaBaru = new Area(value1 * value2, satuan1);
        //        areaBaru.ConvertTo(satuanLuas);
        //    }
        //    else
        //    {
        //        Length tmp1 = new Length(value1, satuan1);
        //        Length tmp2 = new Length(value2, satuan2);

        //        areaBaru = new Area(tmp1.Value * tmp2.Value, length2.Satuan);
        //        areaBaru.ConvertTo(satuan);
        //    }

        //    return areaBaru;
        //}

        #endregion
    }
}