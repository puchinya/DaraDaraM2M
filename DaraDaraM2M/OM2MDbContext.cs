using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.PlatformAbstractions;
using DaraDaraM2M.Model;
using DaraDaraM2M.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DaraDaraM2M
{
	public class OM2MDbContext : DbContext
	{
		public OM2MDbContext()
		{
			
		}

		public DbSet<OM2MAutoIdEntity> AutoIds { get; set; }
		public DbSet<OM2MServiceEntity> Services { get; set; }
		public DbSet<OM2MDbServiceSubscription> ServiceSubscriptions { get; set; }
		public DbSet<OM2MResourceEntity> Resources { get; set; }
		public DbSet<OM2MAccessControlRuleEntity> AccessControlRules { get; set; }
		public DbSet<OM2MUriMapEntity> UriMaps { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OM2MResourceEntity>().HasAlternateKey(x => x.HierarchicalUri);

			modelBuilder.Entity<OM2MResourceEntity>()
						.HasDiscriminator<string>("_class")
			            .HasValue<OM2MResourceEntity>("m2m:resource")
			            .HasValue<OM2MCseBaseEntity>("m2m:csebase")
			            .HasValue<OM2MAEEntity>("m2m:ae")
			            .HasValue<OM2MAccessControlPolicyEntity>("m2m:acp")
			            .HasValue<OM2MSubscriptionEntity>("m2m:sub")
			            ;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Filename=./OM2M.db", x => x.SuppressForeignKeyEnforcement());
		}

		public int GenerateId()
		{
			if (AutoIds.Count() > 0)
			{
				AutoIds.Remove(AutoIds.First());
			}

			var e = new OM2MAutoIdEntity();

			AutoIds.Add(e);

			SaveChanges();

			return e.Id;
		}
	}

	public static class OM2MDbContextExtension
	{
		public static List<OM2MAccessControlPolicyEntity> GetAcpList(this OM2MDbContext db, OM2MResourceEntity entity)
		{
			var hasAcpIdsEntity = entity as IOM2MHasAccessControlPolicyIdsEntity;

			var acpIds = hasAcpIdsEntity != null ? hasAcpIdsEntity.AccessControlPolicyIds : null;

			var acpList = new List<OM2MAccessControlPolicyEntity>();
			if (acpIds != null)
			{
				foreach (var acpId in acpIds)
				{
					var queryAcp = db.Resources.Find(acpId) as OM2MAccessControlPolicyEntity;
					if (queryAcp == null)
					{
						// Damaged
						continue;
					}
					acpList.Add(queryAcp);
				}
			}

			return acpList;
		}
	}

	[Table("autoid")]
	public class OM2MAutoIdEntity
	{
		public int Id
		{
			get;
			set;
		}
	}
}
