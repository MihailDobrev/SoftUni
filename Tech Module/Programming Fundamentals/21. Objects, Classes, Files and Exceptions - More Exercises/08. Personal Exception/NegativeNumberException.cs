namespace _08.Personal_Exception
{
    using System;
    class NegativeNumberException: Exception
    {
        public NegativeNumberException()
       : base(String.Format("My first exception is awesome!!!"))
        {


        }
    }
}
