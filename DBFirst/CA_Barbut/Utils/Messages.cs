namespace CA_Barbut.Utils
{
    public class Messages
    {
        public static void MenuError()
        {
            Console.WriteLine("Hatalı Tuşlama!");
        }
        public static void BalanceError()
        {
            Console.WriteLine("Yeterli Bakiye Bulunamadı!");
        }
        public static void LoginError()
        {
            Console.WriteLine("Kullanıcı Adı veya Şifre Hatalı!");
        }
        public static void PointAddSuccess()
        {
            Console.WriteLine("Bakiye Eklendi!");
        }
        public static void PointAddError()
        {
            Console.WriteLine("Bakiye Eklenemedi!");
        }
        public static void PointRemoveSuccess()
        {
            Console.WriteLine("Bakiye Çekildi!");
        }
        public static void PointRemoveError()
        {
            Console.WriteLine("Bakiye Çekilemedi!");
        }
        public static void GameListAddError()
        {
            Console.WriteLine("Oyun Kaydı Eklenemedi!");
        }
        public static void GameHistoryListError()
        {
            Console.WriteLine("Sonuç Bulunamadı!");
        }
        public static void NotFound()
        {
            Console.WriteLine("Sonuç Bulunamadı!");
        }
    }
}
