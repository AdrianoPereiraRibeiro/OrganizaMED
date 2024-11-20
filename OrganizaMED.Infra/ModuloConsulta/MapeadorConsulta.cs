using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrganizaMED.Dominio.ModuloCirugia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganizaMED.Dominio.ModuloConsulta;

namespace OrganizaMED.Infra.ModuloConsulta
{
    public class MapeadorConsultaOrm : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("TBConsulta");

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Duracao)
                .IsRequired();

            builder.HasOne(x => x.Medico)
                .WithOne()
                .HasForeignKey<Consulta>(x => x.MedicoId)
                .HasConstraintName("FK_TBMedico_TBConsulta");

            builder.Property(x => x.DataDeInicio)
                .IsRequired();

            builder.Property(x => x.DataDeEncerramento)
                .IsRequired();

        }
    }
}
