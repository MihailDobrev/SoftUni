namespace SIS.Framework.Models
{
    public class Model
    {
        private bool? isValid;
        
        public bool? IsValid
        {
            get { return isValid; }
            set { isValid = isValid ?? value; }
        }

    }
}
