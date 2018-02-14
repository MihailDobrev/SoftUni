namespace _05.Pizza_Calories
{
    using System;

    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough()
        {

        }

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }


        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough");
                }
                bakingTechnique = value;
            }
        }

        public string FlourType
        {
            get { return flourType; }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        public double CalculateCalories()
        {
            double flourTypeModifier = 0;
            switch (this.flourType.ToLower())
            {
                case "white":
                    flourTypeModifier = 1.5;
                    break;
                case "wholegrain":
                    flourTypeModifier = 1.0;
                    break;
                default:
                    break;
            }

            double bakingTechniqueModifier = 0;
            switch (this.bakingTechnique.ToLower())
            {
                case "crispy":
                    bakingTechniqueModifier = 0.9;
                    break;
                case "chewy":
                    bakingTechniqueModifier = 1.1;
                    break;
                case "homemade":
                    bakingTechniqueModifier = 1.0;
                    break;
                default:
                    break;
            }
            var calories = 2 * this.weight * flourTypeModifier * bakingTechniqueModifier;
            return calories;
        }

    }
}
