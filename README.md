Proje katmanlı mimari ile ASP.NET Core MVC yapısıyla oluşturulmuştur.

Core katmanı, uygulamanın temel işlevlerini barındırır.

Entity katmanı, veritabanında bulunan tabloları temsil eden sınıfları içerir.

Data katmanı, veritabanı işlemlerinin gerçekleştiği yerdir.

Servis katmanı, iş kurallarının oluşturulduğu ve kullanıcı taleplerini karşıladığımız katmandır.

Web kısmında ise kullanıcı arayüzünü oluştururuz ve kullanıcıların uygulama ile etkileşimde
bulunmasını sağlarız.

Veritabanı olarak SQL Server kullanılmıştır.
Veritabanı işlemlerini OOP mantığına uygun bir şekilde gerçekleştirmek için Entity Framework kullanılmıştır.

Fluent Validation ile istenilen doğrulama kurallarını tanımlamış olduk.

Kimlik doğrulama ve yetklendirme işlemleri yapıldı.

AutoMapper ile sınıflar arası veri aktarımını otomatikleştirmiş olduk.

Gerçekleştirilen işlemlerden sonra kullanıcı arayüzüne bildirim göndermek için ise NToastNotify kullanılmıştır.

Admin bölümüne girmeyi denediğimizde bizi aşağıdaki resimdeki gibi bir login ekranı karşılıyor olacak:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/5afdab9a-aa6f-462d-979e-99ef404ad4e7)


Giriş yapabilmeniz için blog sayfası admini(Topmanager) admin panel üzerinden sizleri blog sayfasına abone yapması gerekiyor.
Yazarlara admin rolü, abonelere ise kullanıcı rolü veriliyor. Adminlerin gönderi ekleme, güncelleme ve silme yetkisi bulunuyor ayrıca kategori ekleme,güncelleme ve silme yetkisi bulunuyor. Kullanıcı ekleme ve güncelleme
yetkisi bulunsa da kullanıcı silme yetkisi sadece topmanager rolüne açıktır. Kullanıcı rolünde ise sadece gönderileri ve kategorileri listeleme özelliği etkindir. Başka hiç bir yetkisi yoktur. Topmanager ve admin rolünde 
gönderiler veya kategoriler silindiğinde direkt içeriğin kaybolmasını önlemek adına bir geri dönüşüm kutusu projeye eklendi. İstenilen zaman bu geri dönüşüm kutusundan kategori veya gönderiyi geri getirebilirler.
Topmanager ve adminde dashboard sidebarı böyle gözükürken: 
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/bd7fb617-7181-4c65-a86e-4c5943cf7f35)

kullanıcı rolünde diğer yerlere erişimini engellemek adına böyle bir görüntü vardır: 

![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/bff7d5db-809e-43d7-8644-1bd0104c54de)

admin panele giriş yaptığımızda bizi böyle bir ekran karşılıyor olacak: 
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/9ec47f9b-238b-4c74-b7a4-ff613748ff52)

gönderileri listelerini görüntülemek için post management sekmesine tıklayınız karşısınızdaki ekran aşağıdaki fotoğraf gibi olacaktır:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/87a40b26-e84f-475b-98ae-2193b08bcb69)

Eğer Topmanager ve admin değilseniz bu sayfa sizlere aşağıdaki fotoğraftaki gibi gözükecektir ve gönderi eklemenize, düzeltmenize veya silmenize engel olmak için gerekli componentler sizlere gösterilmeyecektir
(Gözükseydi bile bir erişim engeli sayfası oluşturulmuştur.) :
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/b29cdd5f-3277-4c62-8bbb-8a11bb5f6a49)

Add post butonuna tıkladığımızda bizi aşağıdaki fotoğraftaki gibi bir sayfa bekliyor olacak:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/d7421b9f-067f-4bf8-977e-2e1354239abf)

bu sayfada gerekli bilgileri girip submite bastığınızda gönderi ekleme işlevini yerine getirmiş oluyoruz. Eğer zorunlu alanlar doldurulmadıysa validasyon işlemlerinin uyarıları ile uyarılıyoruz.
Ayrıca uyarılar türkçeleştirilmiştir. Örneğini aşağıdaki fotoğrafta görebilirsiniz:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/b5f6741f-1e91-4367-aff4-d08d3fc57acb)

İlgili yerler doldurulup submite basıldığında gönderi başarılı bir şekilde gönderildi ise NtoastNotify ile sağ alt köşede kullanıcıya bilgi veriyoruz. Örneğini aşağıdaki fotoğrafta görebilirsiniz:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/ec6f8480-6345-467a-bcb5-e1ab30fa8014)

Eklenen gönderi hakkında bir güncelleme yapmak için listedeki düzenleme işlemi butonuna bastığımızda eski veriler ile beraber bizi güncelleme ekranı karşılıyor olacak. Örneğini aşağıdaki fotoğrafta görebilirsiniz.
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/8d8f8ddb-92fc-45be-ab62-d5e9cdc42540)

Eğer eklenen gönderiyi silmek isterseniz sil butonuna tıklayabilirsiniz. Sil butonuna tıkladığınızda size silmek istediğinizden emin olduğunuz konusunda bir mesaj gelecektir. Eğer Tamam butonuna tıklarsanız
gönderi silinecek iptal butonuna basarsanız herhangi bir değişiklik olmayacaktır:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/8e74138c-c68f-4ee8-9e0b-e0ec4b449215)

Silinen bir gönderi veya kategoriyi geri yüklemek için Deleted Items alanında hem gönderi hem kategori için iki alan bulunmaktadır:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/36ff9930-7222-4fe2-8d31-ff8aa85c3354)

Silinen gönderi veya kategoriyi geri getirmek için Deleted Items içindeki ilgili yere tıkladığınızda sizi aşağıdaki fotoğraftaki gibi bir sayfa karşılıyor olacak: 
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/58d0166a-60e4-42b7-9cbb-bfc51bf4b157)

Geri dönüşüm butonuna bastığınızda size uyarı olarak bu veriyi geri getirmek istediğinizden emin misiniz sorusu sorulacak. Tamam butonuna basarsanız veriyi geri döndürecektir. İptal tuşuna basarsanız herhangi bir
eylemde bulunmayacaktır:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/34bd7182-6c67-4e01-a073-f8bc8bc7d129)

Var olan kategori listesini görmek için Category Management kısmına tıklayınız. Sizi aşağıdaki fotoğraftaki gibi bir alan bekliyor olacaktır:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/61fb8bfb-498a-4724-b1bf-84a7c3103ee7)

Kategori eklemek için Add Category butonuna tıklayınız. Butona tıkladığınızda sizi şöyle bir alan bekliyor olacaktır:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/3e86425f-ce96-42a7-adaa-1695e6861619)

Kategori alanını boş bırakıp submit butonuna bastığınız takdirde validasyondan bir hata mesajı alacaksınız. Aşağıdaki fotoğrafta bu hata mesajını görebilirsiniz:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/948518b6-ea9b-47a4-accd-85a5c8a5a3a6)

Var olan kategoriyi güncellemek istediğinzde Category Management alanında bulunan düzenleme butonuna tıklayabilirsiniz. Bu butona tıkladığınızda içinde hazır eski verisi bulunan kategori alanı
aşağıdaki fotoğraftaki gibi sizi bekliyor olacak:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/e3c616d9-8548-45ae-8a5a-22fe504590e4)

Kategori silmek ise gönderi silmekle aynı işlemleri gerektiyor.

Kullanıcı bilgilerini görmek için Users kısmına tıklayınız. Bu kısma tıkladığınızda sizi aşağıdaki fotoğraftaki gibi bir alan bekliyor olacaktır:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/01f2ebb7-29d4-4ca7-b898-81a5444bc5fb)

Kullanıcı eklemek istiyorsanız Add User butonuna tıklayabilirsiniz. Butona tıkladığınızda sizi aşağıdaki fotoğraftaki gibi bir alan bekliyor olacak:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/e5dc7e15-46d3-4b8b-b163-b4f0b65b8201)

Gerekli yerleri boş bırakmanız halinde validasyon kuralları devreye girecek ve size hata mesajları gösterilecektir. Örneğini aşağıdaki fotoğrafta görebilirsiniz:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/b426d380-5a30-4999-bff7-5629e43cc105)

Var olan bir kullanıcıyı güncellemek istiyorsanız User kısmında güncelleme butonuna tıklayabilirsiniz. Bu butona tıkladığınızda içinde hazır verileri bulunan kullanıcı bilgileri önünüze gelecektir.
Örneğini aşağıdaki fotoğrafta görebilirsiniz:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/5474f8bf-24e7-4120-bb8f-78b9251aa76f)

Kullanıcı silme işlemleri ise gönderi ve kategori silme işlemleriyle tamamen aynıdır.

Admin paneli içerisinde profilinizi görüntülemek için sağ üstte bulunan aşağıdaki fotoğraftaki My Profile alanına tıklayınız:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/5e817716-f67e-46cb-8f80-c6dee456c096)

Bu alana tıkladığınızda sizi aşağıdaki fotoğraftaki gibi bir alan bekliyor olacaktır:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/5e9a8e8b-1cbd-4132-8d57-519812454362)
Burada istediğiniz zaman profilinizi güncelleyebilirsiniz. Profilinizi güncelledikten sonra mevcut parolanızı password alanına girmeniz gerekiyor aksi takdirde bir hata veriyor ve güncellemenize izin vermeyecektir.
Opsiyonel olarak parolanızı güncellemek isterseniz new password alanını da doldurup profili güncelle butonuna basabilirsiniz.

Admin panel oturumunuzu sonlandırmak istiyorsanız aşağıdaki fotoğrafta bulunan Log out kısmına tıklayınız:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/81b3575b-9095-485b-b6d1-1f36e16bfb89)

Blog sayfamızın ön yüzüne geldiğimizde ise bizi aşağıdaki fotoğraftaki gibi bir sayfa bekliyor olacak:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/33743a11-efed-4b7a-a297-b55fa605bf85)

Admin panelde eklediğimiz tüm gödneriler anında bu sayfaya yansımış oluyor. Her gönderinin gönderim zamanı, gönderen kişi,kategori, görüntüleme sayısı ve yorumlar kısmı vardır.(görüntüleme sayısı ve yorum kısmı yapım aşamasındadır.)
Her gönderinin sağ altında ise Devamını oku kısmı vardır. Bu kısma tıkladığınızda gönderinin tüm yazısına ulaşabilirsiniz. Örneğini aşağıdaki fotoğrafta görebilirsiniz:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/7872647e-e83d-4f43-b29a-226c34239393)

Sayfalar aşağıdaki fotoğrafın en aşağısında görmüş olduğunuz gibi bir pagging işlemine tabii tutulmuştur. Böylece belleği etkin ve verimli kullanmak amaçlanmıştır. Her sayfada en fazla 3 gönderi gözükmektedir.
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/666218a3-3777-496a-aa89-60cfa29ad8a6)

Eklenen kategoriler sayfanın sağ yanında aşağıdaki fotoğraftaki gibi sıralanmıştır:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/ef0649f7-ae30-43c5-9184-482794b28f09)

kategoriye basıldığında ekrana sadece o etikete sahip gönderiler gelmektedir.Örneğin donanım kategorisine bastığımda sayfa şu şekilde olmaktadır:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/88aa325e-a155-42d2-a0a0-ad5b81f1aa07)

Ayrıca aşağıdaki fotoğrafta bulunan Search kısmında istenilen string değerlere göre gönderilerde arama yaparak ilgili gönderiler ekrana getirilmektedir. Aşağıda bu adımlar gösterilmektedir:
![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/eabb84c5-1a01-49bd-af4b-17309013ea88)

![image](https://github.com/Seyfettin-Narman/Blog_Project_CodeForge/assets/105067376/94d2c564-cd5f-4fe9-bd92-f36745fc4cea)

Bu sayfanın sağ üstünde ise sizleri kendi LinkedIn ve Instagram hesaplarıma götürecek iki ikon bıraktım.


















































