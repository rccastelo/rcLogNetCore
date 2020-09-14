using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using rcLogTransfers;

namespace rcLogWeb.Services
{
    public class SistemaService
    {
        private string enderecoServico = Settings.GetSetting("servicoLogWebApiEndereco");
        private string nomeServico = "Sistema";
        private HttpClient httpClient = null;
        AutenticaService autenticaService = null;

        public SistemaService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
            autenticaService = new AutenticaService();
        }

        // public async Task<SistemaTransfer> Incluir(SistemaTransfer sistemaTransfer, string pAutorizacao)
        // {
        //     SistemaTransfer sistema = null;
        //     HttpResponseMessage resposta = null;
        //     string mensagemRetono = null;
            
        //     try {
        //         httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", pAutorizacao);

        //         resposta = await httpClient.PostAsync($"{nomeServico}", new StringContent(JsonConvert.SerializeObject(sistemaTransfer)));

        //         if (resposta.IsSuccessStatusCode) {
        //             sistema = JsonConvert.DeserializeObject<SistemaTransfer>(resposta.Content.ReadAsStringAsync().Result);
        //         } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
        //             sistema = JsonConvert.DeserializeObject<SistemaTransfer>(resposta.Content.ReadAsStringAsync().Result);
        //         } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
        //             mensagemRetono = $"Acesso ao serviço {nomeServico} Incluir não autorizado";
        //         } else {
        //             mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Incluir";
        //         }

        //         if (!string.IsNullOrEmpty(mensagemRetono)) {
        //             sistema = new SistemaTransfer();
                    
        //             sistema.Validacao = false;
        //             sistema.Erro = true;
        //             sistema.IncluirMensagem(mensagemRetono);
        //         }
        //     } catch (Exception ex) {
        //         sistema = new SistemaTransfer();

        //         sistema.Validacao = false;
        //         sistema.Erro = true;
        //         sistema.IncluirMensagem("Erro em SistemaService Incluir [" + ex.Message + "]");
        //     } finally {
        //         resposta = null;
        //     }

        //     return sistema;
        // }

        // public async Task<SistemaTransfer> Alterar(SistemaTransfer sistemaTransfer, string pAutorizacao)
        // {
        //     SistemaTransfer sistema = null;
        //     HttpResponseMessage resposta = null;
        //     string mensagemRetono = null;
            
        //     try {
        //         httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", pAutorizacao);

        //         resposta = await httpClient.PutAsync($"{nomeServico}", new StringContent(JsonConvert.SerializeObject(sistemaTransfer)));

        //         if (resposta.IsSuccessStatusCode) {
        //             sistema = JsonConvert.DeserializeObject<SistemaTransfer>(resposta.Content.ReadAsStringAsync().Result);
        //         } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
        //             sistema = JsonConvert.DeserializeObject<SistemaTransfer>(resposta.Content.ReadAsStringAsync().Result);
        //         } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
        //             mensagemRetono = $"Acesso ao serviço {nomeServico} Alterar não autorizado";
        //         } else {
        //             mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Alterar";
        //         }

        //         if (!string.IsNullOrEmpty(mensagemRetono)) {
        //             sistema = new SistemaTransfer();
                    
        //             sistema.Validacao = false;
        //             sistema.Erro = true;
        //             sistema.IncluirMensagem(mensagemRetono);
        //         }
        //     } catch (Exception ex) {
        //         sistema = new SistemaTransfer();

        //         sistema.Validacao = false;
        //         sistema.Erro = true;
        //         sistema.IncluirMensagem("Erro em SistemaService Alterar [" + ex.Message + "]");
        //     } finally {
        //         resposta = null;
        //     }

        //     return sistema;
        // }

        // public async Task<SistemaTransfer> Excluir(int id, string pAutorizacao)
        // {
        //     SistemaTransfer sistema = null;
        //     HttpResponseMessage resposta = null;
        //     string mensagemRetono = null;
            
        //     try {
        //         httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", pAutorizacao);

        //         resposta = await httpClient.DeleteAsync($"{nomeServico}/{id}");

        //         if (resposta.IsSuccessStatusCode) {
        //             sistema = JsonConvert.DeserializeObject<SistemaTransfer>(resposta.Content.ReadAsStringAsync().Result);
        //         } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
        //             sistema = JsonConvert.DeserializeObject<SistemaTransfer>(resposta.Content.ReadAsStringAsync().Result);
        //         } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
        //             mensagemRetono = $"Acesso ao serviço {nomeServico} Excluir não autorizado";
        //         } else {
        //             mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Excluir";
        //         }

        //         if (!string.IsNullOrEmpty(mensagemRetono)) {
        //             sistema = new SistemaTransfer();
                    
        //             sistema.Validacao = false;
        //             sistema.Erro = true;
        //             sistema.IncluirMensagem(mensagemRetono);
        //         }
        //     } catch (Exception ex) {
        //         sistema = new SistemaTransfer();

        //         sistema.Validacao = false;
        //         sistema.Erro = true;
        //         sistema.IncluirMensagem("Erro em SistemaService Excluir [" + ex.Message + "]");
        //     } finally {
        //         resposta = null;
        //     }

        //     return sistema;
        // }

        // public async Task<SistemaTransfer> ConsultarPorId(int id, string pAutorizacao)
        // {
        //     SistemaTransfer sistema = null;
        //     HttpResponseMessage resposta = null;
        //     string mensagemRetono = null;
            
        //     try {
        //         httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", pAutorizacao);

        //         resposta = await httpClient.GetAsync($"{nomeServico}/{id}");

        //         if (resposta.IsSuccessStatusCode) {
        //             sistema = JsonConvert.DeserializeObject<SistemaTransfer>(resposta.Content.ReadAsStringAsync().Result);
        //         } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
        //             sistema = JsonConvert.DeserializeObject<SistemaTransfer>(resposta.Content.ReadAsStringAsync().Result);
        //         } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
        //             mensagemRetono = $"Acesso ao serviço {nomeServico} ConsultarPorId não autorizado";
        //         } else {
        //             mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} ConsultarPorId";
        //         }

        //         if (!string.IsNullOrEmpty(mensagemRetono)) {
        //             sistema = new SistemaTransfer();
                    
        //             sistema.Validacao = false;
        //             sistema.Erro = true;
        //             sistema.IncluirMensagem(mensagemRetono);
        //         }
        //     } catch (Exception ex) {
        //         sistema = new SistemaTransfer();

        //         sistema.Validacao = false;
        //         sistema.Erro = true;
        //         sistema.IncluirMensagem("Erro em SistemaService ConsultarPorId [" + ex.Message + "]");
        //     } finally {
        //         resposta = null;
        //     }

        //     return sistema;
        // }

        public async Task<SistemaTransfer> Consultar(SistemaTransfer pSistemaLista, string pAutorizacao)
        {
            SistemaTransfer sistemaLista = null;
            HttpResponseMessage resposta = null;
            string mensagemRetono = null;
            
            try {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", pAutorizacao);

                HttpContent content = new StringContent(JsonConvert.SerializeObject(pSistemaLista), Encoding.UTF8, "application/json");

                resposta = await httpClient.PostAsync($"{nomeServico}/lista", content);

                if (resposta.IsSuccessStatusCode) {
                    sistemaLista = JsonConvert.DeserializeObject<SistemaTransfer>(resposta.Content.ReadAsStringAsync().Result);
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    sistemaLista = JsonConvert.DeserializeObject<SistemaTransfer>(resposta.Content.ReadAsStringAsync().Result);
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    mensagemRetono = $"Acesso ao serviço {nomeServico} Consultar não autorizado";
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Consultar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    sistemaLista = new SistemaTransfer();
                    
                    sistemaLista.Validacao = false;
                    sistemaLista.Erro = true;
                    sistemaLista.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                sistemaLista = new SistemaTransfer();

                sistemaLista.Validacao = false;
                sistemaLista.Erro = true;
                sistemaLista.IncluirMensagem("Erro em SistemaService Consultar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return sistemaLista;
        }
    }
}
