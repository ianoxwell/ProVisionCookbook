using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pcb.Common.Enums;
using Pcb.Dto.Reference;
using Pcb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pcb.Api.Controllers
{
	/// <summary>
	/// Provides access to Pcb reference data.
	/// All reference data is cached on the web server.
	/// </summary>
	/// <inheritdoc />
	[Route("api/v1/reference")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Produces("application/json")]
	public class ReferenceController : Controller
	{
		/// <summary>
		/// The reference service instance from DI.
		/// </summary>
		private IReferenceService ReferenceService { get; }


		/// <summary>
		/// Initialises a new instance of the <see cref="ReferenceController" /> class.
		/// Expected lifetime is scoped to a web request.
		/// </summary>
		/// <param name="referenceService">The reference service.</param>
		public ReferenceController(
			IReferenceService referenceService)
		{
			ReferenceService = referenceService;
		}

		/// <summary>
		/// Returns reference items by type.
		/// </summary>
		/// <param name="type">The reference type, e.g. Ward</param>
		/// <param name="detail">The level of detail to return, defaulting to simply {Id,Title}.</param>
		/// <returns></returns>
		//[Route("active")]
		[HttpGet]
		[Authorize]
		public IActionResult GetReference(
			Dto.Reference.ReferenceType type,
			ReferenceDetail detail = ReferenceDetail.Basic)
		{
			var items = ReferenceService.GetAll(type);
			// check for null
			if (items == null || items.Count() == 0)
			{
				ModelState.AddModelError("", "No results found");
				return StatusCode(404, ModelState);
			}
			// check for detail level
			if (detail == ReferenceDetail.Extended)
			{
				return Ok(items);
			}
			// convert to ReferenceItem
			List<ReferenceItem> listObj = new List<ReferenceItem>();
			foreach (var row in items)
			{
				var item = new ReferenceItem
				{
					Id = row.Id,
					Title = row.Title
				};
				listObj.Add(item);
			}
			return Ok(listObj);
		}

		[Route("all")]
		[HttpGet]
		public IActionResult GetAllReferences()
		{
			IDictionary<string, IEnumerable<ReferenceItemEx>> refObject = new Dictionary<string, IEnumerable<ReferenceItemEx>>();
			foreach (var type in Enum.GetValues(typeof(Dto.Reference.ReferenceType)))
			{
				var items = ReferenceService.GetAll((Dto.Reference.ReferenceType)type);
				refObject[type.ToString()] = items;
			}
			return Ok(refObject);
		}


		[Route("measurements")]
		[HttpGet]
		public IActionResult GetMeasurements()
		{
			var units = ReferenceService.GetMeasurementUnits();
			return Ok(units);
		}


	}
}
