namespace Mankind
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string[] studentData = Console.ReadLine().Split();
            string[] workerData = Console.ReadLine().Split();

            try
            {
                Student student = new Student(studentData[0], studentData[1], studentData[2]);
                Worker worker = new Worker(workerData[0], workerData[1], decimal.Parse(workerData[2]), double.Parse(workerData[3]));

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }
    }
}
