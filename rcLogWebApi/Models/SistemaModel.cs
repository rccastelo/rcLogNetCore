using System;
using rcLogDataModels;
using rcLogTransfers;

namespace rcLogWebApi.Models
{
    public class SistemaModel
    {
        public SistemaTransfer Incluir(SistemaTransfer pSistema)
        {
            SistemaDataModel sistemaDataModel;
            SistemaTransfer sistemaValidacao;
            SistemaTransfer sistemaInclusao;

            try {
                // sistemaBusiness = new SistemaBusiness();
                sistemaDataModel = new SistemaDataModel();

                // sistemaValidacao = sistemaBusiness.Validar(pSistema);
                sistemaValidacao = new SistemaTransfer();

                if (!sistemaValidacao.Erro) {
                    if (sistemaValidacao.Validacao) {
                        // sistemaInclusao = sistemaDataModel.Incluir(sistemaValidacao);
                        sistemaInclusao = new SistemaTransfer();
                    } else {
                        sistemaInclusao = new SistemaTransfer(sistemaValidacao);
                    }
                } else {
                    sistemaInclusao = new SistemaTransfer(sistemaValidacao);
                }
            } catch (Exception ex) {
                sistemaInclusao = new SistemaTransfer();

                sistemaInclusao.Validacao = false;
                sistemaInclusao.Erro = true;
                sistemaInclusao.IncluirMensagem("Erro em SistemaModel Incluir [" + ex.Message + "]");
            } finally {
                sistemaDataModel = null;
                // sistemaBusiness = null;
                sistemaValidacao = null;
            }

            return sistemaInclusao;
        }

        public SistemaTransfer Alterar(SistemaTransfer pSistema)
        {
            // SistemaDataModel sistemaDataModel;
            // SistemaBusiness sistemaBusiness;
            SistemaTransfer sistemaValidacao;
            SistemaTransfer sistemaAlteracao;

            try {
                // sistemaBusiness = new SistemaBusiness();
                // sistemaDataModel = new SistemaDataModel();

                // sistemaValidacao = sistemaBusiness.Validar(pSistema);
                sistemaValidacao = new SistemaTransfer();

                if (!sistemaValidacao.Erro) {
                    if (sistemaValidacao.Validacao) {
                        // sistemaAlteracao = sistemaDataModel.Alterar(sistemaValidacao);
                        sistemaAlteracao = new SistemaTransfer();
                    } else {
                        sistemaAlteracao = new SistemaTransfer(sistemaValidacao);
                    }
                } else {
                    sistemaAlteracao = new SistemaTransfer(sistemaValidacao);
                }
            } catch (Exception ex) {
                sistemaAlteracao = new SistemaTransfer();

                sistemaAlteracao.Validacao = false;
                sistemaAlteracao.Erro = true;
                sistemaAlteracao.IncluirMensagem("Erro em SistemaModel Alterar [" + ex.Message + "]");
            } finally {
                // sistemaDataModel = null;
                // sistemaBusiness = null;
                sistemaValidacao = null;
            }

            return sistemaAlteracao;
        }

        public SistemaTransfer Excluir(int pId)
        {
            // SistemaDataModel sistemaDataModel;
            SistemaTransfer sistema;

            try {
                // sistemaDataModel = new SistemaDataModel();

                // sistema = sistemaDataModel.Excluir(pId);
                sistema = new SistemaTransfer();
            } catch (Exception ex) {
                sistema = new SistemaTransfer();

                sistema.Validacao = false;
                sistema.Erro = true;
                sistema.IncluirMensagem("Erro em SistemaModel Excluir [" + ex.Message + "]");
            } finally {
                // sistemaDataModel = null;
            }

            return sistema;
        }

        public SistemaTransfer ConsultarPorId(int pId)
        {
            // SistemaDataModel sistemaDataModel;
            SistemaTransfer sistema;
            
            try {
                // sistemaDataModel = new SistemaDataModel();

                // sistema = sistemaDataModel.ConsultarPorId(pId);
                sistema = new SistemaTransfer();
            } catch (Exception ex) {
                sistema = new SistemaTransfer();

                sistema.Validacao = false;
                sistema.Erro = true;
                sistema.IncluirMensagem("Erro em SistemaModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                // sistemaDataModel = null;
            }

            return sistema;
        }

        public SistemaTransfer Consultar(SistemaTransfer pSistemaLista)
        {
            SistemaDataModel sistemaDataModel;
            // SistemaBusiness sistemaBusiness;
            SistemaTransfer sistemaValidacao;
            SistemaTransfer sistemaLista;

            try {
                // sistemaBusiness = new SistemaBusiness();
                sistemaDataModel = new SistemaDataModel();

                // sistemaValidacao = sistemaBusiness.ValidarConsulta(pSistemaLista);
                sistemaValidacao = new SistemaTransfer();

                if (!sistemaValidacao.Erro) {
                    if (sistemaValidacao.Validacao) {
                        sistemaLista = sistemaDataModel.Consultar(sistemaValidacao);

                        if (sistemaLista != null) {
                            if (sistemaLista.Paginacao.TotalRegistros > 0) {
                                if (sistemaLista.Paginacao.RegistrosPorPagina < 1) {
                                    sistemaLista.Paginacao.RegistrosPorPagina = 30;
                                } else if (sistemaLista.Paginacao.RegistrosPorPagina > 200) {
                                    sistemaLista.Paginacao.RegistrosPorPagina = 30;
                                }
                                sistemaLista.Paginacao.PaginaAtual = (pSistemaLista.Paginacao.PaginaAtual < 1 ? 1 : pSistemaLista.Paginacao.PaginaAtual);
                                sistemaLista.Paginacao.TotalPaginas = 
                                    Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(sistemaLista.Paginacao.TotalRegistros) 
                                    / @Convert.ToDecimal(sistemaLista.Paginacao.RegistrosPorPagina)));
                            }
                        }
                    } else {
                        sistemaLista = new SistemaTransfer(sistemaValidacao);
                    }
                } else {
                    sistemaLista = new SistemaTransfer(sistemaValidacao);
                }
            } catch (Exception ex) {
                sistemaLista = new SistemaTransfer();
                sistemaLista.Erro = true;
                sistemaLista.IncluirMensagem("Erro em SistemaModel Consultar [" + ex.Message + "]");
            } finally {
                sistemaDataModel = null;
                // sistemaBusiness = null;
                sistemaValidacao = null;
            }

            return sistemaLista;
        }
    }
}
