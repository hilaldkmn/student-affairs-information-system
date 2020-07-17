# student-affairs-information-system
Reading and writing data from excel and txt files ( Excel ve txt dosyalarından veri okuma ve yazma)

Proliz öğrenci işleri bilgi sistemi dersi alan öğrencileri Excel dosyası olarak dışarı çıkartmaktadır. 
Bu Excel dosyasını göz at düğmesi ile alarak sistemde belirtilen sınıflara rastgele olarak atayan ve her sınıfa atanan öğrencilerin listesini Excel dosyası olarak çıktı veren bir C# uygulaması hazırlayınız.
Hazırlanacak olan uygulamanın arayüzü aşağıdaki gibi olabilir.  

![](https://raw.githubusercontent.com/hilaldkmn/student-affairs-information-system/master/Örnek.png)
  
Uygulamanın çalışma biçimi aşağıdaki gibi olmalıdır:  
  
1.	Program çalıştırıldığında (form load veya benzeri bir  	olay)  	siniflar.txt  	adlı  	dosyadaki  veriler CheckBoxList veya benzeri bir bileşen içerisinde otomatik  	olarak  listelenecektir. 
 siniflar.txt dosyasının içeriği ekte verilmiştir. Buna göre her satır sınıf adı, kapasite şeklinde olacaktır. Ayrıca siniflar.txt dosyası EXE dosyası ile aynı klasördedir. Hazırlanacak  	uygulama  içinde  ekte  	verilen siniflar.txt dosyası kullanılmalıdır.  
2.	Sınıfların listesinde seçim yapıldıkça toplam kontenjan liste altında yer almalıdır. Bu bileşen Label veya TextBox olarak seçilebilir.  
3.	Program çalıştığında öğrenci listesi  (DataGridView veya benzeri bir bileşen) boş olarak gelecektir ve Rastgele Dağıt ve Kaydet düğmesi aktif değildir.  
4.	Excel dosyasını aç düğmesi tıklandığında açılan openFileDialog bileşeni ile ekte verilen ogrenci.xls dosyasının yeri gösterilecektir. Dosya seçilip diyalog kutusu kapandığında Excel dosyasının içeriği öğrenci listesine aktarılacak ve listedeki toplam öğrenci sayısı Label veya TextBox içerinde gösterilecektir. Bazı yerlerde hücre sırası değiştiğinden dolayı Excel listesindeki sıra numarası takip edilerek ilgili hücreler listeye aktarılabilir. Örnek bir dosya ekte verilmiştir (ogrenci.xls). Ayrıca dosyanın önemli bazı hücre adresleri aşağıdaki gibidir.  
a.	Sıra numarası, A11 hücresinden başlamaktadır.  
b.	Öğrenci numarası, C11 hücresinden başlamaktadır.  
c.	Öğrenci Adı ve soyadı, E11 hücresinden başlamaktadır.  
d.	Dersin verileri ise H8 hücresinde bulunmaktadır. Burada Fakülte/Yüksekokul, Program, Sınıf, Ders Kodu, Şube Kodu, Ders Adı, Öğretim Elemanı verileri bulunmaktadır.  
5.	Rastgele dağıt ve kaydet düğmesi öğrenci sayısına uygun sınıf kontenjanı seçildiğinde aktif olmalıdır. Örneğin 150 kişilik bir öğrenci grubu için ez az 150 kişilik sınıf seçilmelidir. Eğer yeterli kontenjana sahip sınıf seçilmez ise Rastgele dağıt ve kaydet düğmesi aktif olmayacaktır.  
6.	Rastgele dağıt ve kaydet düğmesi tıklandığında öğrenciler sınıflara rastgele dağıtılacaktır. Bu aşamada oluşturulan gruplar tek bir Excel dosyası içinde farklı sayfalarda listelenmelidir. Sayfaların adları ise sınıf adları olmalıdır. Örnek bir dosya (sonuc.xls) ekte verilmiştir.  
7.	Programı Kapat düğmesi uygulamayı kapatacaktır.  
