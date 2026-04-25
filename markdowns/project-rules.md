# Proje Kuralları: Açık Menü (OpenMenu)

## Teknoloji Yığını
- **Backend:** .NET 10.0 Web API (C# 14)
- **Database:** PostgreSQL (EF Core & Npgsql)
- **Caching:** Redis (Menü okuma işlemleri için zorunlu)
- **Frontend:** Next.js (App Router, TailwindCSS)
- **Mobile:** Flutter
- **Mimari:** Modular Monolith & Clean Architecture

## Backend Standartları
- Clean Architecture katmanlarına (Domain, Application, Infrastructure, WebAPI) sadık kalınacak.
- CQRS deseni MediatR kütüphanesi ile uygulanacak.
- Tüm veritabanı işlemleri asenkron (async/await) olacak.
- Validasyonlar için FluentValidation kullanılacak.
- PostgreSQL tarafında esnek menü yapıları için JSONB kolonları tercih edilecek.

## Kod Yazım Prensipleri
- Kodlar temiz, okunabilir ve SOLID prensiplerine uygun olmalı.
- Global Exception Handling ve standart bir API Response modeli kullanılmalı.
- Solo geliştirici olduğum için aşırı mühendislikten (over-engineering) kaçınılmalı, sürdürülebilirliğe odaklanılmalı.