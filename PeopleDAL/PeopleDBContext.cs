using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleDAL
{
    public class PeopleDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
