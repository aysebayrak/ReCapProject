using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //static de newlemiyoruz
    public static class Messages
    {
        
        public static string CarAdded = "Araba Eklendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarUpdated = "Araba Güncellendi";
        public static string CarDailyPriceInvalid = "Araba Fiyat Biligisi  Geçersiz";

        public static string BrandAdded = " Marka  Eklendi";
        public static string BrandDeleted = "Marka Silindi";

        
        public static string BrandUpdated = "Marka Güncellendi";
        public static string BrandBrandNameInvalid = "Araba Markası  Geçersiz";

        public static string ColorAdded = " Renk  Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk  Güncellendi";
        public static string MaintenanceTime = "sistem bakımda";
        public static string CarsListed = "ürünler listelendi";

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri Güncellendi";

        public static string RentalAdded = "Araba Kiralama işlemi baraşıyla gerçekleşti.";
        public static string RentalDeleted = "Araba Kiralama işlemi iptal edildi.";
        public static string RentalUpdated = "Araba Kiralama işlemi güncellendi.";
        public static string RentalAddedError = "Aracın kiraya verilebilmesi için önce teslim edilmesi gerekir.";
        public static string RentalReturned = "Kiraladığınız araç teslim edildi";

        public static string UserAdded = "Kullanıcı Eklendi";
        public static string USerDeleted = "Kullanıcı Silindi";
        public static  string UserUpdated = "Kullanıcı Güncellendi";

        public static string ImageLimitExpiredForCar = "Bir Arabaya maksimum 5 fotoğraf yüklenebilir";
        public static string CarImageMustBeExists = "Böyle bir resim bulunamadı";

        public static string AuthorizationDenied = "yetkiniz  yok";
        public static string UserRegistered ="Kayıt oldu";
        public static string UserNotFound = "kullanıcı bulunamadı";
        public static string PasswordError = "parola hatası ";

        public static string SuccessfulLogin = "başarılı giriş";
        public static string UserAlreadyExists = "kullanıcı mevcut";
        public static string AccessTokenCreated = "token oluşturuldu ";
        public static string CarListed = "Arabalar Listelendi";

        public static string CarGetAllSuccess = "Araçlar Listelendi";
        public static string UpdatedCar = "Araba Güncellendi";

        public static string RentalsListed = "Kiralanan Araçlar";

        public static string CreditCardDeleted = "Kart Başarı İle Silinidi";
        public static string CreditCardUpdated = "Kart Başarı İle Güncellendi";
        public static string CreditCardAdded = "Kart Başarı İle Eklendi";

        public static string CreditCardExist = "Kredi Kartı Bulunmakta";

        public static string NotCarAvailable = "İstenilen Araba Suan Başkası Tarafından Kiralı";
        public static string NotEnough = "Fimdeks Puanınız Yetersiz";
    }
}
