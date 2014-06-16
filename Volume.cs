using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konverter
{
    /// <summary>
    /// Tumpuan untuk satuan volume dengan instance default berupa liter, namun dapat diubah-ubah
    /// </summary>
    public class Volume : IMeasurable<Volume.ListSatuan>
   {
        #region constant declaration
        /// <summary>
        /// Epsilon, digunakan untuk membandingkan 2 bilangan real
        /// </summary>
        private const double EPS = 1e-9;
        #endregion

        #region satuan volume yg didefinisikan
        /// <summary>
        /// satuan dari volume
        /// </summary>

        public enum ListSatuan
        {
            picoliter, 
            nanoliter, 
            mikroliter, 
            mililiter, 
            centiliter, 
            desiliter, 
            liter, 
            dekaliter, 
            hektoliter, 
            kiloliter, 
            megaliter, 
            cc
        }
        #endregion

        #region instance version

        private double _value;
        private ListSatuan _satuan;

        /// <summary>
        /// Get or Set satuan volume
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
        /// Get atau Set nilai dari volume
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

        public Volume()
        {
            _value = 0;
            _satuan = ListSatuan.liter;
        }

        /// <summary>
        /// Initialize Volume dengan properti value awal bersatuan liter
        /// </summary>
        /// <param name="val">Nilai mula-mula dari satuan yang akan dikonversi</param>
        public Volume(double val)
        {
            _value = val;
            _satuan = ListSatuan.liter;
        }

        /// <summary>
        /// Initialize Volume dengan satuan yang ditentukan
        /// </summary>
        /// <param name="val">Nilai mula-mula dari satuan yang akan dikonversi</param>
        /// <param name="satuan">Satuan dari nilai mula-mula</param>
        public Volume(double val, ListSatuan satuan)
        {
            _value = val;
            Satuan = satuan;
        }

        /// <summary>
        /// Cetak string nilai dari volume beserta satuannya
        /// </summary>
        /// <returns>Nilai dari volume dan satuannya</returns>
        public override string ToString()
        {
            return (Value.ToString() + " " + Satuan.ToString());
        }

        /// <summary>
        /// Ubah value ke bentuk string
        /// </summary>
        /// <returns>Nilai dari volume dan satuannya</returns>
        public string ValueToString()
        {
            return (Value.ToString());
        }

        /// <summary>
        /// Konversi dari suatu satuan volume ke satuan volume yang lain
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
            if (obj is Volume)
            {
                Volume tmp = obj as Volume;
                return Volume.IsEqual(this, tmp);
            }
            else return false;

        }

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
                    #region dari picoliter
                    case ListSatuan.picoliter:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.nanoliter:
                                    Value /= pangkat(3); 
                                    break;
                                case ListSatuan.mikroliter:
                                    Value /= pangkat(6); 
                                    break;
                                case ListSatuan.mililiter:
                                    Value /= pangkat(9);
                                    break;
                                case ListSatuan.centiliter:
                                    Value /= pangkat(10); 
                                    break;
                                case ListSatuan.desiliter:
                                    Value /= pangkat(11); 
                                    break;
                                case ListSatuan.liter:
                                    Value /= pangkat(12);
                                    break;
                                case ListSatuan.dekaliter:
                                    Value /= pangkat(13); 
                                    break;
                                case ListSatuan.hektoliter:
                                    Value /= pangkat(14); 
                                    break;
                                case ListSatuan.kiloliter:
                                    Value /= pangkat(15);
                                    break;
                                case ListSatuan.megaliter:
                                    Value /= pangkat(18);
                                    break;
                                case ListSatuan.cc:
                                    Value /= pangkat(9);
                                    break;
                            }
                        }
                        break;
                    #endregion
                   
                    #region dari nanoliter
                    case ListSatuan.nanoliter:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picoliter:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.mikroliter:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.mililiter:
                                    Value /= pangkat(6);
                                    break;
                                case ListSatuan.centiliter:
                                    Value /= pangkat(7);
                                    break;
                                case ListSatuan.desiliter:
                                    Value /= pangkat(8);
                                    break;
                                case ListSatuan.liter:
                                    Value /= pangkat(9);
                                    break;
                                case ListSatuan.dekaliter:
                                    Value /= pangkat(10);
                                    break;
                                case ListSatuan.hektoliter:
                                    Value /= pangkat(11);
                                    break;
                                case ListSatuan.kiloliter:
                                    Value /= pangkat(12);
                                    break;
                                case ListSatuan.megaliter:
                                    Value /= pangkat(15);
                                    break;
                                case ListSatuan.cc:
                                    Value /= pangkat(6);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari mikroliter
                    case ListSatuan.mikroliter:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picoliter:
                                    Value /= pangkat(-6);
                                    break;
                                case ListSatuan.nanoliter:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.mililiter:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.centiliter:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.desiliter:
                                    Value /= pangkat(5);
                                    break;
                                case ListSatuan.liter:
                                    Value /= pangkat(6);
                                    break;
                                case ListSatuan.dekaliter:
                                    Value /= pangkat(7);
                                    break;
                                case ListSatuan.hektoliter:
                                    Value /= pangkat(8);
                                    break;
                                case ListSatuan.kiloliter:
                                    Value /= pangkat(9);
                                    break;
                                case ListSatuan.megaliter:
                                    Value /= pangkat(12);
                                    break;
                                case ListSatuan.cc:
                                    Value /= pangkat(3);
                                    break;
                            }
                        }
                        break;
                     #endregion

                    #region dari mililiter
                    case ListSatuan.mililiter:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picoliter:
                                    Value /= pangkat(-9);
                                    break;
                                case ListSatuan.nanoliter:
                                    Value /= pangkat(-6);
                                    break;
                                case ListSatuan.mikroliter:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.centiliter:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.desiliter:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.liter:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.dekaliter:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.hektoliter:
                                    Value /= pangkat(5);
                                    break;
                                case ListSatuan.kiloliter:
                                    Value /= pangkat(6);
                                    break;
                                case ListSatuan.megaliter:
                                    Value /= pangkat(9);
                                    break;
                                case ListSatuan.cc:
                                    Value *= 1;
                                    break;
                            }
                        }
                        break;
                       #endregion

                    #region dari centiliter
                    case ListSatuan.centiliter:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picoliter:
                                    Value /= pangkat(-10);
                                    break;
                                case ListSatuan.nanoliter:
                                    Value /= pangkat(-7);
                                    break;
                                case ListSatuan.mikroliter:
                                    Value /= pangkat(-4);
                                    break;
                                case ListSatuan.mililiter:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.desiliter:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.liter:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.dekaliter:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.hektoliter:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.kiloliter:
                                    Value /= pangkat(5);
                                    break;
                                case ListSatuan.megaliter:
                                    Value /= pangkat(8);
                                    break;
                                case ListSatuan.cc:
                                    Value /= pangkat(-1);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari desiliter
                    case ListSatuan.desiliter:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picoliter:
                                    Value /= pangkat(-11);
                                    break;
                                case ListSatuan.nanoliter:
                                    Value /= pangkat(-8);
                                    break;
                                case ListSatuan.mikroliter:
                                    Value /= pangkat(-9);
                                    break;
                                case ListSatuan.mililiter:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.centiliter:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.liter:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.dekaliter:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.hektoliter:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.kiloliter:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.megaliter:
                                    Value /= pangkat(7);
                                    break;
                                case ListSatuan.cc:
                                    Value /= pangkat(-2);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari liter
                    case ListSatuan.liter:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picoliter:
                                    Value /= pangkat(-12);
                                    break;
                                case ListSatuan.nanoliter:
                                    Value /= pangkat(-9);
                                    break;
                                case ListSatuan.mikroliter:
                                    Value /= pangkat(-6);
                                    break;
                                case ListSatuan.mililiter:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.centiliter:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.desiliter:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.dekaliter:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.hektoliter:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.kiloliter:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.megaliter:
                                    Value /= pangkat(6);
                                    break;
                                case ListSatuan.cc:
                                    Value /= pangkat(-3);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari dekaliter
                    case ListSatuan.dekaliter:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picoliter:
                                    Value /= pangkat(-13);
                                    break;
                                case ListSatuan.nanoliter:
                                    Value /= pangkat(-10);
                                    break;
                                case ListSatuan.mikroliter:
                                    Value /= pangkat(-7);
                                    break;
                                case ListSatuan.mililiter:
                                    Value /= pangkat(-4);
                                    break;
                                case ListSatuan.centiliter:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.desiliter:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.liter:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.hektoliter:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.kiloliter:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.megaliter:
                                    Value /= pangkat(5);
                                    break;
                                case ListSatuan.cc:
                                    Value /= pangkat(-4);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari hektoliter
                    case ListSatuan.hektoliter:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picoliter:
                                    Value /= pangkat(-14);
                                    break;
                                case ListSatuan.nanoliter:
                                    Value /= pangkat(-11);
                                    break;
                                case ListSatuan.mikroliter:
                                    Value /= pangkat(-8);
                                    break;
                                case ListSatuan.mililiter:
                                    Value /= pangkat(-5);
                                    break;
                                case ListSatuan.centiliter:
                                    Value /= pangkat(-4);
                                    break;
                                case ListSatuan.desiliter:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.liter:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.dekaliter:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.kiloliter:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.megaliter:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.cc:
                                    Value /= pangkat(-5);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari kiloliter
                    case ListSatuan.kiloliter:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picoliter:
                                    Value /= pangkat(-15);
                                    break;
                                case ListSatuan.nanoliter:
                                    Value /= pangkat(-12);
                                    break;
                                case ListSatuan.mikroliter:
                                    Value /= pangkat(-9);
                                    break;
                                case ListSatuan.mililiter:
                                    Value /= pangkat(-6);
                                    break;
                                case ListSatuan.centiliter:
                                    Value /= pangkat(-5);
                                    break;
                                case ListSatuan.desiliter:
                                    Value /= pangkat(-4);
                                    break;
                                case ListSatuan.liter:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.dekaliter:
                                    Value /= pangkat(-2);
                                    break;
                                case ListSatuan.hektoliter:
                                    Value /= pangkat(-1);
                                    break;
                                case ListSatuan.megaliter:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.cc:
                                    Value /= pangkat(-6);
                                    break;
                            }
                        }
                        break;
                    #endregion               

                    #region dari megaliter
                    case ListSatuan.megaliter:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picoliter:
                                    Value /= pangkat(-18);
                                    break;
                                case ListSatuan.nanoliter:
                                    Value /= pangkat(-15);
                                    break;
                                case ListSatuan.mikroliter:
                                    Value /= pangkat(-12);
                                    break;
                                case ListSatuan.mililiter:
                                    Value /= pangkat(-9);
                                    break;
                                case ListSatuan.centiliter:
                                    Value /= pangkat(-8);
                                    break;
                                case ListSatuan.desiliter:
                                    Value /= pangkat(-7);
                                    break;
                                case ListSatuan.liter:
                                    Value /= pangkat(-6);
                                    break;
                                case ListSatuan.dekaliter:
                                    Value /= pangkat(-5);
                                    break;
                                case ListSatuan.hektoliter:
                                    Value /= pangkat(-4);
                                    break;
                                case ListSatuan.kiloliter:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.cc:
                                    Value /= pangkat(-9);
                                    break;
                            }
                        }
                        break;
                    #endregion

                    #region dari cc
                    case ListSatuan.cc:
                        {
                            switch (tujuan)
                            {
                                case ListSatuan.picoliter:
                                    Value /= pangkat(-9);
                                    break;
                                case ListSatuan.nanoliter:
                                    Value /= pangkat(-6);
                                    break;
                                case ListSatuan.mikroliter:
                                    Value /= pangkat(-3);
                                    break;
                                case ListSatuan.centiliter:
                                    Value /= pangkat(1);
                                    break;
                                case ListSatuan.desiliter:
                                    Value /= pangkat(2);
                                    break;
                                case ListSatuan.liter:
                                    Value /= pangkat(3);
                                    break;
                                case ListSatuan.dekaliter:
                                    Value /= pangkat(4);
                                    break;
                                case ListSatuan.hektoliter:
                                    Value /= pangkat(5);
                                    break;
                                case ListSatuan.kiloliter:
                                    Value /= pangkat(6);
                                    break;
                                case ListSatuan.megaliter:
                                    Value /= pangkat(9);
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
        /// Membandingkan apakah instance Volume bernilai sama atau beda
        /// </summary>
        /// <param name="a">Volume pertama yang dibandingkan</param>
        /// <param name="b">Volume kedua yang dibandingkan</param>
        /// <returns></returns>
        public static bool IsEqual(Volume a, Volume b)
        {
            if(a is Length && b is Length)
            {
                if (a.Satuan != b.Satuan)
                {
                    Volume tmp = new Volume(a.Value, a.Satuan);
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
