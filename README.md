# Müzik Aletleri Çevrimiçi Mağazası Projesi

Projenin temel işlevi, müşterilere çeşitli enstrümanları inceleme, satın alma, yıldızlama ve yorum eklemelerini sağlayan bir müzik aletleri çevrimiçi mağazasını yönetmektir.

## Eklenen Özellikler

### Enstrümanlar için Oluştur, Güncelle ve Sil (Create, Update, Delete) Özelliği:
- Kullanıcılar, yeni enstrümanlar ekleyebilir, mevcut enstrümanları güncelleyebilir ve silebilirler.

### Markalar için Güncelleme (Update) Özelliği:
- Kullanıcılar, mevcut markaları güncelleyebilirler.

### Sepet Özelliği:
- Kullanıcılar, seçtikleri enstrümanları bir sepete ekleyebilir ve alışverişlerini daha sonra tamamlayabilirler.

### İletişim Kısmı Özelliği:
- Kullanıcılar, mağaza ile iletişime geçmek için iletişim formunu kullanabilirler.

### Pop-up Görünüm (View) Özelliği:
- Kullanıcılar için daha iyi bir deneyim sağlamak için pop-up görünümler kullanılır.

### Yorum Ekleme Özelliği:
- Kullanıcılar, enstrümanlar hakkında yorumlar ekleyebilirler.

## Eklenen Özellikler (Detaylı)

### Enstrümanlar için Oluştur, Güncelle ve Sil (Create, Update, Delete) Özelliği:
- **Entity**: `Instrument` adında bir model.
- **Controller**: `InstrumentsController` ile CRUD işlemleri için yönlendirme.
- **View**: `create.cshtml`, `edit.cshtml`, `delete.cshtml` gibi görünümler.

![HomePage](https://github.com/ahmet-kok/ReDoMusic/assets/111875259/c6f2ce3a-55f4-4b60-9223-4c82c5056940)

### Markalar için Güncelleme (Update) Özelliği:
- **Entity**: `Brand` adında bir model.
- **Controller**: `BrandController` ile güncelleme işlemi için yönlendirme.
- **View**: `index.cshtml` ve `addBrand.cshtml` gibi bir görünüm.

![Brands](https://github.com/ahmet-kok/ReDoMusic/assets/111875259/6c029d23-54b7-4d42-8258-c11e96a082bc)

### Sepet Özelliği:
- **Entity**: Sepet verileri için ayrı bir model oluşturulabilir.
- **Controller**: `ShoppıngCartController` ile sepet işlemleri için yönlendirme.
- **View**: Sepet içeriğini gösteren `Index.cshtml` gibi bir görünüm.

### İletişim Kısmı Özelliği:
- **Controller**: İletişim formunu işlemek için bir controller.
- **View**: İletişim formunu gösteren bir görünüm.

![Contacts](https://github.com/ahmet-kok/ReDoMusic/assets/111875259/b4bf3615-f47f-424e-9141-a2972500ad5a)

### Pop-up Görünüm (View) Özelliği:
- **Controller**: Pop-up görünümleri işlemek için uygun controller.
- **View**: Pop-up olarak görüntülenecek içeriği gösteren görünümler.

### Yorum Ekleme Özelliği:
- **Entity**: Yorumlar için bir model oluşturulabilir.
- **Controller**: Yorum ekleme ve görüntüleme işlemleri için bir controller.
- **View**: Yorumları gösteren ve eklemeyi sağlayan görünümler.

![Comments](https://github.com/ahmet-kok/ReDoMusic/assets/111875259/56b91979-5b81-4198-858c-4a3e0d03a686)

## Team Members
- Ahmet Kök
- Arzu Nisa Yalcınkaya
- Dilara Savcı
- Kadirhan Sağlam

## Görev Dağılımı

- Ahmet Kök
- Arzu Nisa Yalcınkaya
- Dilara Savcı
- Kadirhan Sağlam



