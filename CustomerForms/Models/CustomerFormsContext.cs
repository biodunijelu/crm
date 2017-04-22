using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
//using System.Data.EntityClient;
using System.Data.SqlClient;

namespace CustomerForms.Models
{
    public class CustomerFormsContext : DbContext
    { 
     public DbSet<Customer> Customers { get; set; }

     public CustomerFormsContext() : base("CustomerConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CustomerFormsContext>());

        }

    
    }
}