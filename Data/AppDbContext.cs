using CrudSprint2.Agendamentos;
using CrudSprint2.Pacientes;
using CrudSprint2.Unidades;
using Microsoft.EntityFrameworkCore;

namespace CrudSprint2.Data;

public class AppDbContext : DbContext
{
    public DbSet<Paciente> Pacientes {get; set;}
    public DbSet<Agendamento> Agendamentos { get; set; }
    
    public DbSet<Unidade> Unidades { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //String de conexão com o banco de dados Oracle
        optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) " +
                                 "(CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=rm550269;Password=291103;");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Configuração das tabelas
        modelBuilder.Entity<Paciente>().ToTable("pacientes");
        modelBuilder.Entity<Agendamento>().ToTable("agendamentos");
        modelBuilder.Entity<Unidade>().ToTable("unidades");
        
        //Configuração das chaves primárias
        modelBuilder.Entity<Agendamento>().HasKey(agendamento => agendamento.N_protocolo);
        modelBuilder.Entity<Paciente>().HasKey(paciente => paciente.Cpf);
        modelBuilder.Entity<Unidade>().HasKey(unidade => unidade.Id_unidade);
    }
}