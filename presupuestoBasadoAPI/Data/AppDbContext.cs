using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using presupuestoBasadoAPI.Models;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ProgramaPresupuestario> Programas { get; set; }
    public DbSet<IdentificacionProblema> IdentificacionProblemas { get; set; }
    public DbSet<JustificacionPrograma> JustificacionProgramas { get; set; }
    public DbSet<PoblacionObjetivo> PoblacionObjetivo { get; set; }
    public DbSet<AnalisisEntorno> AnalisisEntorno { get; set; }
    public DbSet<UnidadAdministrativa> UnidadAdministrativas { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UnidadAdministrativa>()
            .HasMany(u => u.Usuarios)
            .WithOne(u => u.UnidadAdministrativa)
            .HasForeignKey(u => u.UnidadAdministrativaId)
            .OnDelete(DeleteBehavior.Restrict); // O Cascade
    }

    public DbSet<AlineacionEstado> AlineacionesEstado { get; set; }
    public DbSet<AlineacionMunicipio> AlineacionesMunicipio { get; set; }
    public DbSet<Ramo> Ramos { get; set; }
    public DbSet<ClasificacionFuncional> ClasificacionesFuncionales { get; set; }

    //anexo 1
    public DbSet<Antecedente> Antecedentes { get; set; }
    public DbSet<IdentificacionDescripcionProblema> IdentificacionDescripcionProblemas { get; set; }
    public DbSet<DeterminacionJustificacionObjetivos> DeterminacionJustificacionObjetivo { get; set; }
    public DbSet<Cobertura> Coberturas { get; set; }
    public DbSet<DisenoIntervencionPublica> DisenoIntervencionPublicas { get; set; }
    public DbSet<ProgramaSocial> ProgramaSocial { get; set; }
    public DbSet<ProgramaSocialCategoria> ProgramaSocialCategorias { get; set; }
    public DbSet<PadronBeneficiarios> PadronBeneficiarios { get; set; }
    public DbSet<ReglasOperacion> ReglasOperacion { get; set; }
    public DbSet<Componente> Componentes { get; set; }
    public DbSet<Accion> Acciones { get; set; }
    public DbSet<Resultado> Resultados { get; set; }


}
