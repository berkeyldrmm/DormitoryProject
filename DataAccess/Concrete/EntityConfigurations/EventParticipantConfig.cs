using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityConfigurations
{
    public class EventParticipantConfig : IEntityTypeConfiguration<EventParticipant>
    {
        public void Configure(EntityTypeBuilder<EventParticipant> builder)
        {
            builder.HasOne(ep => ep.Student)
                .WithMany(s => s.Events)
                .HasForeignKey(ep => ep.StudentId);

            builder.HasOne(ep => ep.Event)
                .WithMany(e => e.Students)
                .HasForeignKey(ep => ep.EventId);
        }
    }
}
