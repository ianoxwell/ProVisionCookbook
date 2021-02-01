using Microsoft.Extensions.DependencyInjection;
using Pcb.Mapping.Implementation;
using Pcb.Mapping.Interface;

namespace Pcb.Mapping
{
    public static class Startup
    {
        public static void AddMappingServices(this IServiceCollection services)
        {
            services.AddScoped<IIngredientMapper, IngredientMapper>();
            services.AddScoped<IRecipeMapper, RecipeMapper>();
            services.AddScoped<IUserMapper, UserMapper>();
            services.AddScoped<IRawFoodMapper, RawFoodMapper>();
            services.AddScoped<IReferenceMapper, ReferenceMapper>();
        }
    }
}
