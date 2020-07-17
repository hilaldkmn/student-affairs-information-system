using System;

namespace last_exam
{
    // Dersin bilgileri için oluşturulmuş sınıf
    public class Ders
    {
        private string fakulte = "";
        private string program = "";
        private int sinif = 0;
        private string ders_kodu = "";
        private string sube_kodu = "";
        private string ders_adi = "";
        private string ogretim_elemani = "";
        public string Fakulte { get { return fakulte; } }
        public string Program { get { return program; } }
        public string DersKodu { get { return ders_kodu; } }
        public string SubeKodu { get { return sube_kodu; } }
        public string DersAdi { get { return ders_adi; } }
        public string OgretimElemani { get { return ogretim_elemani; } }
        public int Sinif { get { return sinif; } }
        public Ders (string bilgi)
        {
            string[] bilgiler = bilgi.Split('\n');
            fakulte = bilgiler[0];
            program = bilgiler[1];
            sinif = Convert.ToInt32(bilgiler[2]);
            ders_kodu = bilgiler[3];
            sube_kodu = bilgiler[4];
            ders_adi = bilgiler[5];
            ogretim_elemani = bilgiler[6];
        }
    }
}