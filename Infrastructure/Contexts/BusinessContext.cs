using Microsoft.EntityFrameworkCore;

using VehicleRegistry.Domain.Entities;
using VehicleRegistry.Infrastructure.Seeders;

namespace VehicleRegistry.Infrastructure.Contexts;

/// <summary>
/// Contexto de banco de dados para a lógica de negócio.
/// </summary>
/// <author>Herberth Leão</author>
/// <email>herberth.leao@pm.me</email>
public class BusinessContext : DbContext
{
    /// <summary>
    /// Entidade de proprietários.
    /// </summary>
    public DbSet<Owner> Owners { get; set; }

    /// <summary>
    /// Entidade de veículos.
    /// </summary>
    public DbSet<Vehicle> Vehicles { get; set; }

    /// <summary>
    /// Entidade de cores de veículos.
    /// </summary>
    public DbSet<VehicleColor> VehicleColors { get; set; }

    /// <summary>
    /// Entidade de combustíveis.
    /// </summary>
    public DbSet<VehicleFuel> VehicleFuels { get; set; }

    /// <summary>
    /// Entidade de tipos de veículos.
    /// </summary>
    public DbSet<VehicleType> VehicleTypes { get; set; }

    /// <summary>
    /// Entidade de marcas de veículos.
    /// </summary>
    public DbSet<Brand> Brands { get; set; }

    /// <summary>
    /// Entidade de modelos de veículos.
    /// </summary>
    public DbSet<Model> Models { get; set; }

    /// <summary>
    /// Semeadores para popular as tabelas.
    /// </summary>
    private Seeder[] seeders;

    /// <summary>
    /// Inicializa propriedades.
    /// </summary>
    /// <param name="options">As configurações de conexão com o banco de dados.</param>
    /// <param name="vehicleColorSeeder">O semeador para cores.</param>
    /// <param name="vehicleFuelSeeder">O semeador para combustíveis.</param>
    /// <param name="vehicleTypeSeeder">O semeador para tipos de veículos.</param>
    /// <param name="brandSeeder">O semeador para marcas.</param>
    public BusinessContext(
        DbContextOptions options,
        VehicleColorSeeder vehicleColorSeeder,
        VehicleFuelSeeder vehicleFuelSeeder,
        VehicleTypeSeeder vehicleTypeSeeder,
        BrandSeeder brandSeeder
    ) : base(options)
    {
        this.seeders = new Seeder[4] {
            vehicleColorSeeder,
            vehicleFuelSeeder,
            vehicleTypeSeeder,
            brandSeeder
        };
    }

    /// <summary>
    /// Define operações a serem realizadas durante o salvamento da entidade.
    /// </summary>
    /// <param name="cancellatonToken">Opção de cancelamento da operação assíncrona.</param>
    /// <returns>O número de entradas no banco de dados.</returns>
    public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default
    )
    {
        // Pega a data e hora atual.
        var now = DateTime.UtcNow;

        // Atualiza as entidades para definir a data de criação e de
        // atualização.
        foreach (var entry in ChangeTracker.Entries<IEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = now;
            }

            entry.Entity.UpdatedAt = now;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Realiza operações de modelagem de dados.
    /// </summary>
    /// <param name="builder">O modelador de dados para o contexto atual.</param>
    /// <remarks>Este método não retorna valor.</remarks>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Vincula as tabelas às entidades.
        this.BindTables(builder);
        // Cria as relações entre as tabelas.
        this.CreateRelations(builder);
        // Popula algumas tabelas.
        this.Populate(builder);

        base.OnModelCreating(builder);
    }

    /// <summary>
    /// Vincula as tabelas às entidades para utilizar nomenclaturas no plural.
    /// Isto permite que o banco de dados fique padronizado.
    /// </summary>
    /// <param name="builder">O modelador de dados para o contexto atual.</param>
    /// <remarks>Este método não retorna valor.</remarks>
    private void BindTables(ModelBuilder builder)
    {
        builder.Entity<Owner>().ToTable("Owners");
        builder.Entity<Vehicle>().ToTable("Vehicles");
        builder.Entity<VehicleColor>().ToTable("VehicleColors");
        builder.Entity<VehicleFuel>().ToTable("VehicleFuels");
        builder.Entity<VehicleType>().ToTable("VehicleTypes");
        builder.Entity<Brand>().ToTable("Brands");
        builder.Entity<Model>().ToTable("Models");
    }

    /// <summary>
    /// Estabelece as relações de chave estrangeira entre as entidades.
    /// </summary>
    /// <param name="builder">O modelador de dados para o contexto atual.</param>
    /// <remarks>Este método não retorna valor.</remarks>
    private void CreateRelations(ModelBuilder builder)
    {
        builder.Entity<Vehicle>().HasOne<Owner>(vehicle => vehicle.Owner);
        builder.Entity<Vehicle>().HasOne<VehicleColor>(vehicle => vehicle.Color);
        builder.Entity<Vehicle>().HasOne<VehicleFuel>(vehicle => vehicle.Fuel);
        builder.Entity<Vehicle>().HasOne<Model>(vehicle => vehicle.Model);

        builder.Entity<Model>().HasOne<Brand>(model => model.Brand);
        builder.Entity<Model>().HasOne<VehicleType>(model => model.Type);
    }

    /// <summary>
    /// Popula algumas tablelas utilizando os semeadores disponíveis.
    /// </summary>
    /// <param name="builder">O modelador de dados para o contexto atual.</param>
    /// <remarks>Este método não retorna valor.</remarks>
    private void Populate(ModelBuilder builder)
    {
        foreach (var seeder in this.seeders) {
            seeder.Seed(builder);
        }
    }
}