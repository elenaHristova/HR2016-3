using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProjectHack.Models
{
	public class ProjectHackContext :DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<PersonalInfo> PersonalInfos { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<TimePeriod> TimePeriods { get; set; }
		public DbSet<Goal> Goals { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}