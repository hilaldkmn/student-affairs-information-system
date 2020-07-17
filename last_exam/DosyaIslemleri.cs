using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;

namespace last_exam
{
    class DosyaIslemleri
    {
        private string excel_path = "";
        private DataTable table;

        public DosyaIslemleri(string path)
        {
            // Oluşturduğum nesnenin XLS dosyasını okuması için gerekli olan yapıcı metod
            this.excel_path = path; 
            // Excelde okunan veriler için table isimli değişkenin atanması
            table = new DataTable();
            // OleDb yardımıyla xls dosyasının okunması için bağlantının açılması
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + this.excel_path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=0\"";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            // Okunan Xls dosyasındaki sayfaların okunabilmesi için dosyanın şema bilgilerinin alınması
            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            DataRow schemaRow = schemaTable.Rows[0];
            string sheet = schemaRow["TABLE_NAME"].ToString();
            if (!sheet.EndsWith("_"))
            {
                // Sayfalarda bulunan verilerin okunup table değişkenine eklenmesi
                string query = "SELECT  * FROM [" + sheet + "]";
                OleDbDataAdapter daexcel = new OleDbDataAdapter(query, conn);
                table.Locale = CultureInfo.CurrentCulture;
                daexcel.Fill(table);
            }
            conn.Close();
        }
        // Okunan Xls dosyasındaki tablonun alınması
        public DataTable getTable()
        {
            return table;
        }
        // Dosyada okunan öğrencilerin bulunması için tanımlanmış metod
        public List<Ogrenci> getOgrenciler()
        {
            // ogrenciler değişkeninin tanımlanması
            List<Ogrenci> ogrenciler = new List<Ogrenci>();
            // dosyadan tablo okunmuş olup olmadığının kontrolü
            if (!(table is null))
            {
                // okunan tablodan satırlarına ayrıştırılması
                foreach (DataRow satir in table.Rows)
                {
                    try
                    {
                        // okunan satırımızda ilk sütun boş olup olmadığının ve ardından bir sayı olarak okunabildiğinin kontrolü
                        if (!(satir[0] is DBNull) && int.Parse(satir[0].ToString()) > 0)
                        {
                            // şartlar sağlanıyorsa öğrenci sınıfı yardımıyla belirli alanlardaki verilerin nesneyi oluşturup ogrenciler listesine eklenmesi
                            ogrenciler.Add(new Ogrenci(Convert.ToInt32(satir[0]), satir[2].ToString(), satir[4].ToString(), satir[8].ToString()));
                        }
                    }
                    catch (Exception e)
                    {
                        e.ToString();
                        continue;
                    }

                }
            }
            else
            {

            }
            return ogrenciler;
        }
        public Ders getDers()
        {
            // Xls dosyasından okunan ders bilgileri için belirli alanların kontrolü ve Ders sınıfından nesne oluşturulması
            Ders d;
            if (!(table.Rows[6][7] is DBNull) && table.Rows[6][7].ToString().Length > 0)
            {
                d = new Ders(table.Rows[6][7].ToString());
            }
            // Ders bulunmadıysa nesneyi oluşturacak varsayılan değerin tanımlanması
            else
            {
                d = new Ders("FAKÜLTE BULUNAMADI\nPROGRAM BULUNAMADI\n1\nDERSKODU BULUNAMADI\n1\nDERS ADI BULUNAMADI\nÖĞRETİM ÜYESİ BULUNAMADI");
            }
            return d;
        }
        // dosyadan okunması için her yerden erişilen getSiniflar metodunun tanımlanması
        public static List<Sinif> getSiniflar(string dosya_yolu)
        {
            // Dosyanın okunması için alınması
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            // Dosyadan bilgileri okuyabilmek için Okuyucu nesnesinin tanımlanması
            StreamReader sw = new StreamReader(fs);
            // Okunacak ilk satırın alınması
            string satir = sw.ReadLine();
            // Sınıflar için oluşturulmuş listenin tanımlanması
            List<Sinif> siniflar = new List<Sinif>();
            // Satır okunmuşsa döngüye girilmesi
            while (satir != null)
            {
                // Okunan satirin Sınıf nesnesi kullanarak oluşturulması ve Listeye Eklenmesi
                siniflar.Add(new Sinif(satir));
                // Satir değişkeninin döngü için iterasyonu
                satir = sw.ReadLine();
            }
            // Dosyanın kapatılması ve bu sayede diğer programların erişebilmesinin sağlaması
            sw.Close();
            fs.Close();
            return siniflar;
        }
    }
}
