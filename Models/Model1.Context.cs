﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProFinalEstudiantes.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities3 : DbContext
    {
        public Entities3()
            : base("name=Entities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<COLA_ESTUDIANTES> COLA_ESTUDIANTES { get; set; }
        public virtual DbSet<ESTUDIANTE> ESTUDIANTE { get; set; }
        public virtual DbSet<INSCRIPCION_ESTUDIANTES> INSCRIPCION_ESTUDIANTES { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
    }
}