public class HammerHarvester : Harvester
{
    public override string Type => "Hammer";
    public HammerHarvester(string id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        OreOutput = oreOutput * 3;
        EnergyRequirement = energyRequirement * 2;
    }   
}
