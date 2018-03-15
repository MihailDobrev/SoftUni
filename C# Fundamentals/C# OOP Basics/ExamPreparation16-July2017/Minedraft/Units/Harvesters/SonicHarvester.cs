public class SonicHarvester : Harvester
{
    public int SonicFactor { get; private set; }
    public override string Type => "Sonic";

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
         : base(id, oreOutput, energyRequirement)
    {
        SonicFactor = sonicFactor;
        EnergyRequirement = energyRequirement / sonicFactor;
    }
}

