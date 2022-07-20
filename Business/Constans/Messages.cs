using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductListed = "Ürünler Listelendi";
        public static string ProductDeleted = "Ürün Silindi";
        public static string BasketAdded = "Sepete Eklendi";
        public static string BasketDeleted = "Sepetten Silindi";
        public static string BasketListed = "Sepet Listelendi";
        public static string CategoryAdded = "Kategori Eklendi";
        public static string CategoryDeleted = "Kategori Silindi";
        public static string CategoryListed = "Kategoriler Listelendi";
        public static string CommentAdded = "Yorum Yapıldı";
        public static string CommentDeleted = "Yorum Silindi";
        public static string CommentListed = "Yorumlar Listelendi";
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserListed = "Kullanıcılar Listelendi";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kayıt olundu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Giriş Yapıldı";
        public static string ClaimAlreadyExists = "Yetki zaten mevcut";
        public static string FavoriteAdded = "Favorilere eklendi";
        public static string FavoriteListed = "Favoriler Listelendi";
        public static string FavoriteUpdated = "Favoriler güncellendi";
        public static string FavoriteDeleted = "Favorilerden Silindi";
        public static string WrongPasswd = "Yanlış Parola";
        public static string ChangeSuccess = "Parola değiştirme başarılı";
        public static string AddressAdded = "Adres eklendi.";
        public static string AddressDeleted = "Adres silindi.";
        public static string AddressUpdated = "Adres güncellendi.";
        public static string ProductRetrieved = "Listenmeye geri alındı";
        internal static string ProductUpdated = "Güncelleme işlemi yapıldı.";
    }
}