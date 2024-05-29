

# Gereksinimler
- .NET 6 SDK
- SQL Server
- Default ConnectionString'in çalışması için "order-management" adlı, "SA" kullanıcı adı ve "reallyStrongPwd123" şifreli bir SQL Server veritabanı (İsteğe Bağlı)

## Kurulum

### Depoyu Klonlayın
```sh
git clone git@github.com:atayikilmaz/order-management-service.git
cd order-management-service
```

### `appsettings.json` Dosyasında Veritabanı İçin Özel Bir ConnectionString İsteğe Bağlı Olarak Tanımlanabilir
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=[your_server];Database=[your_db];User=[User];Password=[password];Trusted_Connection=True"
  }
}
```

### Veritabanında Tabloları Oluşturmak İçin Migration
```sh
cd order-management-service
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Projeyi Derleyin ve Çalıştırın
```sh
dotnet build
dotnet run
```

Swagger UI otomatik olarak açılmalıdır.

## Kullanım

### Uç Noktalar (Endpoints)

#### Şirket (Company)
- **POST /api/companies** - Yeni bir şirket ekleyin
- **PUT /api/companies/{id}** - Şirket bilgilerini güncelleyin
- **GET /api/companies** - Tüm şirketleri listeleyin

#### Ürün (Product)
- **POST /api/products** - Yeni bir ürün ekleyin

#### Sipariş (Order)
- **POST /api/orders** - Yeni bir sipariş oluşturun
