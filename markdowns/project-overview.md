# Proje Özeti ve Vizyon: Açık Menü (OpenMenu)

## 1. Problem (Neden Bu Projeyi Yapıyoruz?)
İnsanlar bir restorana veya kafeye gitmeden önce fiyatları görmek istiyor ancak çoğu işletme menü fiyatlarını web sitelerinde veya sosyal medyalarında saklıyor. Yemeksepeti, Trendyol Yemek gibi platformlardaki fiyatlar ise komisyonlar nedeniyle restorandaki gerçek fiyatlardan %20-%30 daha yüksek. Bu durum tüketicide güven sorunu ve bilgi eksikliği yaratıyor.

## 2. Çözüm (Ürünümüz Ne Yapıyor?)
Açık Menü, kullanıcıların restoranların fiziksel menülerindeki veya QR menülerindeki "gerçek ve güncel" fiyatları şeffaf bir şekilde görebileceği bir platformdur (Web + Mobil Uygulama). 

## 3. İş Modeli ve Kullanıcı Akışı (Nasıl Çalışır?)
Uygulama, "Kullanıcı Tarafından Oluşturulan İçerik" (UGC) modeline dayanır:
1. **Veri Toplama:** Kullanıcılar (müşteriler), gittikleri mekandaki QR kodu veya menü görselini mobil uygulamamız üzerinden çekip/yükleyip bize gönderir.
2. **Arka Plan İşlemi (Backend):** Sistemimiz bu QR kodunu okur (decode eder). Hedef linkteki menü verisini veya görseldeki fiyatları işler.
3. **Yayınlama:** Doğrulanan güncel fiyatlar, web sitemizde ve uygulamamızda restoranın profiline yüklenir.
4. **Son Kullanıcı Deneyimi:** Başka bir kullanıcı web sitemizden "X Restoranı menü fiyatları" diye arattığında, komisyonsuz, mekandaki gerçek fiyat listesini görür.

## 4. Temel Değer Önerisi (Value Proposition)
- **Tüketiciler İçin:** Sürpriz hesaplar olmadan, gitmeden önce bütçe planlaması yapabilme.
- **Sistem İçin:** Başlangıçta 8-10 demo QR ile tohumlanacak (seed data) sistem, zamanla kullanıcıların gönüllü katkılarıyla (crowdsourcing) büyüyecek.

## 5. Kritik Geliştirici Notları (Claude İçin)
- Bu proje bir e-ticaret veya sipariş sistemi **değildir**. Sepete ekleme, ödeme alma veya sipariş takibi gibi modüller **yazılmayacaktır**.
- Uygulamanın tek amacı **"Sadece Oku (Read-Only) Fiyat Şeffaflığı"** sağlamaktır.
- Okuma (Read) işlemleri, Yazma (Write) işlemlerinden 100 kat daha fazla olacaktır. Bu yüzden Redis ve Caching stratejileri sistemin kalbidir.