using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{   
    public List<Provider> Providers { get; private set; }
    public List<Harvester> Harvesters { get; private set; }
    private string mode;
    private double totalEnergyStored;
    private double totalMinedOre;
    private ProviderFactory providerFactory;
    private HarvesterFactory harvesterFactory;

    public DraftManager()
    {
        mode = "Full";
        Harvesters = new List<Harvester>();
        Providers = new List<Provider>();
        providerFactory = new ProviderFactory();
        harvesterFactory = new HarvesterFactory();
    }
   

    public string RegisterHarvester(List<string> arguments)
    {       
        try
        {
            Harvester harvester = harvesterFactory.CreateHarvester(arguments);
            Harvesters.Add(harvester);
            return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}";           
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }

    }
    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = providerFactory.CreateProvider(arguments);
            Providers.Add(provider);
            return $"Successfully registered {provider.Type} Provider - {provider.Id}";
           
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }
    public string Day()
    {
        double totalProviderEnergyOutput = Providers.Sum(p => p.EnergyOutput);
        totalEnergyStored += totalProviderEnergyOutput;
        double totalHarvesterEnergyRequirement = Harvesters.Sum(p => p.EnergyRequirement);
        double totalOreOutput = Harvesters.Sum(p => p.OreOutput);

        switch (mode)
        {
            case "Half":
                totalHarvesterEnergyRequirement = totalHarvesterEnergyRequirement * 0.6;
                totalOreOutput = totalOreOutput * 0.5;
                break;
            case "Energy":
                totalHarvesterEnergyRequirement = 0;
                totalOreOutput = 0;
                break;
            default:
                break;
        }

        double summedEnergyOutput = totalProviderEnergyOutput;
        double summedOreOutput = 0;

        if (totalHarvesterEnergyRequirement <= totalEnergyStored)
        {
            totalEnergyStored -= totalHarvesterEnergyRequirement;
            totalMinedOre += totalOreOutput;
            summedOreOutput = totalOreOutput;
        }

        return "A day has passed." + Environment.NewLine +
                $"Energy Provided: {summedEnergyOutput}" + Environment.NewLine +
                $"Plumbus Ore Mined: {summedOreOutput}";
    }
    public string Mode(List<string> arguments)
    {
        mode = arguments[0];
        return $"Successfully changed working mode to {mode} Mode";
    }
    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        string message = string.Empty;
        List<Unit> allHarvestersAndProviders = new List<Unit>();
        Harvesters.ForEach(h => allHarvestersAndProviders.Add(h));
        Providers.ForEach(p => allHarvestersAndProviders.Add(p));
        Unit foundIIdentifiable = allHarvestersAndProviders.FirstOrDefault(i => i.Id == id);

        if (foundIIdentifiable == null)
        {
            message = $"No element found with id - {id}";
        }
        else
        {
            message = foundIIdentifiable.ToString();
        }
        return message;
    }
    public string ShutDown()
    {
        return "System Shutdown" + Environment.NewLine +
                $"Total Energy Stored: {totalEnergyStored}" + Environment.NewLine +
                $"Total Mined Plumbus Ore: { totalMinedOre}";
    }
}

