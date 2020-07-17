using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace last_exam
{
    // Derslikler için oluşturulmuş sınıf
    class Sinif
    {
        private int derslik = 0;
        private int kontenjan = 0;
        public int Derslik { get { return derslik; } }
        public int Kontenjan { get { return kontenjan; } }
        public Sinif(string bilgi)
        {
            string[] bilgiler = bilgi.Split(',');
            derslik = Convert.ToInt32(bilgiler[0]);
            kontenjan = Convert.ToInt32(bilgiler[1]);
        }
        public override string ToString()
        {
            return derslik + " Numaralı Derslik, " + kontenjan + " Kişilik";
        }
    }
}
