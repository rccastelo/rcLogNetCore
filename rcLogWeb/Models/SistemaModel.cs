using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rcLogTransfers;
using rcLogWeb.Services;

namespace rcLogWeb.Models
{
    public class SistemaModel
    {
        private readonly IHttpContextAccessor httpContext;

        public SistemaModel(IHttpContextAccessor pAccessor)
        {
            httpContext = pAccessor;
        }

        // public async Task<SistemaTransfer> Incluir(SistemaTransfer logTransfer)
        // {
        //     SistemaService sistemaService;
        //     SistemaTransfer cor;
        //     AutenticaModel autenticaModel;
        //     string autorizacao;

        //     try {
        //         sistemaService = new SistemaService();
        //         autenticaModel = new AutenticaModel(httpContext);

        //         autorizacao = autenticaModel.ObterToken();

        //         cor = await sistemaService.Incluir(logTransfer, autorizacao);
        //     } catch (Exception ex) {
        //         cor = new SistemaTransfer();

        //         cor.Validacao = false;
        //         cor.Erro = true;
        //         cor.IncluirMensagem("Erro em LogModel Incluir [" + ex.Message + "]");
        //     } finally {
        //         sistemaService = null;
        //         autenticaModel = null;
        //     }

        //     return cor;
        // }

        // public async Task<SistemaTransfer> Alterar(SistemaTransfer logTransfer)
        // {
        //     SistemaService sistemaService;
        //     SistemaTransfer cor;
        //     AutenticaModel autenticaModel;
        //     string autorizacao;

        //     try {
        //         sistemaService = new SistemaService();
        //         autenticaModel = new AutenticaModel(httpContext);

        //         autorizacao = autenticaModel.ObterToken();

        //         cor = await sistemaService.Alterar(logTransfer, autorizacao);
        //     } catch (Exception ex) {
        //         cor = new SistemaTransfer();

        //         cor.Validacao = false;
        //         cor.Erro = true;
        //         cor.IncluirMensagem("Erro em LogModel Alterar [" + ex.Message + "]");
        //     } finally {
        //         sistemaService = null;
        //         autenticaModel = null;
        //     }

        //     return cor;
        // }

        // public async Task<SistemaTransfer> Excluir(int id)
        // {
        //     SistemaService sistemaService;
        //     SistemaTransfer cor;
        //     AutenticaModel autenticaModel;
        //     string autorizacao;

        //     try {
        //         sistemaService = new SistemaService();
        //         autenticaModel = new AutenticaModel(httpContext);

        //         autorizacao = autenticaModel.ObterToken();

        //         cor = await sistemaService.Excluir(id, autorizacao);
        //     } catch (Exception ex) {
        //         cor = new SistemaTransfer();

        //         cor.Validacao = false;
        //         cor.Erro = true;
        //         cor.IncluirMensagem("Erro em LogModel Excluir [" + ex.Message + "]");
        //     } finally {
        //         sistemaService = null;
        //         autenticaModel = null;
        //     }

        //     return cor;
        // }

        // public async Task<SistemaTransfer> ConsultarPorId(int id)
        // {
        //     SistemaService sistemaService;
        //     SistemaTransfer cor;
        //     AutenticaModel autenticaModel;
        //     string autorizacao;
            
        //     try {
        //         sistemaService = new SistemaService();
        //         autenticaModel = new AutenticaModel(httpContext);

        //         autorizacao = autenticaModel.ObterToken();

        //         cor = await sistemaService.ConsultarPorId(id, autorizacao);
        //     } catch (Exception ex) {
        //         cor = new SistemaTransfer();

        //         cor.Validacao = false;
        //         cor.Erro = true;
        //         cor.IncluirMensagem("Erro em LogModel ConsultarPorId [" + ex.Message + "]");
        //     } finally {
        //         sistemaService = null;
        //         autenticaModel = null;
        //     }

        //     return cor;
        // }

        public async Task<SistemaTransfer> Consultar(SistemaTransfer pSistemaLista)
        {
            SistemaService sistemaService;
            SistemaTransfer sistemaLista;
            AutenticaModel autenticaModel;
            string autorizacao;
            int dif = 0;
            int qtdExibe = 5;

            try {
                sistemaService = new SistemaService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                sistemaLista = await sistemaService.Consultar(pSistemaLista, autorizacao);

                if (sistemaLista != null) {
                    if (sistemaLista.Paginacao.TotalRegistros > 0) {
                        if (sistemaLista.Paginacao.RegistrosPorPagina < 1) {
                            sistemaLista.Paginacao.RegistrosPorPagina = 30;
                        } else if (sistemaLista.Paginacao.RegistrosPorPagina > 200) {
                            sistemaLista.Paginacao.RegistrosPorPagina = 30;
                        }

                        sistemaLista.Paginacao.PaginaAtual = (sistemaLista.Paginacao.PaginaAtual < 1 ? 1 : sistemaLista.Paginacao.PaginaAtual);
                        sistemaLista.Paginacao.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(sistemaLista.Paginacao.TotalRegistros) 
                            / @Convert.ToDecimal(sistemaLista.Paginacao.RegistrosPorPagina)));
                        sistemaLista.Paginacao.TotalPaginas = (sistemaLista.Paginacao.TotalPaginas < 1 ? 1 : sistemaLista.Paginacao.TotalPaginas);
                        if (sistemaLista.Paginacao.PaginaAtual > sistemaLista.Paginacao.TotalPaginas) {
                            sistemaLista.Paginacao.PaginaAtual = sistemaLista.Paginacao.TotalPaginas;
                        }

                        qtdExibe = (qtdExibe > sistemaLista.Paginacao.TotalPaginas ? sistemaLista.Paginacao.TotalPaginas : qtdExibe);

                        sistemaLista.Paginacao.PaginaInicial = sistemaLista.Paginacao.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        sistemaLista.Paginacao.PaginaFinal = sistemaLista.Paginacao.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        sistemaLista.Paginacao.PaginaFinal = ((qtdExibe % 2) == 0 ? (sistemaLista.Paginacao.PaginaFinal - 1) : sistemaLista.Paginacao.PaginaFinal);

                        if (sistemaLista.Paginacao.PaginaInicial < 1) {
                            dif = 1 - sistemaLista.Paginacao.PaginaInicial;
                            sistemaLista.Paginacao.PaginaInicial += dif;
                            sistemaLista.Paginacao.PaginaFinal += dif;
                        }

                        if (sistemaLista.Paginacao.PaginaFinal > sistemaLista.Paginacao.TotalPaginas) {
                            dif = sistemaLista.Paginacao.PaginaFinal - sistemaLista.Paginacao.TotalPaginas;
                            sistemaLista.Paginacao.PaginaInicial -= dif;
                            sistemaLista.Paginacao.PaginaFinal -= dif;
                        }

                        sistemaLista.Paginacao.PaginaInicial = (sistemaLista.Paginacao.PaginaInicial < 1 ? 1 : sistemaLista.Paginacao.PaginaInicial);
                        sistemaLista.Paginacao.PaginaFinal = (sistemaLista.Paginacao.PaginaFinal > sistemaLista.Paginacao.TotalPaginas ? 
                            sistemaLista.Paginacao.TotalPaginas : sistemaLista.Paginacao.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                sistemaLista = new SistemaTransfer();

                sistemaLista.Validacao = false;
                sistemaLista.Erro = true;
                sistemaLista.IncluirMensagem("Erro em LogModel Consultar [" + ex.Message + "]");
            } finally {
                sistemaService = null;
                autenticaModel = null;
            }

            return sistemaLista;
        }
    }
}
