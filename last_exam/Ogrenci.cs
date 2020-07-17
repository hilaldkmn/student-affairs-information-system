using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace last_exam
{
    // Öğrencilerin Bilgileri için oluşturulmuş sınıf
    class Ogrenci
    {
        private int sira_no = 0;
        private string ogrenci_no = "";
        private string ogrenci_adi = "";
        private string ders_durum = "";
        public int SiraNo { get { return sira_no; } }
        public string OgrenciNumarasi { get { return ogrenci_no; } }
        public string OgrenciAdiSoyadi { get { return ogrenci_adi; } }
        public string OgrenciDersDurum { get { return ders_durum; } }
        public Ogrenci(int sira, string no, string adi, string durum)
        {
            sira_no = sira;
            ogrenci_no = no.Trim();
            ogrenci_adi = adi.Trim();
            ders_durum = durum.Trim();
        }
        public override string ToString()
        {
            return "\n"+sira_no +":"+ ogrenci_no +":"+ ogrenci_adi +":"+ ders_durum;
        }
    }
}
