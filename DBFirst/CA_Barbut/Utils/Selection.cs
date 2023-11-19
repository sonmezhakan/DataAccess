namespace CA_Barbut.Utils
{
    public class Selection
    {
        public static byte MenuSelection()
        {
            try
            {
                Console.Write("Lütfen bir seçim yapınız:");
                return byte.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
