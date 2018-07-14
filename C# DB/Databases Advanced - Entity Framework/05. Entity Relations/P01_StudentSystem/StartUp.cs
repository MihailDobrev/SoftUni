namespace P01_StudentSystem
{
    using Data;
    public class StartUp
    {
        public static void Main()
        {
            using (var context = new StudentSystemContext())
            {
                Configuration.Seed(context);
            }
        }
    }


}
