using AutoMapper;
using Dominio.Entidades;
using Dominio.ViewModels;

namespace Gerenciador.Configurations
{
	public class MappingModels : Profile
	{
		public MappingModels()
		{
			CreateMap<UsuarioViewModel, Usuario>().ReverseMap();
			CreateMap<UsuarioEnderecoViewModel, UsuarioEndereco>().ReverseMap();
        
			CreateMap<LojaViewModel, Loja>().ReverseMap();
            CreateMap<EnderecoViewModel, Endereco>().ReverseMap();
        }
    }
}
