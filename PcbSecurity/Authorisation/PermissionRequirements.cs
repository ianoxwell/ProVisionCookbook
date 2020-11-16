using System.Collections.Generic;
using Pcb.Dto.Security;
using Microsoft.AspNetCore.Authorization;

namespace Pcb.Security.Authorisation
{
	/// <summary>
	/// The Permission Requirements
	/// </summary>
	public enum PermissionRequirementsType
	{
		None,
		Any,
		All
	}

	/// <inheritdoc />
	public class PermissionRequirements : IAuthorizationRequirement
	{
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
		public ISet<SecurityPermission> Permissions { get; }

		/// <inheritdoc />
		public PermissionRequirements(
			IEnumerable<SecurityPermission> permissions,
			PermissionRequirementsType requirementsType = PermissionRequirementsType.All)
		{
			Permissions = new HashSet<SecurityPermission>(permissions);
			RequirementsType = requirementsType;
		}
	}
}
