using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelloLinuxAPI.Models;

namespace HelloLinuxAPI.Models
{
    public class HelloLinuxDbContext : DbContext
    {
        public HelloLinuxDbContext(DbContextOptions<HelloLinuxDbContext> options) : base(options)
        {

        }
        public DbSet<HelloLinuxAPI.Models.Greetings> Greetings { get; set; }
    }
}
