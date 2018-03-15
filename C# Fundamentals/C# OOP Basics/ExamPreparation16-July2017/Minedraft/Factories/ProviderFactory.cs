using System;
using System.Collections.Generic;
public class ProviderFactory
{
    public Provider CreateProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        switch (arguments[0])
        {
            case "Solar":
                return new SolarProvider(arguments[1], double.Parse(arguments[2]));
            case "Pressure":
                return new PressureProvider(arguments[1], double.Parse(arguments[2]));
            default:
                throw new ArgumentException();
        }

    }
}

