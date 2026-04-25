# Detaylı Yürütme Planı (Execution Backlog)

Bu dosya, projenin adım adım geliştirme talimatlarını içerir. Her bir "Task" tek bir geliştirme oturumunda/promptunda tamamlanacak şekilde tasarlanmıştır. Bir task bitmeden diğerine geçilmemelidir.

## PHASE 1: Solution Kurulumu ve Temel Altyapı (.NET 10)

- [x] **Task 1.1: Solution ve Projelerin Oluşturulması**
  - [x] `OpenMenu.sln` adında boş bir solution oluştur.
  - [x] Clean Architecture klasör yapısına uygun olarak şu class library projelerini oluştur ve solution'a ekle: `OpenMenu.Domain`, `OpenMenu.Application`, `OpenMenu.Infrastructure`.
  - [x] `OpenMenu.WebAPI` adında bir .NET 10 Web API projesi (Native AOT uyumlu) oluştur ve solution'a ekle.
  - [x] Proje referanslarını ayarla (WebAPI -> Application & Infrastructure, Infrastructure -> Application, Application -> Domain).

- [x] **Task 1.2: Domain Katmanı Temelleri**
  - [x] `Domain` projesi içinde `Common` klasörü oluştur.
  - [x] `BaseEntity` (Id, CreatedAt, UpdatedAt özellikleri içeren) abstract sınıfını yaz.
  - [x] `Restaurants`, `Menus`, `Categories`, `Products`, `QRRequests` entity'lerini oluştur ve `BaseEntity`'den türet.

- [ ] **Task 1.3: Standart API Response ve Exception Handling**
  - [ ] `Application` katmanında tüm API dönüşlerini standardize edecek `Result<T>` veya `ApiResponse` modelini (Success, Data, ErrorMessage) yaz.
  - [ ] `WebAPI` katmanında Global Exception Handler Middleware'ini oluştur. (Beklenmeyen hataları yakalayıp standart formata çevirecek).

- [ ] **Task 1.4: Veritabanı ve Docker Altyapısı**
  - [ ] Root dizinde `docker-compose.yml` oluştur. İçine PostgreSQL (latest) ve Redis imajlarını, gerekli environment variable'lar ile (şifre, port) tanımla.
  - [ ] `Infrastructure` katmanına `Npgsql.EntityFrameworkCore.PostgreSQL` paketini kur.
  - [ ] `ApplicationDbContext` sınıfını oluştur, `DbSet`'leri tanımla ve entity'ler arasındaki ilişkileri (One-to-Many vb.) `OnModelCreating` içinde Fluent API ile yapılandır.
  - [ ] Ürün detayları veya ekstra opsiyonlar için esneklik sağlamak adına ilgili alanlarda JSONB konfigürasyonunu yap.

- [ ] **Task 1.5: Dependency Injection (DI) Kurulumu**
  - [ ] `WebAPI` katmanında `Program.cs` dosyasını düzenle.
  - [ ] Db context, Redis (StackExchange.Redis veya IDistributedCache), MediatR ve FluentValidation servis kayıtlarını (service registrations) yap.
  - [ ] İlk Entity Framework Core migration'ını (`InitialCreate`) oluştur.

---

## PHASE 2: Core Domain Logic & API Endpoint'leri

- [ ] **Task 2.1: Restoran Yönetimi (CQRS ile)**
  - [ ] `Application` katmanında Restoranlar için `CreateRestaurantCommand`, `GetRestaurantByIdQuery`, `GetAllRestaurantsQuery` ve bunların handler'larını MediatR kullanarak yaz.
  - [ ] Girdi doğrulamaları için ilgili Command'lere FluentValidation kurallarını yaz.
  - [ ] `WebAPI` katmanında `RestaurantsController` oluştur ve endpoint'leri bağla.

- [ ] **Task 2.2: Menü, Kategori ve Ürün Yönetimi**
  - [ ] Menü, Kategori ve Ürün ekleme/listeleme işlemleri için gerekli Command ve Query'leri (MediatR) yaz.
  - [ ] `MenusController`'ı oluştur.
  - [ ] Özellikle "Bir restoranın tüm menüsünü getir" query'sini yaz. Bu query çok sık çağrılacağı için performansa odaklan.

- [ ] **Task 2.3: Redis Caching Entegrasyonu**
  - [ ] `GetMenuByRestaurantIdQuery` (veya benzeri bir okuma query'si) için Redis Cache mekanizmasını entegre et.
  - [ ] Eğer menü Redis'te varsa veritabanına gitmeden direkt döndür.
  - [ ] Menüye yeni bir ürün eklendiğinde (Command çalıştığında) ilgili restoranın Redis cache'ini invalid edecek (silecek) yapıyı kur.

---

## PHASE 3: QR İşleme ve Background Jobs

- [ ] **Task 3.1: QR Görsel Upload Endpoint'i**
  - [ ] Kullanıcıdan bir görsel (IFormFile) alacak `UploadQRCommand` ve endpoint'ini yaz.
  - [ ] Görseli sunucuda/lokalde geçici bir klasöre kaydet.
  - [ ] Veritabanındaki `QRRequests` tablosuna "Pending" statüsünde bir kayıt at.

- [ ] **Task 3.2: Background Worker (Arka Plan Görevi) Kurulumu**
  - [ ] Sistemi yormamak için `QRRequests` tablosundaki "Pending" talepleri okuyacak bir .NET Hosted Service (BackgroundService) veya Quartz.NET/Hangfire altyapısı kur.
  - [ ] Worker servisi belirli aralıklarla (örn. her 1 dakikada bir) çalışacak şekilde ayarla.

- [ ] **Task 3.3: QR Decode İşlemi (Mock/Dummy)**
  - [ ] Background worker içinde, kaydedilen görseli okuyup içindeki URL'yi çıkartacak mantığı (şimdilik ZXing.Net gibi bir kütüphane ile veya Dummy bir string döndürecek şekilde) entegre et.
  - [ ] Okunan URL'yi `QRRequests` tablosuna kaydet ve statüyü "Processed" (veya menü işleme kısmına geçecekse farklı bir statü) olarak güncelle.

---

## PHASE 4: Frontend (Next.js) MVP Kurulumu

- [ ] **Task 4.1: Next.js Proje Başlangıcı**
  - [ ] `frontend` klasörü oluşturup Next.js (App Router), TailwindCSS ve TypeScript kurulumunu yap.
  - [ ] Axios veya Fetch API ile backend'e (örn: `localhost:5000`) istek atacak temel servis katmanını kur.

- [ ] **Task 4.2: Ana Sayfa ve Arama**
  - [ ] Restoranların listelendiği veya aranabildiği (Search Bar) ana sayfayı geliştir.
  - [ ] SEO uyumlu olacak şekilde metadata (title, description) tanımlamalarını yap.

- [ ] **Task 4.3: Menü Detay Sayfası**
  - [ ] Dinamik routing (`/restaurant/[id]`) ile restoran detay sayfasını oluştur.
  - [ ] SSR (Server-Side Rendering) kullanarak menü verisini backend'den (veya Redis'ten) hızlıca çekip ekranda kategorilerine göre listele.

---

## PHASE 5: Mobil (Flutter) MVP Kurulumu

- [ ] **Task 5.1: Flutter Proje İskeleti**
  - [ ] `mobile` klasöründe Flutter projesini başlat.
  - [ ] MVVM veya Riverpod gibi bir state management çözümü ile temel klasör yapısını kur.
  - [ ] Bottom Navigation Bar (Ana Sayfa, QR Okut) oluştur.

- [ ] **Task 5.2: Kamera ve QR Gönderme Modülü**
  - [ ] `camera` veya `image_picker` paketlerini kullanarak kullanıcının fotoğraf çekmesini/seçmesini sağla.
  - [ ] Çekilen görseli multipart form data olarak backend'deki QR upload endpoint'ine gönderen API entegrasyonunu yap.
