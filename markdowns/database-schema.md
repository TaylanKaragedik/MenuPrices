# Veritabanı Şeması (PostgreSQL)

## Tables
1. **Restaurants**: Id, Name, Address, Location (Point), LogoUrl, IsActive.
2. **Menus**: Id, RestaurantId, Title (Örn: Kahvaltı, Akşam Yemeği), IsActive.
3. **Categories**: Id, MenuId, Name (Örn: Başlangıçlar, İçecekler).
4. **Products**: Id, CategoryId, Name, Description, Price (Decimal), Currency, LastUpdated.
5. **QRRequests**: Id, ImageUrl, RawUrl (Decoded), Status (Pending, Processed, Failed), CreatedBy.

## Relationships
- Restaurant -> Menus (1:N)
- Menu -> Categories (1:N)
- Category -> Products (1:N)