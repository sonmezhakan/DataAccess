using CA_Barbut.Concrete;
using CA_Barbut.Models;
using CA_Barbut.Utils;

namespace CA_Barbut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userId = 0;
            string userName = "";
            string password = "";
            byte menuSayac = 1;
            byte menuSecim = 0;

            UserRepository userRepository = new UserRepository();
            BalanceRepository balanceRepository = new BalanceRepository();
            GameHistoryRepository gameHistoryRepository = new GameHistoryRepository();
            Random rnd = new Random();

            #region Giris

            void Login()
            {
                Console.Write("Kullanıcı Adı:");
                userName = Console.ReadLine();
                Console.Write("Şifre:");
                password = Console.ReadLine();
                LoginValidate(userName, password);
            }
            void LoginValidate(string userName, string password)
            {
                if (userRepository.Validate(userName, password) == true)
                {
                    LoginPoint();//Kullanıcı her giriş yaptığında 500 puan ekleniyor.
                    MenuList();
                }
                else
                {
                    Messages.LoginError();
                    userName = "";
                    password = "";
                    Login();
                }
            }
            void LoginPoint()
            {
                balanceRepository.PointAdd(BalanceInfo(500));
            }
            #endregion

            #region Menu
            void MenuList()
            {
                while (true)
                {
                    foreach (string item in Menu.menus)
                    {
                        Console.WriteLine($"{menuSayac} {item}");
                        menuSayac++;
                    }
                    menuSayac = 1;
                    MenuSelection();
                }
            }
            void MenuSelection()
            {
                switch (Selection.MenuSelection())
                {
                    case 1:
                        MenuGameList();
                        break;
                    case 2:
                        MenuBalanceList();
                        break;
                    default:
                        Messages.MenuError();
                        break;
                }
                menuSecim = 0;
            }
            void MenuGameList()
            {
                foreach (string item in Menu.gameMenus)
                {
                    Console.WriteLine($"{menuSayac} {item}");
                    menuSayac++;
                }
                menuSayac = 1;
                MenuGameSelection();
            }


            void MenuGameSelection()
            {
                switch (Selection.MenuSelection())
                {
                    case 1:
                        Game();
                        break;
                    case 2:
                        GameHistory();
                        break;
                    default:
                        Messages.MenuError();
                        break;
                }
            }

            void MenuBalanceList()
            {
                foreach (string item in Menu.balanceMenus)
                {
                    Console.WriteLine($"{menuSayac} {item}");
                    menuSayac++;
                }
                menuSayac = 1;
                MenuBalanceSelection();
            }
            void MenuBalanceSelection()
            {
                switch (Selection.MenuSelection())
                {
                    case 1:
                        BalanceShow();
                        break;
                    case 2:
                        BalancePointRemove();
                        break;
                    case 3:
                        BalancePointAdd();
                        break;
                    default:
                        Messages.MenuError();
                        break;
                }
            }
            #endregion

            #region Oyun Islemleri
            int ZarAt()
            {
                return rnd.Next(1, 7);
            }

            void Game()
            {
                try
                {
                    Console.WriteLine("Yatırılacak Puan:");
                    int point = int.Parse(Console.ReadLine());
                    if (BalanceControl(point) == true)//Bakiyenin yeterli olup olmadığını kontrol eder.
                    {
                        balanceRepository.PointRemove(BalanceInfo(point));//Yatırılan puanı kullanıcı bakiyesinden düşer
                        int totalPoint = point * 2;//Toplam bakiyeyi belirler

                        Console.WriteLine("Zar atmak için e ana menüye dönmek için h");
                        char secim = char.Parse(Console.ReadLine());
                        switch (secim)
                        {
                            case 'e':
                                Console.WriteLine($"Toplam Yatırılan Puan:{totalPoint}");
                                int userZar = ZarAt();
                                int pcZar = ZarAt();
                                string winner = "";
                                if (userZar > pcZar)
                                {
                                    balanceRepository.PointAdd(BalanceInfo(totalPoint));//user kazandığı takdirde totalPoint bakiyeye eklenecek
                                    winner = userName;
                                }
                                else if (pcZar > userZar)
                                {
                                    winner = "Bilgisayar";
                                }
                                else if (userZar == pcZar)
                                {
                                    balanceRepository.PointAdd(BalanceInfo(point));//berabere oldugunda yatırılan point bakiyeye eklenecek
                                    winner = "Berabere";
                                }
                                Console.WriteLine($"Siz:{userZar}\nBilgisayar:{pcZar}\nKazanan:{winner}");
                                GameHistoryAdd(userZar, pcZar, point, totalPoint);//Oynanan oyunu veritabanına kayıt eder.
                                break;
                            case 'h':
                                balanceRepository.PointAdd(BalanceInfo(point));//user oynamaktan vazgeçer ise yatırdığı puan hesabına geri yatırılacak.
                                MenuList();
                                break;
                            default:
                                Messages.MenuError();
                                break;
                        }
                    }
                    else
                    {
                        Messages.BalanceError();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            void GameHistoryAdd(int userZar, int pcZar, int point, int totalPoint)
            {
                GameHistory gameHistory = new GameHistory();
                gameHistory.UserId = userRepository.GetByName(userName).Id;
                gameHistory.UserDice = Convert.ToInt16(userZar);
                gameHistory.Pcdice = Convert.ToInt16(pcZar);
                gameHistory.PointInvested = point;
                gameHistory.TotalPointInvested = totalPoint;
                gameHistory.GameDate = DateTime.Now;
                gameHistoryRepository.Add(gameHistory);
            }
            void GameHistory()
            {
                var result = gameHistoryRepository.GetList();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        string getUserName = userRepository.GetById(item.UserId);
                        Console.WriteLine($"ID:{item.GameId}\nKullanıcı Adı:{getUserName}\nKullanıcının Attığı Zar:{item.UserDice}\n" +
                            $"Bilgisayarın Attığı Zar:{item.Pcdice}\nYatırılan Tutar:{item.PointInvested}\nToplam Yatırılmış Tutar:{item.TotalPointInvested}\nOyunanma Tarihi:{item.GameDate}");
                    }
                }
                else
                {
                    Messages.BalanceError();
                }
            }
            #endregion

            #region Bakiye Islemleri
            void BalanceShow()
            {
                var result = balanceRepository.GetById(userRepository.GetByName(userName).Id);
                if (result != null)
                {
                    Console.WriteLine($"Bakiye:{result}");
                }
                else
                {
                    Messages.NotFound();
                }
            }
            void BalancePointRemove()
            {
                Console.Write("Çekilecek Tutar:");
                int cekilecekTutar = int.Parse(Console.ReadLine());
                if(BalanceControl(cekilecekTutar) == true)
                {
                    balanceRepository.PointRemove(BalanceInfo(cekilecekTutar));
                }
                else
                {
                    Messages.BalanceError();
                }
                
            }
            void BalancePointAdd()
            {
                Console.WriteLine("Yatırılacak Tutar:");
                int cekilecekTutar = int.Parse(Console.ReadLine());
                if (BalanceControl(cekilecekTutar) == true)
                {
                    balanceRepository.PointAdd(BalanceInfo(cekilecekTutar));
                }
                else
                {
                    Messages.BalanceError();
                }
            }
            #endregion

            bool BalanceControl(int point)
            {
                int userPoint = balanceRepository.GetById(userRepository.GetByName(userName).Id);
                if (point > 0 && point <= userPoint)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            Balance BalanceInfo(int point)
            {
                Balance balance = new Balance();
                balance.Id = userRepository.GetByName(userName).Id;
                balance.Point = point;
                return balance;
            }

            Login();
            Console.ReadLine();
        }
    }
}