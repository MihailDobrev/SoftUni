using System;
public abstract class Provider:Unit
{  
    private double energyOutput;
  
    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(EnergyOutput)}");
            }
            energyOutput = value;
        }
    }

    protected Provider(string id, double energyOutput)
       : base(id)
    {
        EnergyOutput = energyOutput;
    }
    public override string ToString()
    {
      
        return $"{Type} Provider - {Id}" + Environment.NewLine +
            $"Energy Output: {energyOutput}";
    }

}

