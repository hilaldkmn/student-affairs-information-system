using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.CheckedListBox;

namespace last_exam
{
    public partial class Form1 : Form
    {
        private int ogrenci_sayisi;
        private int kontenjan;
        private string derslikler;
        private string[] siniflar;
        private int[] sinif_kontenjanlar;
        private List<Ogrenci> ogrenciler;
        private Ders ders;
        private List<Tuple<string, int, string, string>> liste;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Dosyadan sınıfların okunması
            List<Sinif> siniflar = DosyaIslemleri.getSiniflar("./siniflar.txt");
            // Form açıldığı anda okunan sınıfların CheckedListBox'a programsal olarak eklenmesi
            foreach (Sinif sinif in siniflar)
            {
                siniflar_listbox.Items.Add(sinif.Derslik+","+sinif.Kontenjan+" Kişilik");
            }
        }

        private void kontenjan_degistir(object sender, EventArgs e)
        {
            // isaretli sınıfların bulunması
            CheckedItemCollection isaretliler = siniflar_listbox.CheckedItems;
            // seçilen sınıfıların kontenjanları toplamının bulunması için değişkenin atanması
            kontenjan = 0;
            // seçilen sınıflar için dersliklerin sayıları
            derslikler = "";
            // seçilen sınıfların kontenjanlarının tutulması için integer dizinin tanımlanması
            sinif_kontenjanlar = new int[isaretliler.Count];

            for (int i = 0; i < isaretliler.Count; i++)
            {
                // işaretlenmiş dersliklerin ayrıştırılması
                string[] derslik = isaretliler[i].ToString().Split(',');
                // derslik numaralarının string olarak birleştirilmesi
                derslikler += derslik[0] + "\n";
                // derslik kontenjanının diziye atanması
                sinif_kontenjanlar[i] = Convert.ToInt32(derslik[1].Substring(0, derslik[1].IndexOf(' ')));
                // seçilen kontenjanların toplanması
                kontenjan += Convert.ToInt32(derslik[1].Substring(0, derslik[1].IndexOf(' ')));
            }
            // seçilmiş dersliklerin diziye dönüştürülmesi
            siniflar = derslikler.Split('\n');
            // Toplam kontenjan sayısının kullanıcıya bildirilmesi
            secilen_kontenjan.Text = "Seçilen Kontenjan:" + kontenjan;
            // Kontenjan Öğrenci sayısından az ise dağıtma butonunun kapatılması
            if (kontenjan < ogrenci_sayisi)
            {
                dagit_buton.Enabled = false;
            }
            else
            {
                dagit_buton.Enabled = true;
            }
        }

        private void dagit_buton_Click(object sender, EventArgs e)
        {
            // Öğrencilerin geçici bir Listeye alınması
            List<Ogrenci> temp_ogrenci = ogrenciler;
            // Dağıtılacak listenin ilk atanmasının yapılması
            liste = new List<Tuple<string,int, string, string>>();
            // Form nesnesi üzerinde tutulan seçilen sınıfların döngü ile bulunması
            for(int i = 0;i<siniflar.Length-1;i++)
            {
                // Seçilen sınıfların kontenjanlarına göre döngüye alınması
                for(int j = 0; j < sinif_kontenjanlar[i]; j++) {
                    // geçici değişkende öğrenci bulunmuyorsa döngünün hata vermesinin önüne geçilmesi
                    if (temp_ogrenci.Count > 0)
                    {
                        // Rastgele sayı almak için standart Random sınıfının oluşturulması
                        Random a = new Random();
                        // Rastgele sayının atanması
                        int rastgele = a.Next(0, temp_ogrenci.Count);
                        // Rastgele seçilen öğrencinin bulunması
                        Ogrenci o = temp_ogrenci[rastgele];
                        // Dağıtılacak liste için bulunan öğrencinin sınıfa atanması
                        liste.Add(Tuple.Create(siniflar[i], j + 1, o.OgrenciNumarasi, o.OgrenciAdiSoyadi));
                        // Dağıtılan öğrencinin geçici değikenden kaldırılması
                        temp_ogrenci.RemoveAt(rastgele);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            dataGridView1.DataSource = liste;
            // Dağıtılan öğrencilerin Kaydetme işleminin yapılması
            this.DosyaKaydet();
            // Bilgisinin Verilmesi
            MessageBox.Show(liste.Count + " Kişi Atandı");
        }
        private void DosyaKaydet()
        {
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            try
            {
                // Excelden okunan dersin bilgilerine göre dosyanın adının ve yolunun belirlenmesi
                string pathOfFileToCreate = "./"+ders.DersKodu+"_"+ders.DersAdi+".xls";
                // Aynı isimde dosya varsa silinmesi
                File.Delete(pathOfFileToCreate);
                // Office Access Database Engine yardımıyla XLS dosyasının bağlanması
                conn.ConnectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathOfFileToCreate + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=0\"");
                conn.Open();
                // Bağlantının sağlanması ve işlemler için bağlantıda komut nesnesinin çağırılması
                var cmd = conn.CreateCommand();
                // Formda tutulan her bir sınıf için XLS dosyasında tablo oluşturulması
                for(int i = 0; i < siniflar.Length - 1; i++)
                {
                    cmd.CommandText = "CREATE TABLE "+siniflar[i]+ " ('Sıra No' INTEGER,'Ögrenci Numarası' NVARCHAR(15),'Öğrenci Adı Soyadı' NVARCHAR(100),'İmza' NVARCHAR(1))";
                    cmd.ExecuteNonQuery();
                }
                // Formda tutulan Dağıtılan Kişiler Listesinin her bir tabloya Eklenmesi
                foreach(Tuple<string,int,string,string> tuple in liste)
                {
                    
                    cmd.CommandText = String.Format("INSERT INTO "+tuple.Item1+ " ('Sıra No','Ögrenci Numarası','Öğrenci Adı Soyadı') VALUES({0},'{1}','{2}')", tuple.Item2, tuple.Item3,tuple.Item4);
                    cmd.ExecuteNonQuery(); // Ekleme işleminin çalıştırılması
                }
            }
            finally
            {
                // Bağlantının sonlandırılması
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        private void yukleme(string dosya)
        {
            // Excel dosyası okumak için oluşturduğum sınıfın kullanılması
            DosyaIslemleri a = new DosyaIslemleri(dosya);
            // Oluşturduğum sınıftan öğrenci listesinin alınması
            ogrenciler = a.getOgrenciler();
            // Öğrencilerin DataGridView ile gösterilmesi
            dataGridView1.DataSource = ogrenciler;
            // Form nesnesinde erişilebilir olarak tutulan öğrenci sayısının bulunması
            ogrenci_sayisi = ogrenciler.Count;
            // Öğrenci sayısının kullanıcıya bilgilendirmesinin yapılması
            toplam_ogrenci.Text = "Toplam Öğrenci:" + ogrenci_sayisi;
            // Dersin genel bilgilerinin alınıp form üzerindeki bir değişkende tutulması
            ders = a.getDers();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Excel Dosyalarına Gözat",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xls",
                Filter = "xls files (*.xls)|*.xls",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                yukleme(openFileDialog1.FileName);
            }
            openFileDialog1.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
