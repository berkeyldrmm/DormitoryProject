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
    public class PaymentRecordConfig : IEntityTypeConfiguration<PaymentRecord>
    {
        public void Configure(EntityTypeBuilder<PaymentRecord> builder)
        {
            builder.HasOne(pr => pr.Student)
                .WithMany(s => s.PaymentRecords)
                .HasForeignKey(pr => pr.StudentId);

            builder.HasOne(pr => pr.Month)
                .WithMany(m => m.PaymentRecords)
                .HasForeignKey(pr => pr.MonthId);
        }
    }
}
