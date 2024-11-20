using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganizaMED.Dominio.ModuloCirugia;

namespace OrganizaMED.Infra.ModuloCirugia
{
    public class MapeadorCirugiaOrm : IEntityTypeConfiguration<Cirugia>
    {
        public void Configure(EntityTypeBuilder<Cirugia> builder)
        {
            builder.ToTable("TBCirugia");

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Duracao)
                .IsRequired();

            builder.HasMany(x => x.Medicos);

            builder.Property(x => x.DataDeInicio)
                .IsRequired();

            builder.Property(x => x.DataDeEncerramento)
                .IsRequired();

        }
    }
}
