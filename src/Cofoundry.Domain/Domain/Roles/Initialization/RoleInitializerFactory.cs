﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cofoundry.Core.DependencyInjection;
using Conditions;

namespace Cofoundry.Domain
{
    /// <summary>
    /// Factory for creating role initializers to avoid exposing IResolutionContext
    /// directly.
    /// </summary>
    public class RoleInitializerFactory : IRoleInitializerFactory
    {
        private readonly IResolutionContext _resolutionContext;

        public RoleInitializerFactory(
            IResolutionContext resolutionContext
            )
        {
            _resolutionContext = resolutionContext;
        }

        /// <summary>
        /// Creates an instance of a role initializer for the specified role
        /// definition if one has been implemented; otherwise returns null
        /// </summary>
        /// <param name="roleDefinition">The role to find an initializer for</typeparam>
        /// <returns>IRoleInitializer if one has been implemented; otherwise null</returns>
        public IRoleInitializer Create(IRoleDefinition roleDefinition)
        {
            Condition.Requires(roleDefinition).IsNotNull();

            // Never add permission to the super admin role
            if (roleDefinition is SuperAdminRole) return null;

            var type = typeof(IRoleInitializer<>).MakeGenericType(roleDefinition.GetType());
            if (_resolutionContext.IsRegistered(type))
            {
                return (IRoleInitializer)_resolutionContext.Resolve(type);
            }
            else if (roleDefinition is AnonymousRole)
            {
                // We use a default initializer just for the anonymous role
                // as it's the only built in role with permissions
                return new DefaultAnonymousRoleInitializer();
            }

            return null;
        }
    }
}
