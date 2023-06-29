using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.EntityConfigurations
{
    public class MonthsConfig : IEntityTypeConfiguration<MonthsForPay>
    {
        public void Configure(EntityTypeBuilder<MonthsForPay> builder)
        {
            List<MonthsForPay> months = new List<MonthsForPay>() {
                new MonthsForPay()
                {
                    Id= 1,
                    Month="September",
                    Cost=750,
                    ExpiresDate=new DateTime(2023,10,10)
                },
                new MonthsForPay()
                {
                    Id= 2,
                    Month="October",
                    Cost=1500,
                    ExpiresDate=new DateTime(2023,11,10)
                },
                new MonthsForPay()
                {
                    Id = 3,
                    Month="November",
                    Cost=1500,
                    ExpiresDate=new DateTime(2023,12,10)
                },
                new MonthsForPay()
                {
                    Id= 4,
                    Month="December",
                    Cost=1500,
                    ExpiresDate=new DateTime(2024,01,10)
                },
                new MonthsForPay()
                {
                    Id= 5,
                    Month="January",
                    Cost=1500,
                    ExpiresDate=new DateTime(2024,02,10)
                },
                new MonthsForPay()
                {
                    Id= 6,
                    Month="February",
                    Cost=1500,
                    ExpiresDate=new DateTime(2024,03,10)
                },
                new MonthsForPay()
                {
                    Id= 7,
                    Month="March",
                    Cost=1500,
                    ExpiresDate=new DateTime(2024,04,10)
                },
                new MonthsForPay()
                {
                    Id= 8,
                    Month="April",
                    Cost=1500,
                    ExpiresDate=new DateTime(2024,05,10)
                },
                new MonthsForPay()
                {
                    Id= 9,
                    Month="May",
                    Cost=1500,
                    ExpiresDate=new DateTime(2024,06,10)
                },
                new MonthsForPay()
                {
                    Id= 10,
                    Month="June",
                    Cost=750,
                    ExpiresDate=new DateTime(2024,06,30)
                }
            };
            builder.HasData(months);
        }
    }
}
