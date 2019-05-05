using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUDWeb.Models;
using System.Data.Entity;

namespace CRUDWeb.DAL
{
    public class BSDBContext: DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BSDBContext():base("name=conn")
        {

        }
    }
}