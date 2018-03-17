public class Animal
{
    private string name;
    private string favouriteFood;

    public Animal(string name, string favouriteFood)
    {
        FavouriteFood = favouriteFood;
        Name = name;
    }

    public string FavouriteFood
    {
        get { return favouriteFood; }
        set { favouriteFood = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public virtual string ExplainSelf() => $"I am {name} and my fovourite food is {favouriteFood}";
}

