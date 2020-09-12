using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using rcLogTransfers;

namespace rcLogWeb.Services
{
  public class AutenticaService
    {
        private string enderecoServico = Settings.GetSetting("servicoAcessoApiEndereco");
        private string nomeServico = "Autentica";
        private readonly HttpClient httpClient;

        public AutenticaService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(enderecoServico);
        }
        
        public async Task<AutenticaTransfer> Autenticar(AutenticaTransfer pAutentica)
        {
            HttpResponseMessage resposta = null;
            AutenticaTransfer autentica = null;
            string mensagemRetono = null;
            
            try {
                resposta = await httpClient.PostAsync($"{nomeServico}", 
                    new StringContent(JsonConvert.SerializeObject(pAutentica), Encoding.UTF8, "application/json" ));

                if (resposta.IsSuccessStatusCode) {
                    autentica = JsonConvert.DeserializeObject<AutenticaTransfer>(resposta.Content.ReadAsStringAsync().Result);
                } else if (resposta.StatusCode == HttpStatusCode.BadRequest) {
                    autentica = JsonConvert.DeserializeObject<AutenticaTransfer>(resposta.Content.ReadAsStringAsync().Result);
                } else if (resposta.StatusCode == HttpStatusCode.Unauthorized) {
                    autentica = JsonConvert.DeserializeObject<AutenticaTransfer>(resposta.Content.ReadAsStringAsync().Result);
                } else {
                    mensagemRetono = $"Não foi possível acessar o serviço {nomeServico} Autenticar";
                }

                if (!string.IsNullOrEmpty(mensagemRetono)) {
                    autentica = new AutenticaTransfer();
                    
                    autentica.Autenticado = false;
                    autentica.Validacao = false;
                    autentica.Erro = true;
                    autentica.IncluirMensagem(mensagemRetono);
                }
            } catch (Exception ex) {
                autentica = new AutenticaTransfer();

                autentica.Autenticado = false;
                autentica.Validacao = false;
                autentica.Erro = true;
                autentica.IncluirMensagem("Erro em AutenticaService Autenticar [" + ex.Message + "]");
            } finally {
                resposta = null;
            }

            return autentica;
        }
    }
}
