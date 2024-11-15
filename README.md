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

