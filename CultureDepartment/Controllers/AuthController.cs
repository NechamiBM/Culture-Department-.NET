using CultureDepartment.API.Models;
using CultureDepartment.Core.Services;
using CultureDepartment.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IWorkerService _workerService;
    private readonly IResidentService _residentService;
    private readonly IManagerService _managerService;

    public AuthController(IConfiguration configuration, IWorkerService workerService, IResidentService residentService, IManagerService managerService)
    {
        _workerService = workerService;
        _configuration = configuration;
        _residentService = residentService;
        _managerService = managerService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        string role;
        bool isManager = await _managerService.IsManagerPassword(loginModel.Password);
        if (loginModel.UserName == "manager" && isManager)
            role = "manager";
        else
        {
            var worker = await _workerService.GetWorkerAsync(loginModel.Password);
            if (worker != null && worker.Name == loginModel.UserName)
                role = "worker";
            else
            {
                var resident = await _residentService.GetResidentAsync(loginModel.Password);
                if (resident != null && resident.FirstName + " " + resident.LastName == loginModel.UserName)
                    role = "resident";
                else return Unauthorized();
            }
        }

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, loginModel.UserName),
            new Claim(ClaimTypes.Role, role)
        };
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var tokeOptions = new JwtSecurityToken(
            issuer: _configuration.GetValue<string>("JWT:Issuer"),
            audience: _configuration.GetValue<string>("JWT:Audience"),
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: signinCredentials
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        return Ok(new { Token = tokenString });
    }
}
