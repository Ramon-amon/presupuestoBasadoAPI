namespace presupuestoBasadoAPI.Dto
{
    public class RegisterDto
    {
        public string User { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public string? NombreCompleto { get; set; }
    }
}
