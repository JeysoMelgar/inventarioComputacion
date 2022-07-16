using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioComputo.BL
{
    public class Contexto: DbContext //Conectamos al Entity Framework
    {   
        //Creamos una base datos
        public Contexto(): base(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename=" + 
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) 
            + @"\InventarioComputoDB.mdf")
        {

        }
        // protegemos la sobreescritura y evitamos la pluralizacion de las tablas
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

            //Se crea una tabla de datos de cada campo
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet <Usuarios> Usuarios { get; set; }
    }
}
