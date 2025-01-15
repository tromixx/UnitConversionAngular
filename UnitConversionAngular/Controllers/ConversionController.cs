using Microsoft.AspNetCore.Mvc;
//using UnitConversionAngular.Services;
using UnitConversionApp.Services;

[ApiController]
[Route("api/[controller]")]
public class ConversionController : ControllerBase
{
    [HttpGet("convert")]
    public IActionResult Convert(double value, string fromUnit, string toUnit)
    {
        var result = ConversionService.Convert(value, fromUnit, toUnit);
        if (result == null) return BadRequest("Invalid units.");
        return Ok(result);
    }

    [HttpGet("validate")]
    public IActionResult Validate(double correctValue, double studentResponse)
    {
        var isValid = ConversionService.ValidateResponse(correctValue, studentResponse);
        return Ok(isValid);
    }
}
