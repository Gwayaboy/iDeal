﻿using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using UIT.iDeal.Common.Extensions;
using UIT.iDeal.Domain.Model;

namespace UIT.iDeal.Data.EntityFrameworkProvider.Configuration
{
    /// <summary>
    /// http://stackoverflow.com/questions/5246466/entity-framework-4-mapping-non-public-properties-with-ctp5-code-first-in-a-p
    /// </summary>
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Ignore(x => x.ApplicationRoles);
            Ignore(x => x.BusinessUnits);
            Ignore(x => x.Modules);
            HasMany(x => x.internalApplicationRoles)
                .WithMany(x => x.internalUsers)
                .Map(x =>
                {
                    x.ToTable("UserApplicationRoles");
                    x.MapLeftKey("UserId");
                    x.MapRightKey("ApplicationRoleId");
                });

            HasMany(x => x.internalBusinessUnits)
                .WithMany(x => x.internalUsers)
                .Map(x =>
                {
                    x.ToTable("UserBusinessUnits");
                    x.MapLeftKey("UserId");
                    x.MapRightKey("BusinessId");
                });
            HasMany(x=>x.internalModules)
                .WithMany(x => x.internalUsers)
                .Map(x =>
                         {
                             x.ToTable("UserApplicationPermissions");
                             x.MapLeftKey("UserId");
                             x.MapRightKey("ModuleId");
                         });
        }
    }
}