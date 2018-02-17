namespace _06.Football_Team_Generator
{
    using System;

    public class Player
    {
        private string name;
        private short endurance;
        private short sprint;
        private short dribble;
        private short passing;
        private short shooting;

        public Player(string name, short endurance, short sprint, short dribble, short passing, short shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public short Shooting
        {
            get { return shooting; }
            set {
                if (value<0 || value>100)
                {
                    throw new ArgumentException("Shooting should be between 0 and 100.");
                }
                shooting = value; }
        }

        public short Passing
        {
            get { return passing; }
            set {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Passing should be between 0 and 100.");
                }
                passing = value; }
        }

        public short Dribble
        {
            get { return dribble; }
            set {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Dribble should be between 0 and 100.");
                }
                dribble = value; }
        }

        public short Sprint
        {
            get { return sprint; }
            set {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Sprint should be between 0 and 100.");
                }
                sprint = value; }
        }

        public short Endurance
        {
            get { return endurance; }
            set {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Endurance should be between 0 and 100.");
                }
                endurance = value; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value == string.Empty || value == " ")
                {
                    throw new ArgumentException("A name should not be empty. ");
                }
                name = value;
            }
        }

        public double Average()
        {
            return (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
        }

    }
}
