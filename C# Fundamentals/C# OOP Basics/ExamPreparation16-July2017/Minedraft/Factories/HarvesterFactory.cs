using System;
using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester CreateHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        switch (type)
        {
            case "Hammer":
                return new HammerHarvester(id, double.Parse(arguments[2]), double.Parse(arguments[3]));
            case "Sonic":
                return new SonicHarvester(id, double.Parse(arguments[2]), double.Parse(arguments[3]), int.Parse(arguments[4]));
            default:
                throw new ArgumentException();
        }

    }
}

