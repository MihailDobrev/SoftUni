namespace P01.Generic_Box_of_String
{
    public class Box<T>
    {
        private T boxContent;

        public Box(T entry)
        {
            boxContent = entry;
        }
    
        public override string ToString()
        {       
            return $"{this.boxContent.GetType().FullName}: {boxContent}";
        }
    }
}
