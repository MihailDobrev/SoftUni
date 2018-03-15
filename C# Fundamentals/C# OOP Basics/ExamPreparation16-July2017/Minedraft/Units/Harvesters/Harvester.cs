using System;

public abstract class Harvester:Unit
{
   
    private double oreOutput;
    private double energyRequirement;
    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(OreOutput)}");
            }
            oreOutput = value;
        }
    }
    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(EnergyRequirement)}");
            }
            energyRequirement = value;
        }
    }
    protected Harvester(string id, double oreOutput, double energyRequirement) 
        : base(id)
    {
        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }

    public override string ToString()
    {
        return $"{Type} Harvester - { Id}"+ Environment.NewLine +
            $"Ore Output: {oreOutput}" + Environment.NewLine +
            $"Energy Requirement: {energyRequirement}";
    }
}

