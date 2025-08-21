namespace presupuestoBasadoAPI.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using presupuestoBasadoAPI.Models;
using presupuestoBasadoAPI.Dto;
using presupuestoBasadoAPI.Helpers;

[ApiController]
[Route("api/[controller]")]
public class CuentasController : ControllerBase
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _config;

    public CuentasController(SignInManager<ApplicationUser> signInManager,
                             UserManager<ApplicationUser> userManager,
                             RoleManager<IdentityRole> roleManager,
                             IConfiguration config)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
        _config = config;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        var user = await _userManager.FindByNameAsync(model.User);
        if (user == null)
            return Unauthorized("Usuario no encontrado.");

        var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        if (!result.Succeeded)
            return Unauthorized("Contraseña incorrecta.");

        var roles = await _userManager.GetRolesAsync(user);
        var token = JwtHelper.GenerateJwtToken(user, roles, _config);

        return Ok(new
        {
            token,
            username = user.UserName,
            roles
        });
    }

    [HttpPost("Registro")]
    public async Task<IActionResult> Registro([FromBody] RegisterDto model)
    {
        var usuario = new ApplicationUser
        {
            UserName = model.User,
            Email = model.Email,
            NombreCompleto = model.NombreCompleto,
            Cargo = model.Cargo,
            Coordinador = model.Coordinador,
            UnidadesPresupuestales = model.UnidadesPresupuestales,
            ProgramaPresupuestario = model.ProgramaPresupuestario,
            NombreMatriz = model.NombreMatriz,
            // UnidadResponsable
            UnidadAdministrativaId = model.UnidadAdministrativaId

        };

        var resultado = await _userManager.CreateAsync(usuario, model.Password);

        if (!resultado.Succeeded)
            return BadRequest(resultado.Errors);

        // Validar y asignar el rol
        if (!string.IsNullOrEmpty(model.Rol))
        {
            var roleExists = await _roleManager.RoleExistsAsync(model.Rol);
            if (!roleExists)
                return BadRequest($"El rol '{model.Rol}' no existe.");

            await _userManager.AddToRoleAsync(usuario, model.Rol);
        }

        return Ok($"Usuario registrado correctamente con el rol: {model.Rol}");
    }

    [HttpGet("roles/{username}")]
    public async Task<IActionResult> GetRoles(string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        if (user == null) return NotFound("Usuario no encontrado.");

        var roles = await _userManager.GetRolesAsync(user);
        return Ok(roles);
    }
}
