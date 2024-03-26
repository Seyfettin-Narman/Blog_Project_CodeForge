namespace SeyfBlog.Web.NotifyMessages
{
    public static class Messages
    {
        public static class Post
        {
            public static string Add(string title)
            {
                return $"{title} başlıklı gönderi başarıyla eklendi.";
            }
            public static string Update(string title)
            {
                return $"{title} başlıklı gönderi başarıyla güncellendi.";
            }
            public static string Delete(string title)
            {
                return $"{title} başlıklı gönderi başarıyla silindi.";
            }
            public static string UndoDelete(string title)
            {
                return $"{title} başlıklı gönderi başarıyla tekrar eklenmiştir.";
            }
        }
        public static class Category
        {
            public static string Add(string Name)
            {
                return $"{Name} isimli kategori başarıyla eklendi.";
            }
            public static string Update(string Name)
            {
                return $"{Name} isimli kategori başarıyla güncellendi.";
            }
            public static string Delete(string Name)
            {
                return $"{Name} isimli kategori başarıyla silindi.";
            }
            public static string UndoDelete(string Name)
            {
                return $"{Name} isimli kategori başarıyla tekrar eklenmiştir.";
            }
        }
        public static class User
        {
            public static string Add(string userName)
            {
                return $"{userName} kullanıcısı başarıyla eklendi.";
            }
            public static string Update(string userName)
            {
                return $"{userName} kullanıcısı başarıyla güncellendi.";
            }
            public static string Delete(string userName)
            {
                return $"{userName} kullanıcısı başarıyla silindi.";
            }
        }
    }
}
