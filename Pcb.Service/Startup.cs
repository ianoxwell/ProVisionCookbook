using Microsoft.Extensions.DependencyInjection;
using Pcb.Service.Implementations;
using Pcb.Service.Interfaces;

namespace Pcb.Service
{
	public static class Startup
	{
		/// <summary>
		/// Adds the Pcb services.
		/// </summary>
		/// <param name="services">The services.</param>
		public static void AddPcbServices(this IServiceCollection services)
		{
			services.AddScoped<ISecurityService, SecurityService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IReferenceService, ReferenceService>();
			services.AddScoped<IIngredientService, IngredientService>();
			services.AddScoped<IRecipeService, RecipeService>();
			services.AddScoped<IEmailService, EmailService>();
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IRawFoodService, RawFoodService>();

		}
	}
}
