namespace P11.Threeuple
{
    public class Threeuple<T1,T2,T3>
    {
        public Threeuple(T1 firstItem, T2 secondItem, T3 thirdItem)
        {
            this.item1 = firstItem;
            this.item2 = secondItem;
            this.item3 = thirdItem;
        }
        public T1 item1 { get; }
        public T2 item2 { get; }
        public T3 item3 { get; }

        public override string ToString() => $"{item1.ToString()} -> {item2.ToString()} -> {item3.ToString()}";
    }
}
