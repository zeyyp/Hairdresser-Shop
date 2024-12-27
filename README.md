## Hairdresser-Shop

Bu proje, ASP.NET Core MVC kullanılarak geliştirilmiş bir Kuaför İşletme Yönetim Uygulamasıdır. Amaç, kuaför salonlarının hizmetlerini, çalışanlarını ve randevu süreçlerini kolaylıkla yönetebileceği bir sistem sunmaktır.
Sistem, kullanıcıların uygun çalışanların uygun saatlerinde işlem bazlı randevu oluşturmasına olanak tanır. Ayrıca, kullanıcıların uygulamaya fotoğraf yükleyerek saç modeli önerileri almasını sağlayan yapay zeka entegrasyonu da mevcuttur. 
Uygulamada kullanıcı ve admin panelleri yer almakta olup, kullanıcıların sisteme üye olma ve oturum açma işlemleri yetkilendirme mekanizmaları ile desteklenmiştir. Veritabanı yönetimi için postgreSql ve Entity Framework Core kullanılmış, Bootstrap ile kullanıcı dostu bir arayüz tasarlanmıştır. 


### Temel Özellikler:
Hizmet Tanımlama: Hizmet türleri, süreleri ve ücretlerinin yönetimi.
Randevu Yönetimi: Kullanıcıların uygun çalışanlarla işlem bazlı randevu oluşturabilmesi.
Uzmanlık ve Müsaitlik Takibi: Çalışanların uzmanlık alanları ve müsaitlik durumlarının takibi.
Yapay Zeka Entegrasyonu: Kullanıcıların fotoğraf yükleyerek saç modeli ve renk önerisi alabilmesi.
Kullanıcı ve Admin Panelleri: Kullanıcılar ve adminler için ayrı paneller.
Kimlik Doğrulama: Üyelik ve oturum açma işlemleri için ASP.NET Core Identity altyapısı.
Veritabanı Yönetimi: PostgreSQL ve Entity Framework Core kullanılarak veritabanı işlemleri.
Kullanıcı Dostu Arayüz: Bootstrap ile tasarlanmış dinamik ve kullanıcı dostu bir arayüz.

## Uygulama Mimarisi
###Entity Katmanı
Veritabanı tablolarını temsil eden sınıflar tanımlandı.
Tablolara ait sütunlar ve ilişkiler burada belirlendi.
### Context Katmanı
PostgreSQL veritabanı ile bağlantı kurularak tabloların oluşturulması sağlandı.

### Controllerlar
AppointmentController:
NewAppointment (GET): Kullanıcıya yeni randevu oluşturma formunu gösterir.
NewAppointment (POST): Randevu bilgilerini işler, çakışmaları kontrol eder ve uygunsa veritabanına kaydeder.
UpdateEarnings: Randevu sonrası personelin günlük kazancını günceller.
HomeController:
Statik sayfaların (Hizmetler, İletişim, Biz Kimiz?) yönetimini sağlar.
Salon bilgilerini dinamik olarak getirir.

LoginController:
Kayıt olma, giriş yapma ve çıkış yapma işlemlerini yönetir.
ASP.NET Core Identity altyapısını kullanır.

## Admin Paneli
Admin paneli ayrı bir alan (Areas) olarak tasarlandı.

### Özellikler:
Personel Yönetimi: Personel ekleme, silme, güncelleme ve listeleme.
Hizmet Yönetimi: Hizmetlerin yönetimi.
Randevu Yönetimi: Alınan randevuların onaylanması veya iptali.
Rol Yönetimi: Kullanıcılara rol atama ve rollerin düzenlenmesi.
Kazançlar: Personellerin kazançlarını görüntüleme.
Rol Atama İşlemleri:
RoleAta (GET): Kullanıcının mevcut rollerini listeler.
RoleAta (POST): Seçilen rolleri kullanıcıya atar.
Authorization İşlemleri
IdentitySeedData: Admin rolündeki bir kullanıcı yoksa uygulama başlatıldığında otomatik olarak oluşturulur.
Admin paneline yalnızca admin rolündeki kullanıcılar erişebilir.
















