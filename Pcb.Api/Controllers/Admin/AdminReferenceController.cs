using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pcb.Dto.Reference;
using Pcb.Dto.Security;
using Pcb.Service.Implementations;
using Pcb.Security.Authorisation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pcb.Service.Interfaces;


namespace Pcb.Api.Controllers.Admin
{
	/// <summary>
	/// Provides administrative reference data methods.
	/// </summary>
	//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Produces("application/json")]
	[Route("api/v1/admin/reference")]
	[ApiController]
	public class AdminReferenceController : Controller
	{
		/// <summary>
		/// Initialises a new instance of the <see cref="AdminReferenceController"/> class.
		/// Creates a reference controller.
		/// </summary>
		/// <param name="refService">The reference query service.</param>
		public AdminReferenceController(
			IReferenceService refService)
		{
			RefService = refService;
		}

		/// <summary>
		/// The reference query service instance.
		/// </summary>
		private IReferenceService RefService { get; }

		/// <summary>
		/// Returns all reference type names.
		/// </summary>
		/// <returns></returns>
		[Route("types")]
		[HttpGet]
		//[PermissionRequirement(SecurityPermission.AdministerUsers)]
#pragma warning disable CA1822 // Mark members as static
		public IEnumerable<string> GetTypes()
#pragma warning restore CA1822 // Mark members as static
		{
			var types = Enum.GetNames(typeof(ReferenceType));
			return types;
		}

		/// <summary>
		/// Saves a reference item.
		/// </summary>
		/// <param name="item">The item.</param>
		/// /// <param name="type">The type.</param>
		/// <returns></returns>
		[Route("{type}")]
		[HttpPost]
		//[PermissionRequirement(SecurityPermission.AdministerUsers)]
		public async Task<IActionResult> Post([FromBody] ReferenceItemEx item, ReferenceType type)
		{
			await RefService.Save(item, type);
			return NoContent();
		}

	}
}
