using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Repositorios;
using System.Threading.Tasks;
using Dominio.ViewModels;
using Dominio.Entidades;
using Dominio.Helpers;
using AutoMapper;
using System.IO;
using Dominio.Constantes;

namespace Dominio.Servicos
{
    public class ServicoLoja : IServicoLoja
    {
        private readonly IRepositorioLoja _repositorioLoja;
        private readonly IRepositorioEndereco _repositorioEndereco;
        private readonly IMapper _mapper;

        public ServicoLoja(IMapper mapper, IRepositorioLoja repositorioLoja, IRepositorioEndereco repositorioEndereco)
        {
            _repositorioLoja = repositorioLoja;
            _repositorioEndereco = repositorioEndereco;
            _mapper = mapper;
        }

        public async Task<OutPadraoViewModel> CadastrarAsync(LojaViewModel loja)
        {
            try
            {
                //Validações de campos
                var outPadrao = await ValidaCamposAsync(loja);

                if (!outPadrao.Sucesso)
                {
                    return new OutPadraoViewModel(false, outPadrao.Mensagem);
                }

                var lojaEntidade = _mapper.Map<Loja>(loja);

                //Cadastrando endereço
                lojaEntidade.END_INT_IDF = await _repositorioEndereco.CadastrarAsync(lojaEntidade.Endereco);

                if (lojaEntidade.END_INT_IDF > 0)
                {
                    //Cria um Stream
                    MemoryStream ms = new MemoryStream();
                    await loja.LJA_FILE_ARQUIVO.CopyToAsync(ms);

                    //Lendo bytes da foto
                    lojaEntidade.LJA_BIN_FOTO = ms.ToArray();

                    //Finaliza Stream
                    ms.Close();
                    ms.Dispose();

                    //Cadastrando loja
                    await _repositorioLoja.CadastrarAsync(lojaEntidade);
                }
                else
                {
                    return new OutPadraoViewModel(false, "Erro ao tentar cadastar endereço no sistema.");
                }

                return new OutPadraoViewModel(outPadrao.Sucesso, outPadrao.Mensagem);
            }
            catch (Exception)
            {
                return new OutPadraoViewModel(false, "Erro ao tentar cadastar loja no sistema.");
            }
        }

        public async Task<OutPadraoViewModel> EditarAsync(LojaViewModel loja)
        {
            try
            {
                //Validações de campos
                var outPadrao = await ValidaCamposEdicaoAsync(loja);

                if (!outPadrao.Sucesso)
                {
                    return new OutPadraoViewModel(false, outPadrao.Mensagem);
                }

                var lojaEntidade = _mapper.Map<Loja>(loja);

                //Editando endereço
                await _repositorioEndereco.EditarAsync(lojaEntidade.Endereco);

                //Cria um Stream
                if (loja.LJA_FILE_ARQUIVO != null)
                {
                    MemoryStream ms = new MemoryStream();
                    await loja.LJA_FILE_ARQUIVO.CopyToAsync(ms);

                    //Lendo bytes da foto
                    lojaEntidade.LJA_BIN_FOTO = ms.ToArray();

                    //Finaliza Stream
                    ms.Close();
                    ms.Dispose();
                }

                //Editando loja
                await _repositorioLoja.EditarAsync(lojaEntidade);

                return new OutPadraoViewModel(outPadrao.Sucesso, outPadrao.Mensagem);
            }
            catch (Exception)
            {
                return new OutPadraoViewModel(false, "Erro ao tentar editar a loja.");
            }
        }

        public async Task<OutPadraoViewModel> ExcluirAsync(int idf)
        {
            try
            {
                await _repositorioLoja.ExcluirAsync(idf);

                return new OutPadraoViewModel(true, "Loja excluída com sucesso.");
            }
            catch (Exception)
            {
                return new OutPadraoViewModel(false, "Erro ao tentar excluir a loja.");
            }
        }

        public async Task<List<LojaViewModel>> ListarAsync()
        {
            try
            {
                List<Loja> lojas = await _repositorioLoja.ListarAsync();

                return _mapper.Map<List<LojaViewModel>>(lojas);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao tentar listar as lojas.");
            }
        }

        public async Task<LojaViewModel> ListarPorIdAsync(int idf)
        {
            try
            {
                var loja = await _repositorioLoja.ListarPorIdAsync(idf);

                return _mapper.Map<LojaViewModel>(loja);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao tentar listar a loja.");
            }
        }

        private async Task<OutPadraoViewModel> ValidaCamposEdicaoAsync(LojaViewModel loja)
        {
            try
            {
                //Valida se preencheu todos os campos
                if (string.IsNullOrEmpty(loja.LJA_STR_NOME) ||
                    string.IsNullOrEmpty(loja.LJA_STR_WHATSAPP) ||
                    string.IsNullOrEmpty(loja.LJA_STR_CNPJ_CPF) ||
                    string.IsNullOrEmpty(loja.LJA_STR_EMAIL) ||
                    string.IsNullOrEmpty(loja.LJA_STR_DESCRICAO) ||
                    string.IsNullOrEmpty(loja.Endereco.END_STR_COMPLEMENTO) ||
                    string.IsNullOrEmpty(loja.Endereco.END_STR_RUA) ||
                    string.IsNullOrEmpty(loja.Endereco.END_STR_CEP) ||
                    string.IsNullOrEmpty(loja.Endereco.END_STR_BAIRRO) ||
                    loja.Endereco.END_STR_ESTADO == 0 ||
                    string.IsNullOrEmpty(loja.Endereco.END_STR_NUMERO) ||
                    string.IsNullOrEmpty(loja.Endereco.END_STR_CIDADE))
                {
                    return new OutPadraoViewModel(false, "Preencha todos os campos obrigatórios.");
                }

                //Valida se o tamanho dos campos está correto
                if (loja.LJA_STR_NOME.Length > 255 ||
                    loja.LJA_STR_WHATSAPP.Length > 30 ||
                    loja.LJA_STR_EMAIL.Length > 255 ||
                    loja.LJA_STR_DESCRICAO.Length > 1000 ||
                    loja.Endereco.END_STR_COMPLEMENTO.Length > 255 ||
                    loja.Endereco.END_STR_RUA.Length > 255 ||
                    loja.Endereco.END_STR_CEP.Length > 10 ||
                    loja.Endereco.END_STR_BAIRRO.Length > 255 ||
                    loja.Endereco.END_STR_NUMERO.Length > 255 ||
                    loja.Endereco.END_STR_CIDADE.Length > 255)
                {
                    return new OutPadraoViewModel(false, "Tamanho limite ultrapassado.");
                }

                //Valida se o CPF/CNPJ é válido
                if ((bool)loja.LJA_BIT_CPF)
                {
                    if (!Geral.ValidarCpf(loja.LJA_STR_CNPJ_CPF))
                    {
                        return new OutPadraoViewModel(false, "CPF de pessoa física não é válido.");
                    }
                }
                else
                {
                    if (!Geral.ValidarCnpj(loja.LJA_STR_CNPJ_CPF))
                    {
                        return new OutPadraoViewModel(false, "CNPJ de pessoa júridica não é válido.");
                    }
                }

                if (!(loja.LJA_FILE_ARQUIVO is null))
                {
                    if (!(loja.LJA_FILE_ARQUIVO.ContentType.ToUpper() == CExtensoesPermitidas.PNG ||
                        loja.LJA_FILE_ARQUIVO.ContentType.ToUpper() == CExtensoesPermitidas.JPG ||
                        loja.LJA_FILE_ARQUIVO.ContentType.ToUpper() == CExtensoesPermitidas.JPEG))
                    {
                        return new OutPadraoViewModel(false, "Extensões permitidas são apenas \"JPG\" \"PNG\" e \"JPEG\".");
                    }
                }

                return new OutPadraoViewModel(true, "Loja editada com sucesso.");
            }
            catch (Exception)
            {
                return new OutPadraoViewModel(false, "Erro ao tentar cadastar usuário no sistema.");
            }
        }

        private async Task<OutPadraoViewModel> ValidaCamposAsync(LojaViewModel loja)
        {
            try
            {
                //Valida se preencheu todos os campos
                if (string.IsNullOrEmpty(loja.LJA_STR_NOME) ||
                    string.IsNullOrEmpty(loja.LJA_STR_WHATSAPP) ||
                    loja.LJA_BIT_CPF is null ||
                    string.IsNullOrEmpty(loja.LJA_STR_CNPJ_CPF) ||
                    string.IsNullOrEmpty(loja.LJA_STR_EMAIL) ||
                    loja.LJA_FILE_ARQUIVO is null ||
                    string.IsNullOrEmpty(loja.LJA_STR_DESCRICAO) ||
                    string.IsNullOrEmpty(loja.Endereco.END_STR_COMPLEMENTO) ||
                    string.IsNullOrEmpty(loja.Endereco.END_STR_RUA) ||
                    string.IsNullOrEmpty(loja.Endereco.END_STR_CEP) ||
                    string.IsNullOrEmpty(loja.Endereco.END_STR_BAIRRO) ||
                    loja.Endereco.END_STR_ESTADO == 0 ||
                    string.IsNullOrEmpty(loja.Endereco.END_STR_NUMERO) ||
                    string.IsNullOrEmpty(loja.Endereco.END_STR_CIDADE))
                {
                    return new OutPadraoViewModel(false, "Preencha todos os campos obrigatórios.");
                }

                //Valida se o tamanho dos campos está correto
                if (loja.LJA_STR_NOME.Length > 255 ||
                    loja.LJA_STR_WHATSAPP.Length > 30 ||
                    loja.LJA_STR_EMAIL.Length > 255 ||
                    loja.LJA_STR_DESCRICAO.Length > 1000 ||
                    loja.Endereco.END_STR_COMPLEMENTO.Length > 255 ||
                    loja.Endereco.END_STR_RUA.Length > 255 ||
                    loja.Endereco.END_STR_CEP.Length > 10 ||
                    loja.Endereco.END_STR_BAIRRO.Length > 255 ||
                    loja.Endereco.END_STR_NUMERO.Length > 255 ||
                    loja.Endereco.END_STR_CIDADE.Length > 255)
                {
                    return new OutPadraoViewModel(false, "Tamanho limite ultrapassado.");
                }

                //Valida se o CPF/CNPJ é válido
                if ((bool)loja.LJA_BIT_CPF)
                {
                    if (!Geral.ValidarCpf(loja.LJA_STR_CNPJ_CPF))
                    {
                        return new OutPadraoViewModel(false, "CPF de pessoa física não é válido.");
                    }
                }
                else
                {
                    if (!Geral.ValidarCnpj(loja.LJA_STR_CNPJ_CPF))
                    {
                        return new OutPadraoViewModel(false, "CNPJ de pessoa júridica não é válido.");
                    }
                }

                if (!(loja.LJA_FILE_ARQUIVO.ContentType.ToUpper() == CExtensoesPermitidas.PNG ||
                loja.LJA_FILE_ARQUIVO.ContentType.ToUpper() == CExtensoesPermitidas.JPG ||
                loja.LJA_FILE_ARQUIVO.ContentType.ToUpper() == CExtensoesPermitidas.JPEG))
                {
                    return new OutPadraoViewModel(false, "Extensões permitidas são apenas \"JPG\" \"PNG\" e \"JPEG\".");
                }

                return new OutPadraoViewModel(true, "Loja cadastrada com sucesso.");
            }
            catch (Exception)
            {
                return new OutPadraoViewModel(false, "Erro ao tentar cadastar usuário no sistema.");
            }
        }
    }
}
