namespace P01_BillsPaymentSystem.App
{
    using P01_BillsPaymentSystem.Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BillsPaymentSystemContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //2.	Seed Some Data
                Configuration.Seed(context);
            }
        }
    }
}
