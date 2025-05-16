using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SonoffController : ControllerBase
{
    private readonly SonoffService _service;

    public SonoffController(SonoffService service)
    {
        _service = service;
    }

[HttpPost("send")]
public async Task<IActionResult> SendCommand([FromBody] SonoffRequest request)
{
    if (string.IsNullOrWhiteSpace(request.DeviceIp) || string.IsNullOrWhiteSpace(request.Command))
    {
        return BadRequest(new { error = "DeviceIp e Command são obrigatórios." });
    }

    try
    {
        var result = await _service.SendCommandAsync(request.DeviceIp, request.Command);
        return Ok(result);
    }
    catch (Exception ex)
    {
        return BadRequest(new { error = ex.Message });
    }
}}

public class SonoffRequest
{
    public string? DeviceIp { get; set; }
    public string? Command { get; set; }
}
