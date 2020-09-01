using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using rcLogTransfers;
using rcLogWeb.Services;

namespace rcLogWeb.Models
{
    public class LogModel
    {
        private readonly IHttpContextAccessor httpContext;

        public LogModel(IHttpContextAccessor accessor)
        {
            httpContext = accessor;
        }

        public async Task<LogTransfer> Incluir(LogTransfer logTransfer)
        {
            LogService logService;
            LogTransfer cor;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                logService = new LogService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                cor = await logService.Incluir(logTransfer, autorizacao);
            } catch (Exception ex) {
                cor = new LogTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em LogModel Incluir [" + ex.Message + "]");
            } finally {
                logService = null;
                autenticaModel = null;
            }

            return cor;
        }

        public async Task<LogTransfer> Alterar(LogTransfer logTransfer)
        {
            LogService logService;
            LogTransfer cor;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                logService = new LogService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                cor = await logService.Alterar(logTransfer, autorizacao);
            } catch (Exception ex) {
                cor = new LogTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em LogModel Alterar [" + ex.Message + "]");
            } finally {
                logService = null;
                autenticaModel = null;
            }

            return cor;
        }

        public async Task<LogTransfer> Excluir(int id)
        {
            LogService logService;
            LogTransfer cor;
            AutenticaModel autenticaModel;
            string autorizacao;

            try {
                logService = new LogService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                cor = await logService.Excluir(id, autorizacao);
            } catch (Exception ex) {
                cor = new LogTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em LogModel Excluir [" + ex.Message + "]");
            } finally {
                logService = null;
                autenticaModel = null;
            }

            return cor;
        }

        public async Task<LogTransfer> ConsultarPorId(int id)
        {
            LogService logService;
            LogTransfer cor;
            AutenticaModel autenticaModel;
            string autorizacao;
            
            try {
                logService = new LogService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                cor = await logService.ConsultarPorId(id, autorizacao);
            } catch (Exception ex) {
                cor = new LogTransfer();

                cor.Validacao = false;
                cor.Erro = true;
                cor.IncluirMensagem("Erro em LogModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                logService = null;
                autenticaModel = null;
            }

            return cor;
        }

        public async Task<LogTransfer> Consultar(LogTransfer corListaTransfer)
        {
            LogService logService;
            LogTransfer corLista;
            AutenticaModel autenticaModel;
            string autorizacao;
            int dif = 0;
            int qtdExibe = 5;

            try {
                logService = new LogService();
                autenticaModel = new AutenticaModel(httpContext);

                autorizacao = autenticaModel.ObterToken();

                corLista = await logService.Consultar(corListaTransfer, autorizacao);

                if (corLista != null) {
                    if (corLista.Paginacao.TotalRegistros > 0) {
                        if (corLista.Paginacao.RegistrosPorPagina < 1) {
                            corLista.Paginacao.RegistrosPorPagina = 30;
                        } else if (corLista.Paginacao.RegistrosPorPagina > 200) {
                            corLista.Paginacao.RegistrosPorPagina = 30;
                        }

                        corLista.Paginacao.PaginaAtual = (corLista.Paginacao.PaginaAtual < 1 ? 1 : corLista.Paginacao.PaginaAtual);
                        corLista.Paginacao.TotalPaginas = 
                            Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(corLista.Paginacao.TotalRegistros) 
                            / @Convert.ToDecimal(corLista.Paginacao.RegistrosPorPagina)));
                        corLista.Paginacao.TotalPaginas = (corLista.Paginacao.TotalPaginas < 1 ? 1 : corLista.Paginacao.TotalPaginas);

                        qtdExibe = (qtdExibe > corLista.Paginacao.TotalPaginas ? corLista.Paginacao.TotalPaginas : qtdExibe);

                        corLista.Paginacao.PaginaInicial = corLista.Paginacao.PaginaAtual - (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        corLista.Paginacao.PaginaFinal = corLista.Paginacao.PaginaAtual + (Convert.ToInt32(Math.Floor(qtdExibe / 2.0)));
                        corLista.Paginacao.PaginaFinal = ((qtdExibe % 2) == 0 ? (corLista.Paginacao.PaginaFinal - 1) : corLista.Paginacao.PaginaFinal);

                        if (corLista.Paginacao.PaginaInicial < 1) {
                            dif = 1 - corLista.Paginacao.PaginaInicial;
                            corLista.Paginacao.PaginaInicial += dif;
                            corLista.Paginacao.PaginaFinal += dif;
                        }

                        if (corLista.Paginacao.PaginaFinal > corLista.Paginacao.TotalPaginas) {
                            dif = corLista.Paginacao.PaginaFinal - corLista.Paginacao.TotalPaginas;
                            corLista.Paginacao.PaginaInicial -= dif;
                            corLista.Paginacao.PaginaFinal -= dif;
                        }

                        corLista.Paginacao.PaginaInicial = (corLista.Paginacao.PaginaInicial < 1 ? 1 : corLista.Paginacao.PaginaInicial);
                        corLista.Paginacao.PaginaFinal = (corLista.Paginacao.PaginaFinal > corLista.Paginacao.TotalPaginas ? 
                            corLista.Paginacao.TotalPaginas : corLista.Paginacao.PaginaFinal);
                    }
                }
            } catch (Exception ex) {
                corLista = new LogTransfer();

                corLista.Validacao = false;
                corLista.Erro = true;
                corLista.IncluirMensagem("Erro em LogModel Consultar [" + ex.Message + "]");
            } finally {
                logService = null;
                autenticaModel = null;
            }

            return corLista;
        }
    }
}
