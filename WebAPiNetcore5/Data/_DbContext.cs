using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPiNetcore5.Data
{
    public class _DbContext : IdentityDbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options)
            : base(options)
        {
        }
    }
}
