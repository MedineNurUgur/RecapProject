using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ColorAdded = "Renk Eklendi.";
        public static string ColorDeleted = "Renk Silindi.";
        public static string ColorUpdated = "Renk Güncellendi.";

        public static string BrandAdded = "Marka Eklendi.";
        public static string BrandDeleted = "Marka Silindi.";
        public static string BrandUpdated = "Marka Güncellendi.";

        public static string CarAdded = "Araba Eklendi";
        public static string CarDailyPriceInvalid = "Günlük ücret belirlemelisiniz";
        public static string CarDeleted = "Araba Silindi";
        public static string CarUpdated = "Araba güncellendi.";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı Silindi.";
        public static string UserUpdated = "Kullanıcı Güncellendi.";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri Silindi.";
        public static string CustomerUpdated = "Müşteri Güncellendi.";

        public static string RentalAdded = "İşlem eklendi";
        public static string RentalDeleted = "İşlem Silindi.";
        public static string RentalUpdated = "İşlem Güncellendi.";
        public static string CarRented = "Araç dolu.";

        public static string CarImageAdded = "Resim eklendi";
        public static string CarImageDeleted = "Resim Silindi.";
        public static string CarImageUpdated = "Resim Güncellendi.";
        public static string CarImageCountOfCarError = "Bir arabaya 5 den fazla fotoğraf yüklenemez.";
        public static string DefaultCarImageNotFound = "Resim Yok";
    }

}
