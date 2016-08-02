using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Dto
{
    public enum WeatherCondition
    {
        Unspecified,
        Clear,
        Rain,
        Snow,
        Fog,
        Clowdy,
        PartlyClowdy
    }

    public enum UnitOfMeasure
    {
        Kelvin,
        Celsius,
        Fahrenheit
    }
}