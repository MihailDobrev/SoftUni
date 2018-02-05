namespace _04._Copy_Binary_File
{
    using System.IO;

    public class Startup
    {
        public static void Main()
        {

            FileStream reader = new FileStream("../Resources/copyMe.png", FileMode.Open);
            FileStream writer = new FileStream("copiedPic.png", FileMode.Create);

            using (reader)
            {
                using (writer)
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int bytes = reader.Read(buffer, 0, buffer.Length);
                        if (bytes==0)
                        {
                            break;
                        }
                        else
                        {
                            writer.Write(buffer, 0, buffer.Length);
                        }
                       
                    }

                
                }

            }

        }      
    }
}
