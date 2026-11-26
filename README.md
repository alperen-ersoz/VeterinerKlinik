# Veteriner Kliniği Randevu ve Hasta Takip Sistemi

## Proje Tanıtımı

ASP.NET Core MVC kullanılarak geliştirilen bu proje, veteriner kliniğinin hizmet, veteriner, hayvan, aşı ve randevu işlemlerinin yönetilmesini amaçlamaktadır.

## Kullanılan Teknolojiler

- ASP.NET Core MVC (.NET 10)
- C#
- SQL Server
- Entity Framework Core (Code First ve Migrations)
- ASP.NET Core Identity
- LINQ
- REST API
- Model Context Protocol (MCP)
- Bootstrap 5
- HTML, CSS, JavaScript ve jQuery

## Veritabanı Tasarımı

Sistem tek klinik üzerinden çalışacak şekilde tasarlanmıştır.

```mermaid
erDiagram
    ApplicationUser ||--o| Veterinarian : "has profile"
    ApplicationUser ||--o{ Pet : owns
    Clinic ||--o{ Service : provides
    Veterinarian ||--o{ VeterinarianService : provides
    Service ||--o{ VeterinarianService : includes
    Veterinarian ||--o{ VeterinarianAvailability : has
    Pet ||--o{ VaccinationRecord : receives
    Pet ||--o{ Appointment : has
    Veterinarian ||--o{ Appointment : attends
    Service ||--o{ Appointment : includes

    ApplicationUser {
        string Id PK
        string FirstName
        string LastName
        string Email
    }

    Clinic {
        int Id PK
        string Name
        string Address
        string PhoneNumber
    }

    Service {
        int Id PK
        int ClinicId FK
        string Name
        string Description
        int DurationMinutes
        decimal Price
        bool IsActive
    }

    Veterinarian {
        int Id PK
        string UserId FK,UK
        string Specialty
        string Biography
        bool IsActive
    }

    VeterinarianService {
        int VeterinarianId PK,FK
        int ServiceId PK,FK
    }

    VeterinarianAvailability {
        int Id PK
        int VeterinarianId FK
        enum DayOfWeek
        TimeOnly StartTime
        TimeOnly EndTime
    }

    Pet {
        int Id PK
        string OwnerId FK
        string Name
        string Species
        string Breed
        DateOnly BirthDate
        decimal Weight
        string PhotoPath
        bool IsActive
    }

    VaccinationRecord {
        int Id PK
        int PetId FK
        string VaccineName
        DateOnly VaccinationDate
        DateOnly NextDoseDate
    }

    Appointment {
        int Id PK
        int PetId FK
        int VeterinarianId FK
        int ServiceId FK
        DateTime StartDateTime
        int DurationMinutes
        decimal Price
        enum Status
        string ExaminationNote
        DateTime CreatedAt
    }
```

ApplicationUser, ASP.NET Core Identity altyapısındaki AspNetUsers tablosunu temsil etmektedir. Identity'nin diğer sistem tabloları diyagramda gösterilmemiştir.

## Planlanan Temel İş Kuralları

- Kullanıcılar Admin, Veterinarian ve Member rollerine sahip olacaktır.
- Hayvan sahipleri yalnızca kendi hayvanlarına ve randevularına erişebilecektir.
- Veterinerler yalnızca yetkin oldukları hizmetleri verebilecektir.
- Randevular veterinerin çalışma saatlerine uygun olmalıdır.
- Çakışan randevular oluşturulamayacaktır.
- Yeni randevular Pending durumunda başlayacaktır.
- Randevu oluşturulduğu andaki hizmet ücreti ve süresi korunacaktır.
- Geçmiş sağlık ve randevu kayıtlarının bütünlüğü korunacaktır.
- MVC, REST API ve MCP ortak servis katmanını kullanacaktır.

## Proje Durumu

Proje geliştirme aşamasındadır. Veritabanı tasarımı hazırlanmış olup uygulama özellikleri aşamalı olarak geliştirilecektir.
