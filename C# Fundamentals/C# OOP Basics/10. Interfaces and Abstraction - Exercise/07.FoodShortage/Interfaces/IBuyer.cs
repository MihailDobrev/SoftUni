namespace _07.FoodShortage.Interfaces
{
    public interface IBuyer
    {
        int BuyFood();

        string Name { get; }
        int Food { get; }
    }
}
