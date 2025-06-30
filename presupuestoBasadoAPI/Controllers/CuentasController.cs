namespace presupuestoBasadoAPI.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using presupuestoBasadoAPI.Models;
using presupuestoBasadoAPI.Dto;

[ApiController]
[Route("api/[controller]")]
public class CuentasController : ControllerBase
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public CuentasController(SignInManager<ApplicationUser> signInManager,
                             UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
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

        // Aquí podrías devolver datos del usuario o generar un token JWT (recomendado)
        return Ok(new
        {
            mensaje = "Inicio de sesión correcto",
            user = user.UserName
        });
    }

    [HttpPost("Registro")]
    public async Task<IActionResult> Registro([FromBody] RegisterDto model)
    {
        var usuario = new ApplicationUser
        {
            UserName = model.User,
            Email = model.Email,
            NombreCompleto = model.NombreCompleto
        };

        var resultado = await _userManager.CreateAsync(usuario, model.Password);

        if (!resultado.Succeeded)
            return BadRequest(resultado.Errors);

        // Puedes asignar un rol si lo deseas:
        // await _userManager.AddToRoleAsync(usuario, "Enlace");

        return Ok("Usuario registrado correctamente.");
    }

}
