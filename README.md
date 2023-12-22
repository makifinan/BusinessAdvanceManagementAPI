# İş Avans Yönetim Sistemi Web API Projesi

Bu repo, BusinessAdvanceManagement projesi için geliştirilen Web API projesini içermektedir. Aşağıda proje ile ilgili detayları bulabilirsiniz.

## Kullanılan Teknolojiler

- **ASP.NET Core Web API:** 
- **Dapper:**
- **Katmanlı Mimari:** Proje, katmanlı mimari prensiplerine göre tasarlanmıştır. Aşağıda bulunan katmanlar mevcuttur:
  - **API Katmanı:** Gelen istekleri işleyen, cevapları oluşturan ve uygun iş mantığı katmanlarına yönlendiren katman.
  - **Servis Katmanı:** İş mantığının yürütüldüğü katman. Veritabanı işlemleri, hesaplama ve diğer işlemler burada gerçekleştirilir.
  - **Veri Erişim Katmanı (Repository):** Dapper aracılığıyla veritabanı işlemlerini yöneten katman.
  - **Domain Katmanı:** Veritabanı tablolarını temsil eden modellerin bulunduğu,DTO'ların bulunduğu katman.





