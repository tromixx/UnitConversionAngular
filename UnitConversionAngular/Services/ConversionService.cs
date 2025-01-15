using System;

namespace UnitConversionApp.Services
{
    public static class ConversionService
    {
        public static double? Convert(double value, string fromUnit, string toUnit)
        {
            try
            {
                return fromUnit.ToLower() switch
                {
                    //temperature conv
                    "fahrenheit" when toUnit.ToLower() == "celsius" => (value - 32) * 5 / 9,
                    "celsius" when toUnit.ToLower() == "fahrenheit" => (value * 9 / 5) + 32,
                    "fahrenheit" when toUnit.ToLower() == "rankine" => value + 459.67,
                    "rankine" when toUnit.ToLower() == "fahrenheit" => value - 459.67,
                    "kelvin" when toUnit.ToLower() == "celsius" => value - 273.15,
                    "celsius" when toUnit.ToLower() == "kelvin" => value + 273.15,

                    //volume conv
                    "liters" when toUnit.ToLower() == "cups" => value * 4.22675,
                    "cups" when toUnit.ToLower() == "liters" => value / 4.22675,
                    "tablespoons" when toUnit.ToLower() == "liters" => value / 67.628,
                    "liters" when toUnit.ToLower() == "tablespoons" => value * 67.628,
                    "gallons" when toUnit.ToLower() == "liters" => value * 3.78541,
                    "liters" when toUnit.ToLower() == "gallons" => value / 3.78541,
                    "cubic-inches" when toUnit.ToLower() == "liters" => value * 0.0163871,
                    "liters" when toUnit.ToLower() == "cubic-inches" => value / 0.0163871,
                    "cups" when toUnit.ToLower() == "tablespoons" => value * 16,
                    "tablespoons" when toUnit.ToLower() == "cups" => value / 16,


                    _ => null
                };
            }
            catch
            {
                return null;
            }
        }

        public static bool ValidateResponse(double correctValue, double studentResponse)
        {
            return Math.Round(correctValue, 1) == Math.Round(studentResponse, 1);
        }
    }
}
