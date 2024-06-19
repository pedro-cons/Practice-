using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Gerenciador.Configurations
{
	public static class AutoMapperConfig
	{
		public static void RegisterAutoMapper(this IServiceCollection services)
		{
			// Configura o automapper com o respectivo profile
			var configMapper = AutoMapperConfigEntities.RegisterMappings();

			var mapper = configMapper.CreateMapper();
			services.AddSingleton(mapper);
		}
	}
}
