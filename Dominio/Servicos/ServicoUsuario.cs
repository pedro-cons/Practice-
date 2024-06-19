using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Repositorios;
using System.Threading.Tasks;
using Dominio.ViewModels;
using Dominio.Helpers;
using System.Reflection;
using Dominio.Entidades;
using System.Linq;
using AutoMapper;

namespace Dominio.Servicos
{
    public class ServicoUsuario : IServicoUsuario
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IMapper _mapper;

        public ServicoUsuario(IMapper mapper, IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
            _mapper = mapper;
        }

        public async Task<OutPadraoViewModel> AuthenticarAsync(LoginViewModel login)
        {
            try
            {
                //Verifica se preencheu os campos
                if (!string.IsNullOrEmpty(login.Senha) && !string.IsNullOrEmpty(login.CNPJ_CPF))
                {
                    var usuario = await _repositorioUsuario.ListarPorLoginAsync(login.CNPJ_CPF);

                    //Valida se encontrou o usuário
                    if (usuario.USU_INT_IDF != 0)
                    {
                        //Verifica senha com criptografia e salva na sessão
                        if (Criptografia.verificaHash(login.Senha, usuario.USU_STR_SENHA))
                        {
                            Sessao.Setar<Usuario>(SessaoItem.Usuario, usuario);
                        }
                        else
                        {
                            return new OutPadraoViewModel(false, "Usuário ou Senha incorretos.");
                        }
                    }
                    else
                    {
                        return new OutPadraoViewModel(false, "Usuário ou Senha incorretos.");
                    }
                }
                else
                {
                    return new OutPadraoViewModel(false, "Necessário preencher todos os campos.");
                }

                return new OutPadraoViewModel(true, "Bem vindo novamente ao Practice - " + Sessao.Usuario.USU_STR_LOGIN + ".");
            }
            catch (Exception)
            {
                return new OutPadraoViewModel(false, "Erro ao tentar entrar no sistema.");
            }
        }

        public async Task<OutPadraoViewModel> CadastrarAsync(UsuarioViewModel usuario)
        {
            try
            {
                //Validações de campos
                var outPadrao = await ValidaCamposAsync(usuario);
                if (!outPadrao.Sucesso)
                {
                    return new OutPadraoViewModel(false, outPadrao.Mensagem);
                }

                var usuarioEntidade = _mapper.Map<Usuario>(usuario);

                //Criptografando senha
                usuarioEntidade.USU_STR_SENHA = Criptografia.GerarMD5Hash(usuario.USU_STR_SENHA);

                //Cadastrando usuário
                await _repositorioUsuario.CadastrarAsync(usuarioEntidade);

                return new OutPadraoViewModel(outPadrao.Sucesso, outPadrao.Mensagem);
            }
            catch (Exception)
            {
                return new OutPadraoViewModel(false, "Erro ao tentar cadastar usuário no sistema.");
            }
        }

        public async Task<OutPadraoViewModel> ValidaCamposAsync(UsuarioViewModel usuario)
        {
            //Valida se preencheu todos os campos
            if (string.IsNullOrEmpty(usuario.USU_STR_SENHA) ||
                string.IsNullOrEmpty(usuario.USU_STR_SENHA_CONFIRMAR) ||
                string.IsNullOrEmpty(usuario.USU_STR_LOGIN) ||
                string.IsNullOrEmpty(usuario.USU_STR_WHATSAPP))
            {
                return new OutPadraoViewModel(false, "Preencha todos os campos obrigatórios.");
            }

            //Valida se o tamanho dos campos está correto
            if (usuario.USU_STR_WHATSAPP.Length > 30 ||
                usuario.USU_STR_LOGIN.Length > 30)
            {
                return new OutPadraoViewModel(false, "Tamanho limite ultrapassado.");
            }

            //Valida se já não existe um usuário no banco com esse CPF/CNPJ
            var usuarioExiste = await _repositorioUsuario.ListarPorLoginAsync(usuario.USU_STR_LOGIN);
            if (usuarioExiste.USU_INT_IDF != 0)
            {
                return new OutPadraoViewModel(false, "Usuário já cadastrado no sistema.");
            }

            //Verifica confirmação de senha
            if (usuario.USU_STR_SENHA != usuario.USU_STR_SENHA_CONFIRMAR)
            {
                return new OutPadraoViewModel(false, "Os campos \"Senha\" e \"Confirmar Senha\" devem ser iguais.");
            }

            return new OutPadraoViewModel(true, "Usuário cadastrado com sucesso.");
        }
    }
}
