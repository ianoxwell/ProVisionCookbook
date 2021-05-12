using System;
using System.Linq;
using System.Threading.Tasks;
using Pcb.Dto.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pcb.Security.Authorisation;
using Pcb.Security;

namespace Pcb.Security.Authorisation
{
	/// <summary>
	/// Permission Requirement Attribute
	/// </summary>
	/// <seealso cref="TypeFilterAttribute" />
	[AttributeUsage(AttributeTargets.All)]
	public sealed class PermissionRequirementAttribute : TypeFilterAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PermissionRequirementAttribute"/> class.
		/// </summary>
		/// <param name="requirementsType">Type of the requirements.</param>
		/// <param name="permissions">The permissions.</param>
		public PermissionRequirementAttribute(
			PermissionRequirementsType requirementsType,
			params SecurityPermission[] permissions)
			: base(typeof(PermissionRequirementAttributeImpl))
		{
			Arguments = new object[]
			{
				new PermissionRequirements(permissions, requirementsType)
			};
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PermissionRequirementAttribute"/> class.
		/// </summary>
		/// <param name="permissions">The permissions.</param>
		public PermissionRequirementAttribute(params SecurityPermission[] permissions)
			: this(PermissionRequirementsType.Any, permissions)
		{
		}

		[AttributeUsage(AttributeTargets.All)]
		private sealed class PermissionRequirementAttributeImpl : Attribute, IAsyncResourceFilter
		{
			private IPcbSecurityService SecurityService { get; }

			private PermissionRequirements PermissionsReqs { get; }

			public PermissionRequirementAttributeImpl(IPcbSecurityService securityService, PermissionRequirements permissionRequirements)
			{
				SecurityService = securityService;
				PermissionsReqs = permissionRequirements;
			}

			public async Task OnResourceExecutionAsync(
				ResourceExecutingContext context,
				ResourceExecutionDelegate next)
			{
				var isAuth = PermissionsReqs.RequirementsType == PermissionRequirementsType.All
					? PermissionsReqs.Permissions.All(p => SecurityService.IsAuthorisedInAnyFacility(p))
					: PermissionsReqs.Permissions.Any(p => SecurityService.IsAuthorisedInAnyFacility(p));

				// Not authorised in the required permissions
				if (!isAuth)
				{
					// Note: Unless Startup.cs correctly calls AddAuthentication() with a DefaultForbidScheme,
					// the below call will fail.
					await context.HttpContext.ForbidAsync();
					return;
				}

				await next();
			}
		}

		/// <summary>
		/// Gets the type of the requirements.
		/// </summary>
		/// <value>
		/// The type of the requirements.
		/// </value>
		public PermissionRequirementsType RequirementsType { get; }

		/// <summary>
		/// Gets the permissions.
		/// </summary>
		/// <value>
		/// The permissions.
		/// </value>
		public SecurityPermission[] Permissions { get; }
	}
}
