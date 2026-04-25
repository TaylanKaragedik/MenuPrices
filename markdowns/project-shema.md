MenuPrices/
├── markdowns/
│   ├── project-overview.md
│   ├── project-plan.md
│   ├── project-rules.md
│   ├── database-schema.md
│   ├── project-shema.md
│   ├── skills.md
│   └── detailed-execution-plan.md
├── docker-compose.yml              ← postgres:5432 + redis:6379
├── backend/
│   ├── OpenMenu.slnx
│   └── src/
│       ├── OpenMenu.Domain/
│       │   ├── Common/
│       │   │   └── BaseEntity.cs
│       │   ├── Entities/
│       │   │   ├── Restaurant.cs
│       │   │   ├── Menu.cs
│       │   │   ├── Category.cs
│       │   │   ├── Product.cs      ← Extras: JSONB
│       │   │   └── QRRequest.cs
│       │   └── Enums/
│       │       └── QRRequestStatus.cs
│       ├── OpenMenu.Application/
│       │   └── Common/
│       │       └── Result.cs       ← Result\<T\> + Result
│       ├── OpenMenu.Infrastructure/
│       │   └── Persistence/
│       │       ├── ApplicationDbContext.cs
│       │       └── Configurations/
│       │           ├── RestaurantConfiguration.cs
│       │           ├── MenuConfiguration.cs
│       │           ├── CategoryConfiguration.cs
│       │           ├── ProductConfiguration.cs
│       │           └── QRRequestConfiguration.cs
│       └── OpenMenu.WebAPI/
│           ├── Middleware/
│           │   └── GlobalExceptionHandler.cs
│           ├── Program.cs
│           └── appsettings.json    ← DefaultConnection + Redis
├── frontend/                       ← Next.js buraya (Task 4.1)
└── mobile/                         ← Flutter buraya (Task 5.1)
