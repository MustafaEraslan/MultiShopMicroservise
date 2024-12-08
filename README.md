# MultiShopMicroservise

No Sql nedir?

İlişkili veritabanı sistemleri ile arasındaki en büyük fark ilişkisel veritabanı sistemlerinde veriler tablo ve sütunlar ile ilişkili bir şekilde tutulurken NoSQL’de json bir yapıda tutulmasıdır.

NoSQL sistemlerin avantajlarına değinmek gerekirse ilk olarak performans gösterilebilir. Okuma ve yazma işlemleri ilişkisel veritabanlarına göre çok daha hızlı olmaktadır. İkinci olarak ise NoSQL sistemler yatay olarak genişletilebilirler. Binlerce sunucu bir arada çalışarak inanılmaz derecedeki veriler üzerinde işlemler yapabilir.

Mongo Db:

MongoDB 2009 yılında geliştirilmiş açık kaynak kodlu bir NoSQL veritabanıdır.

MongoDB’de her kayıt bir doküman olarak ifade edilir. Ve bu dökümanlar json formatı şeklinde saklanır. Daha önce ilişkisel veritabanlarıyla ilgilenenlerin bildiği table yapısını burada collection, row yapısını document, column yapısını ise field alır.

Tablolar - collection
satırlar - döküman
Sütunlar - kolonlar


------
multishop catalog
settings klasörünü : veritabanı ile ilgili ayarları barındıran interface ve class'ı barındıyorum

appsettings: Bizim bağlantı klasörümüzü oluşturacak dosya.

Dtos: biz her bir CRUD için Single responsiblty ezmemek için ekledik. Ana tek sorumluluk. Her sınıf kendi işlemini yapsın diyordu. Bu yüzden her bir işlem için ayrı ayrı tanımlıyor olacağız.

[BsonIgnore] nedir?

[BsonIgnore], MongoDB için belge ve nesne eşleştirme işlemlerinde kullanılan bir özniteliktir. Bu öznitelik, belirli bir özelliğin MongoDB belgesine dönüştürülürken veya belgeden nesneye dönüştürülürken dikkate alınmamasını sağlar, yani MongoDB tarafında depolanmaz veya yüklenmez.

[BsonIgnore] kullanmassak ne olur ?
[BsonIgnore] özniteliği, MongoDB'nin .NET kitaplığı olan MongoDB.Driver'da bir özellik veya alanın MongoDB veritabanına kaydedilmemesi veya sorgulandığında yüklenmemesi için kullanılır. Bu öznitelik sayesinde belirli özellikler, sınıfın MongoDB koleksiyonundaki belgesine dahil edilmez.

[BsonIgnore] Ne İşe Yarar?

Bir sınıftaki belirli özelliklerin veya alanların MongoDB belgelerinde saklanmasını engeller.
Veritabanına kaydedilmesini istemediğiniz hassas bilgileri veya gereksiz olduğunu düşündüğünüz alanları dışarıda bırakmak için kullanılır.
Sadece uygulama içinde kullanılacak ancak veritabanında saklanması gerekmeyen geçici verileri dışarıda bırakmaya yarar.
[BsonIgnore] Kullanmazsak Ne Olur?
Eğer [BsonIgnore] özniteliğini kullanmazsanız:

Veritabanında Fazladan Alanlar Oluşur: Özelliğin veya alanın tüm verisi MongoDB’ye kaydedilir ve belgedeki veri boyutunu gereksiz yere büyütebilir.
Gereksiz Yükleme Yükü: Yüklemeler sırasında MongoDB, veriyi geri dönerken bu alanları da getirir, bu da bellek tüketimini artırabilir.
Performans Düşüşü: Özellikle fazla sayıda belge ve alan varsa, veri depolama ve sorgulama işlemlerinin performansı olumsuz etkilenebilir.
Özetle, [BsonIgnore] özniteliği, MongoDB ile gereksiz veri saklama ve bellek tüketimini azaltmak, yalnızca önemli bilgilerin kaydedilmesini sağlamak için önemli bir özelliktir.



Sadece Bir Tane Property İçin bir koca sınıf oluşturulur mu?
Sadece bir özellik (property) için koca bir DTO sınıfı oluşturmak çoğu zaman aşırıya kaçabilir. Ancak, ihtiyaçlarınıza ve projenizin yapısına bağlı olarak bu durum bazı avantajlar da sağlayabilir. 

- Kod Okunabilirliği ve Anlaşılabilirlik

Eğer tek bir özelliği kullanmak istiyorsanız, tek başına bir DTO oluşturmak yerine mevcut bir sınıf veya yapı kullanarak bu özelliği taşımak, kodun okunabilirliğini artırabilir.

Ancak bazı durumlarda, yalnızca bir özellik taşınıyor olsa bile, ayrı bir DTO sınıfı oluşturmak, kodun kendini açıklayan bir yapıya sahip olmasını sağlar. Örneğin, bir UpdateProductPriceDto sınıfı, bir fiyat güncelleme işleminin daha anlaşılır ve düzenli görünmesini sağlar.

- Uzun Vadeli Esneklik

Projeniz büyüdükçe veya geliştikçe, başlangıçta tek bir özelliği içeren DTO sınıfına başka özellikler de eklenebilir. Bu durumda DTO’yu erken oluşturmuş olmanız, ileride değişiklik yaparken esnek olmanızı sağlar.

Mikroservis veya çok katmanlı projelerde, özellikle açık ve anlaşılır veri transfer nesneleri, kod bakımı ve geliştirme sürecini kolaylaştırabilir.

- Validasyon ve Yetkilendirme Kontrolleri


Automapper kullandık
Amacımız: Bizim entity'lerimizden nesne oluşturmak yerine yani onları new'lemek yerine entitylerimizi propları gelip dto'daki proplarla eşleştirecek.

Tek bir property’ye sahip bir DTO bile olsa, validasyon ve yetkilendirme gibi süreçlerde anlamlı bir adlandırmaya sahip bir DTO ile daha güvenli ve sağlam bir yapı oluşturabilirsiniz. Örneğin, tek bir userId özelliğine sahip bir DeleteUserDto sınıfı, gelen veriyi daha rahat kontrol etmenizi sağlar.

Eğer projeniz küçük ve basit bir yapıya sahipse, tek bir özellik için ayrı bir DTO oluşturmak gereksiz olabilir. Ancak, daha karmaşık bir yapı ya da uzun vadeli büyüme hedefliyorsanız, bu DTO’yu oluşturmak ileride işleri daha düzenli ve kolay yönetilebilir hale getirebilir.


Auto mapper hakkında:
Alttaki gibi bir mapping'e ihtiyaç duymuyoruz.
![image](https://github.com/user-attachments/assets/882b9f93-5719-403a-89d7-c80ce384ccc0)



Controller içerisinde readonly ve ctro ile Dependency Injection uygulanması:

Burada alttaki kodu neden kullandık sorusuna yanıt buldum. 



Bu kodda readonly alan ve constructor'da (ctor) yapılan atama, bağımlılık enjeksiyonu (Dependency Injection, DI) ile ilgili bir yapıdır. İşte bu kullanımın detayları:

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
    }

1. readonly Anahtar Kelimesi
readonly ile işaretlenmiş alanlar yalnızca sınıf oluşturulurken (yani constructor içinde) veya tanımlandıkları anda değer alabilirler.
readonly olarak tanımlanmış bir alan, sınıfın diğer metotlarında değiştirilemez. Bu özellik, değiştirilemez (immutable) veri yapılarında istikrar sağlar ve alanın yanlışlıkla değiştirilmesini engeller.
2. Dependency Injection ve Constructor Ataması
ICategoryService gibi bir bağımlılığı readonly bir alan olarak tanımlamak, bu bağımlılığın sınıfın yaşam döngüsü boyunca değiştirilememesini sağlar.
CategoriesController sınıfı, ICategoryService bağımlılığını kendisi oluşturmamaktadır; bunun yerine bu bağımlılık dışarıdan, yani DI çerçevesi tarafından sağlanır.
Constructor, DI çerçevesi tarafından sağlanan bu bağımlılığı alıp _categoryService alanına atar. Bu sayede sınıf, ICategoryService bağımlılığını doğru bir şekilde alır ve kullanır.
Neden Böyle Bir Kod Yazılır?
Bu yapının amacı:

Gevşek Bağlılık: CategoriesController, ICategoryService’in bir somut sınıfını değil, arayüzünü (interface) kullanır. Bu da farklı ICategoryService uygulamaları ile kolayca değiştirilebilir olmasını sağlar.
Test Edilebilirlik: DI ile sağlanan bağımlılık, testlerde kolayca "mock"lanabilir. Bu da birim testleri yazarken sahte nesnelerle (mock objects) bağımlılıkları simüle etmenizi sağlar.
Kodun Güvenliği: readonly anahtar kelimesi sayesinde _categoryService alanı yalnızca constructor'da atanabilir, bu da yanlışlıkla değiştirilmesini önler.
Kısacası, bu kod CategoriesController sınıfında bağımlılık enjeksiyonu ve güvenli kod yapısı sağlamak için yazılmıştır.


Mediator

uçak kule jet örneğini buraya uygulayabiliriz. Mediator ile kule gibi hiç karışıklık olmadan uçuşlar sağlanabiliyor. Kule= Mediatıor


Docker:
Docker, uygulamalarınızı hızla derlemenize, test etmenize ve dağıtmanıza imkân tanıyan bir yazılım platformudur. Docker, yazılımları kitaplıklar, sistem araçları, kod ve çalışma zamanı dâhil olmak üzere yazılımların çalışması için gerekli her şeyi içeren container adlı standartlaştırılmış birimler hâlinde paketler. Docker'ı kullanarak her ortama hızla uygulama dağıtıp uygulamaları ölçeklendirebilir ve kodunuzun çalışacağından emin olabilirsiniz.

Docker Volume:

Docker Volumes, Docker Container’larındaki verileri saklamamız veya Container’lar arasında veri paylaşmamız gerektiğinde çok kullanışlıdır. Docker Volumes çok önemli bir kavramdır. Çünkü Docker Container silindiğinde tüm dosya sistemi de yok edilir. Bu gibi durumlarda verileri bir şekilde saklamak istiyorsak, Docker Volumes kullanmamız gerekiyor.

Portainer:

Bizler cmd ve teminal üzerinden çalışmak yerine arayüz içerisinden görmek istiyoruz. Portainer aslında bu işe yarıyor.

docker volume create portainer_data
docker run -d -p 8000:8000 -p 9000:9000 --name=portainer --restart=always -v /var/run/docker.sock:/var/run/docker.sock -v portainer_data:/data portainer/portainer-ce

1. AddTransient
Yaşam Süresi: Servis her talep edildiğinde yeni bir örnek oluşturulur.
Kullanım Alanı:
Hafif ve durumsuz (stateless) servisler.
Her çağrıda güncel bir örneğe ihtiyaç duyulan servisler.
Örnek: Yardımcı (utility) sınıflar, küçük fonksiyonel servisler.
Performans:
Her çağrıda yeni bir nesne üretildiği için biraz daha fazla kaynak tüketebilir.
Örnek:
services.AddTransient<IMyService, MyService>();
IMyService her talep edildiğinde yeni bir MyService örneği sağlanır.
2. AddScoped
Yaşam Süresi: Her HTTP isteği (scope) için bir kez oluşturulur. Aynı istek içinde aynı örnek kullanılır, ancak farklı isteklerde farklı örnekler oluşturulur.
Kullanım Alanı:
İstek boyunca durumu koruması gereken servisler.
İstek yaşam döngüsüne bağlı işlemler (ör. veritabanı bağlamı, birim çalışmaları).
Performans:
İstek tabanlı servisler için verimlidir, çünkü her istek için yalnızca bir örnek oluşturulur.
Örnek:
services.AddScoped<IMyService, MyService>();
Tek bir HTTP isteği boyunca MyService bir kez oluşturulur ve tekrar kullanılır.
3. AddSingleton
Yaşam Süresi: Uygulama ömrü boyunca bir kez oluşturulur ve aynı örnek tekrar kullanılır.
Kullanım Alanı:
Yüksek maliyetli ilk yükleme işlemleri olan servisler (ör. önbellekleme, loglama).
Uygulama genelinde durum tutması veya global görevler için kullanılan servisler.
Performans:
İlk yükleme maliyeti yüksek servislerde verimlidir, çünkü sadece bir örnek kullanılır.
Bellek yönetimi ve çoklu iş parçacığı (thread safety) konularına dikkat edilmelidir.
Örnek:
services.AddSingleton<IMyService, MyService>();
MyService sadece bir kez oluşturulur ve uygulama boyunca aynı örnek kullanılır.
Davranış Farklılıkları
Özellik	AddTransient	AddScoped	AddSingleton
Yaşam Süresi	Her talep için yeni örnek	Her istek için tek örnek	Uygulama ömrü boyunca tek örnek
Kaynak Verimliliği	Ek yük oluşturabilir	İstek bazlı dengelidir	Global kullanımda en verimli
İsteklerde Kullanım	Her çağrıda yeni nesne	İstek içinde aynı nesne	Tüm isteklerde aynı nesne
Doğru Yaşam Süresini Seçmek
AddTransient:
Kısa ömürlü, hafif veya durumsuz servisler için.
AddScoped:
HTTP isteklerinin yaşam döngüsüne bağlı servisler için.
AddSingleton:
Global, uygulama genelinde paylaşılan servisler için.
Servisinizin amacı ve yaşam döngüsü gereksinimlerine göre doğru yaşam süresini seçerek kaynak kullanımını optimize edebilir ve uygulamanızın doğru şekilde çalışmasını sağlayabilirsiniz.



# Identity Server

![image](https://github.com/user-attachments/assets/68c89da5-7a84-4fc1-85a9-e5bffe1fed58)

Cargo mikroservisi için katmanlı mimari tercih ettik ve katmanlarımızı alttaki gibi belirledik. 

![image](https://github.com/user-attachments/assets/a5ac4e71-d08e-4b3b-b953-9c162b2ea016)

![image](https://github.com/user-attachments/assets/007dd20d-b617-428f-a928-142fba1b75f8)


Repository Design Pattern:
daha çok N Layer arch. üzerinde kullanılır.


entity framework içeriisnde her bir entity için class oluşturduk.

Katmanlı Mimari Nedir?

Katmanlı mimari, yazılım projelerini daha yönetilebilir, sürdürülebilir ve esnek hale getirmek için kullanılan bir tasarım desenidir. Her katman, belirli bir sorumluluğu yerine getirir ve birbirinden ayrılmıştır. Bu, kodun yeniden kullanılabilirliğini artırır ve geliştirme sırasında bağımlılıkları minimize eder.

Bu Yapıdaki Katmanlar
1.	Entity Layer:
	•	MultiShop.Cargo.EntityLayer
	•	Amaç: Veritabanı tablolarına karşılık gelen sınıflar burada tanımlanır. (Örneğin, CargoCompany, CargoCustomer vb.)
	•	Domain Class veya POCO Class olarak da adlandırılır. Bu sınıflar genellikle sade veri taşıma nesneleridir (DTO değildir).
2.	Dto Layer:
	•	MultiShop.Cargo.DtoLayer
	•	Amaç: Veri transfer objelerini (Data Transfer Object) içerir. API’de dış dünyaya gösterilecek veriler burada şekillendirilir. (Örneğin, bir CargoDetailDto ile sadece gerekli bilgileri API çıktısı olarak sağlayabilirsiniz.)
	•	Entity’leri dış dünyaya doğrudan göstermek yerine DTO kullanmak, veri güvenliği ve performans açısından önemlidir.
3.	Data Access Layer (DAL):
	•	MultiShop.Cargo.DataAccessLayer
	•	Amaç: Veritabanı ile etkileşim kuran sınıflar burada tanımlanır.
	•	Bu katman genellikle şu alt yapılardan oluşur:
	•	Abstract: Arayüzler (Interfaces) burada tanımlanır. Örneğin, ICargoCompanyDal, IGenericDal gibi.
	•	Concrete: Generic repository veya Entity Framework implementasyonları buradadır. Örneğin, EfCargoCompanyDal gibi sınıflar.
	•	Repositories: Genel CRUD işlemleri (Add, Update, Delete, GetById) için GenericRepository tanımlanır ve tüm veri sınıflarına bu yapı üzerinden erişilir.
4.	Business Layer:
	•	MultiShop.Cargo.BusinessLayer
	•	Amaç: İş mantığını (Business Logic) içerir. Veritabanı operasyonlarını kontrol eder, gerekli validasyonları yapar ve uygulamanın temel kurallarını yönetir.
	•	Data Access katmanını çağırarak veritabanı işlemlerini yürütür, ancak veri işleme, doğrulama veya dönüşüm gibi işlemleri de burada gerçekleştirir.
5.	Web API:
	•	MultiShop.Cargo.WebApi
	•	Amaç: Uygulamanın dış dünya ile iletişim kurmasını sağlar. HTTP isteklerini karşılar ve yanıt üretir.
	•	Bu katmanda genellikle Controller sınıfları bulunur. Controller’lar Business Layer üzerinden iş mantığını çalıştırır ve DTO’lar ile veri transferi sağlar.

Generic Repository Pattern Nedir?

Generic Repository Pattern, CRUD işlemleri için tekrar eden kodları azaltmak amacıyla kullanılan bir tasarım desenidir. Bu desen, tüm veritabanı işlemleri için tek bir genel sınıf (Generic Class) tanımlayarak bu sınıftan farklı entity türleri için faydalanmayı sağlar.

Design Mantığı
1.	Bağımsızlık ve Test Edilebilirlik:
	•	Katmanlı mimari sayesinde her katman birbirinden ayrıdır. Örneğin, Data Access katmanı Entity Framework yerine farklı bir ORM’ye geçmek istediğinizde kolayca değiştirilebilir.
2.	Kod Tekrarını Azaltma:
	•	Generic repository ile CRUD işlemleri için kod tekrarı yapmanıza gerek kalmaz.
3.	Esneklik:
	•	İleride her entity için farklı özellikler eklemek isterseniz (örneğin, EfCargoCompanyDal içine özel sorgular eklemek), bu yapı buna izin verir.
4.	SOLID Prensiplerine Uyum:
	•	Single Responsibility Principle: Her katman sadece kendi işini yapar (veritabanı işlemleri, iş mantığı, vs.).
	•	Dependency Inversion Principle: Business Layer, Data Access Layer’ın somut sınıflarına değil, arayüzlerine bağımlıdır. Bu sayede Dependency Injection uygulanabilir.

