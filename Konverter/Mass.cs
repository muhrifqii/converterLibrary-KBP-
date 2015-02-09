using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konverter
{
    /// <summary>
    /// Tumpuan untuk satuan massa dengan instance default berupa kilogram, namun dapat diubah-ubah
    /// </summary>
    public class Mass : IMeasurable<Mass.ListSatuan>
    {
        #region satuan massa yg didefinisikan
        /// <summary>
        /// satuan dari massa
        /// </summary>
        public enum ListSatuan
        {
            picogram, nanogram, mikrogram, miligram, centigram, desigram, gram, dekagram, hektogram, kilogram, pound, ons
        }
        #endregion

        #region instance version
        public Mass()
        {
            Satuan = ListSatuan.kilogram;
        }

        /// <summary>
        /// Initialize Mass dengan properti awal bersatuan gram
        /// </summary>
        /// <param name="val">Nilai mula-mula dari satuan yang akan dikonversi</param>
        public Mass(double val)
        {
            Value = val;
            Satuan = ListSatuan.kilogram;
        }

        /// <summary>
        /// Initialize Mass dengan satuan yang ditentukan
        /// </summary>
        /// <param name="val">Nilai mula-mula dari satuan yang akan dikonversi</param>
        /// <param name="satuan">Satuan dari nilai mula-mula</param>
        public Mass(double val, ListSatuan satuan)
        {
            Value = val;
            Satuan = satuan;
        }

        /// <summary>
        /// Get or Set satuan massa
        /// </summary>
        public ListSatuan Satuan { get; set; }

        /// <summary>
        /// Get or Set nilai dari massa
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Cetak string nilai dari massa beserta satuannya
        /// </summary>
        /// <returns>Nilai dari massa dan satuannya</returns>
        public string ValueToString()
        {
            return (Value.ToString() + " " + Satuan.ToString());
        }

        /// <summary>
        /// Konversi dari suatu satuan massa ke satuan massa yang lain
        /// </summary>
        /// <param name="tujuan">Satuan tujuan konversi</param>
        public void ConvertTo(ListSatuan tujuan)
        {
            Value = ConvertFrom(Value, Satuan, tujuan);
            Satuan = tujuan;
        }
        #endregion

        #region static version
        /// <summary>
        /// Konversi massa langsung panggil
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
                    #region dari picogram
                    case ListSatuan.picogram:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.nanogram:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.mikrogram:
                                    Value /= pangkat(6);
                                    break;
                                case ListSatuan.miligram:
                                    Value /= pangkat(9);
                                    break;
                                case ListSatuan.centigram:
                                    Value /= pangkat(10);
                                    break;
                                case ListSatuan.desigram:
                                    Value /= pangkat(11);
                                    break;
                                case ListSatuan.gram:
                                    Value /= pangkat(12);
                                    break;
                                case ListSatuan.dekagram:
                                    Value /= pangkat(13);
                                    break;
                                case ListSatuan.hektogram:
                                    Value /= pangkat(14);
                                    break;
                                case ListSatuan.kilogram:
                                    Value /= pangkat(15);
                                    break;
                                case ListSatuan.pound:
                                    break;
                                case ListSatuan.ons:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari nanogram
                    case ListSatuan.nanogram:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picogram:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.mikrogram:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.miligram:
                                    Value /= pangkat(6);
                                    break;
                                case ListSatuan.centigram:
                                    Value /= pangkat(7);
                                    break;
                                case ListSatuan.desigram:
                                    Value /= pangkat(8);
                                    break;
                                case ListSatuan.gram:
                                    Value /= pangkat(9);
                                    break;
                                case ListSatuan.dekagram:
                                    Value /= pangkat(10);
                                    break;
                                case ListSatuan.hektogram:
                                    Value /= pangkat(11);
                                    break;
                                case ListSatuan.kilogram:
                                    Value /= pangkat(12);
                                    break;
                                case ListSatuan.pound:
                                    break;
                                case ListSatuan.ons:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari mikrogram
                    case ListSatuan.mikrogram:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picogram:
                                    Value /= pangkat(-6);
                                    break;
                                case ListSatuan.nanogram:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.miligram:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.centigram:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.desigram:
                                    Value /= pangkat(5);
                                    break;
                                case ListSatuan.gram:
                                    Value /= pangkat(6);
                                    break;
                                case ListSatuan.dekagram:
                                    Value /= pangkat(7);
                                    break;
                                case ListSatuan.hektogram:
                                    Value /= pangkat(8);
                                    break;
                                case ListSatuan.kilogram:
                                    Value /= pangkat(9);
                                    break;
                                case ListSatuan.pound:
                                    break;
                                case ListSatuan.ons:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari miligram
                    case ListSatuan.miligram:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picogram:
                                    Value /= pangkat(-9);
                                    break;
                                case ListSatuan.nanogram:
                                    Value /= pangkat(-6);
                                    break;
                                case ListSatuan.mikrogram:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.centigram:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.desigram:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.gram:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.dekagram:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.hektogram:
                                    Value /= pangkat(5);
                                    break;
                                case ListSatuan.kilogram:
                                    Value /= pangkat(6);
                                    break;
                                case ListSatuan.pound:
                                    break;
                                case ListSatuan.ons:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari centigram
                    case ListSatuan.centigram:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picogram:
                                    Value /= pangkat(-10);
                                    break;
                                case ListSatuan.nanogram:
                                    Value /= pangkat(-7);
                                    break;
                                case ListSatuan.mikrogram:
                                    Value /= pangkat(-4);
                                    break;
                                case ListSatuan.miligram:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.desigram:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.gram:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.dekagram:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.hektogram:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.kilogram:
                                    Value /= pangkat(5);
                                    break;
                                case ListSatuan.pound:
                                    break;
                                case ListSatuan.ons:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari desigram
                    case ListSatuan.desigram:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picogram:
                                    Value /= pangkat(-11);
                                    break;
                                case ListSatuan.nanogram:
                                    Value /= pangkat(-8);
                                    break;
                                case ListSatuan.mikrogram:
                                    Value /= pangkat(-5);
                                    break;
                                case ListSatuan.miligram:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.centigram:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.gram:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.dekagram:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.hektogram:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.kilogram:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.pound:
                                    break;
                                case ListSatuan.ons:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari gram
                    case ListSatuan.gram:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picogram:
                                    Value /= pangkat(-12);
                                    break;
                                case ListSatuan.nanogram:
                                    Value /= pangkat(-9);
                                    break;
                                case ListSatuan.mikrogram:
                                    Value /= pangkat(-6);
                                    break;
                                case ListSatuan.miligram:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.centigram:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.desigram:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.dekagram:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.hektogram:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.kilogram:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.pound:
                                    break;
                                case ListSatuan.ons:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari dekagram
                    case ListSatuan.dekagram:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picogram:
                                    Value /= pangkat(-13);
                                    break;
                                case ListSatuan.nanogram:
                                    Value /= pangkat(-10);
                                    break;
                                case ListSatuan.mikrogram:
                                    Value /= pangkat(-7);
                                    break;
                                case ListSatuan.miligram:
                                    Value /= pangkat(-4);
                                    break;
                                case ListSatuan.centigram:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.desigram:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.gram:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.hektogram:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.kilogram:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.pound:
                                    break;
                                case ListSatuan.ons:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari hektogram
                    case ListSatuan.hektogram:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picogram:
                                    Value /= pangkat(-14);
                                    break;
                                case ListSatuan.nanogram:
                                    Value /= pangkat(-11);
                                    break;
                                case ListSatuan.mikrogram:
                                    Value /= pangkat(-8);
                                    break;
                                case ListSatuan.miligram:
                                    Value /= pangkat(-5);
                                    break;
                                case ListSatuan.centigram:
                                    Value /= pangkat(-4);
                                    break;
                                case ListSatuan.desigram:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.gram:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.dekagram:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.kilogram:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.pound:
                                    break;
                                case ListSatuan.ons:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari kilogram
                    case ListSatuan.kilogram:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picogram:
                                    Value /= pangkat(-15);
                                    break;
                                case ListSatuan.nanogram:
                                    Value /= pangkat(-12);
                                    break;
                                case ListSatuan.mikrogram:
                                    Value /= pangkat(-9);
                                    break;
                                case ListSatuan.miligram:
                                    Value /= pangkat(-6);
                                    break;
                                case ListSatuan.centigram:
                                    Value /= pangkat(-5);
                                    break;
                                case ListSatuan.desigram:
                                    Value /= pangkat(-4);
                                    break;
                                case ListSatuan.gram:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.dekagram:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.kilogram:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.pound:
                                    break;
                                case ListSatuan.ons:
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari pound
                    case ListSatuan.pound:
                        {
                        }
                        break;
                    #endregion

                    #region dari ons
                    case ListSatuan.ons:
                        {
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
            return (double)Math.Pow(10, power);
        }

        /// <summary>
        /// Membandingkan apakah instance Mass bernilai sama atau beda
        /// </summary>
        /// <param name="a">Mass pertama yang dibandingkan</param>
        /// <param name="b">Mass kedua yang dibandingkan</param>
        /// <returns></returns>
        public static bool Equals(Mass a, Mass b)
        {
            if (a.Satuan != b.Satuan)
            {
                Mass tmp = a;
                tmp.ConvertTo(b.Satuan);
                if (tmp.Value == b.Value) return true;
                else return false;
            }
            else
            {
                if (a.Value == b.Value) return true;
                else return false;
            }
        }

        #endregion

    }
}
