﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PicoYPlacaPredictor
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PicoyPlacaPredictorEntities : DbContext
    {
        public PicoyPlacaPredictorEntities()
            : base("name=PicoyPlacaPredictorEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DayOfWeek> DayOfWeek { get; set; }
        public virtual DbSet<PicoYPlaca> PicoYPlaca { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
    }
}
