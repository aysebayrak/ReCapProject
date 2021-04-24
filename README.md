# ReCapProject
Kurumsal, Katmanlı Mimari yapısı kullanılarak *SOLID* kuralları dahilinde oluşturulmuş, *C#* dili ile yazılmıştır.<br/>
Araba kiralama fikri üzerine oluşmuştur .
## Katmanlar
- **Core** : Projenin çekirdek katmanı olup içerisinde evrensel operasyonlar  yazılmıştır.
- **DataAccess** : Projede veritabanımız ile bağlantımızı kurduğumuz katmanımızdır.
- **Entities** : Projede veritabanındaki tablolarımızın projemizde nesne olarak kullanılması için oluşturuldu . İçerisinde DTO nesnelerinide içermekte.
- **Business** : Projemizin iş katmanıdır. Türlü iş kuralları; Veri kontrolleri, validasyonlar, IoC Container'lar ve yetki kontrolleri için yazılmış katmandır.
- **WebAPI** : Projenin Restful API Katmanıdır. İçerisinde kullanılan metodlar: Get, Post, Put, Delete metodlarıdır.
## Kullanılan Teknolojiler
- .Net Core 3.1
- Restful API
- Result Türleri
- Interceptor
- Autofac
  - AOP, Aspect Oriented Programming 
    - Caching
    - Performance
    - Transaction
    - Validation
- Fluent Validation
- Cache yönetimi
- JWT Authentication
- Cross Cutting Concerns
  - Caching
  - Validation
- Extensions
  - Claim
    - Claim Principal
  - Error Handling
    - Error Details
    - Validation Error Details

