using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using rcLogTransfers;

namespace rcLogWeb.Services
{
    public class LogService
    {
        private string enderecoServico = Settings.GetSetting("servicoLogWebApiEndereco");
        private string nomeServico = "Log";
        private HttpClient httpClient = null;
        AutenticaService autenticaService = null;

        public LogService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
            autenticaService = new AutenticaService();
        }

        public async Task<LogTransfer> Incluir(LogTransfer logTransfer, string autorizacao)
        {
            LogTransfer log = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsync($"{nomeServico}", new StringContent(JsonConvert.SerializeObject(logTransfer)));

                if (resposta.IsSuccessStatusCode) {
                    log = JsonConvert.DeserializeObject<LogTransfer>(resposta.Content.ReadAsStringAsync().Result);
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    log = JsonConvert.DeserializeObject<LogTransfer>(resposta.Content.ReadAsStringAsync().Result);
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Incluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Incluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    log = new LogTransfer();
                    
                    log.Validacao = false;
                    log.Erro = true;
                    log.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                log = new LogTransfer();

                log.Validacao = false;
                log.Erro = true;
                log.IncluirMensagem("Erro em LogService Incluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return log;
        }

        public async Task<LogTransfer> Alterar(LogTransfer logTransfer, string autorizacao)
        {
            LogTransfer log = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PutAsync($"{nomeServico}", new StringContent(JsonConvert.SerializeObject(logTransfer)));

                if (resposta.IsSuccessStatusCode) {
                    log = JsonConvert.DeserializeObject<LogTransfer>(resposta.Content.ReadAsStringAsync().Result);
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    log = JsonConvert.DeserializeObject<LogTransfer>(resposta.Content.ReadAsStringAsync().Result);
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Alterar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Alterar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    log = new LogTransfer();
                    
                    log.Validacao = false;
                    log.Erro = true;
                    log.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                log = new LogTransfer();

                log.Validacao = false;
                log.Erro = true;
                log.IncluirMensagem("Erro em LogService Alterar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return log;
        }

        public async Task<LogTransfer> Excluir(int id, string autorizacao)
        {
            LogTransfer log = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.DeleteAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    log = JsonConvert.DeserializeObject<LogTransfer>(resposta.Content.ReadAsStringAsync().Result);
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    log = JsonConvert.DeserializeObject<LogTransfer>(resposta.Content.ReadAsStringAsync().Result);
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Excluir não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Excluir";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    log = new LogTransfer();
                    
                    log.Validacao = false;
                    log.Erro = true;
                    log.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                log = new LogTransfer();

                log.Validacao = false;
                log.Erro = true;
                log.IncluirMensagem("Erro em LogService Excluir [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return log;
        }

        public async Task<LogTransfer> ConsultarPorId(int id, string autorizacao)
        {
            LogTransfer log = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.GetAsync($"{nomeServico}/{id}");

                if (resposta.IsSuccessStatusCode) {
                    log = JsonConvert.DeserializeObject<LogTransfer>(resposta.Content.ReadAsStringAsync().Result);
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    log = JsonConvert.DeserializeObject<LogTransfer>(resposta.Content.ReadAsStringAsync().Result);
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} ConsultarPorId não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} ConsultarPorId";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    log = new LogTransfer();
                    
                    log.Validacao = false;
                    log.Erro = true;
                    log.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                log = new LogTransfer();

                log.Validacao = false;
                log.Erro = true;
                log.IncluirMensagem("Erro em LogService ConsultarPorId [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return log;
        }

        public async Task<LogTransfer> Consultar(LogTransfer logListaTransfer, string autorizacao)
        {
            LogTransfer logLista = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", autorizacao);

                resposta = await httpClient.PostAsync($"{nomeServico}/lista", new StringContent(JsonConvert.SerializeObject(logListaTransfer)));

                if (resposta.IsSuccessStatusCode) {
                    logLista = JsonConvert.DeserializeObject<LogTransfer>(resposta.Content.ReadAsStringAsync().Result);
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    logLista = JsonConvert.DeserializeObject<LogTransfer>(resposta.Content.ReadAsStringAsync().Result);
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Consultar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Consultar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    logLista = new LogTransfer();
                    
                    logLista.Validacao = false;
                    logLista.Erro = true;
                    logLista.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                logLista = new LogTransfer();

                logLista.Validacao = false;
                logLista.Erro = true;
                logLista.IncluirMensagem("Erro em LogService Consultar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return logLista;
        }
    }
}
