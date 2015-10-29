using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Pro.Assur.Models
{
    public class AssurContext:DbContext
    {

        public AssurContext() : base("name=DefaultConnection")
        {
           
        }


        public virtual DbSet<Devis> Devises { get; set; }

    }
}