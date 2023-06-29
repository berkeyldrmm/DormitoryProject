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
    public class SuggestionsComplaintmentsConfig : IEntityTypeConfiguration<Suggestion_Complaint>
    {
        public void Configure(EntityTypeBuilder<Suggestion_Complaint> builder)
        {
            builder.HasOne(sc => sc.Complainant_Recommender)
                .WithMany(s => s.Suggestions_Complaints)
                .HasForeignKey(sc=>sc.Suggestion_ComplanintId);
        }
    }
}
