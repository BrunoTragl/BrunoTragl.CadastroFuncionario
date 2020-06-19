using BrunoTragl.CadastroFuncionario.Business.Service.Interfaces;
using BrunoTragl.CadastroFuncionario.Domain.Model.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BrunoTragl.CadastroFuncionario.Business.Service.Configuration
{
    public static class HttpContext
    {
        private static DateTime _tokenExpiraEm;
        private static string _ultimoToken;
        public static HttpClient GetHttpClient()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("UrlBase"));

                if (_tokenExpiraEm == null || DateTime.Now > _tokenExpiraEm)
                {
                    AccessToken accessToken = GetToken();
                    
                    if (accessToken == null || string.IsNullOrEmpty(accessToken.Token))
                        throw new Exception("Ocorreu um erro ao buscar o token.");

                    _ultimoToken = accessToken.Token;
                    _tokenExpiraEm = DateTime.Now.AddSeconds(accessToken.TokenExpireIn);
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _ultimoToken);
                }
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _ultimoToken);
                return httpClient;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static AccessToken GetToken()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("UrlBase"));
                
                var dicBody = new Dictionary<string, string>();
                dicBody.Add("UserName", ConfigurationManager.AppSettings.Get("UserName"));
                dicBody.Add("Password", ConfigurationManager.AppSettings.Get("Password"));
                dicBody.Add("grant_type", ConfigurationManager.AppSettings.Get("GrantType"));

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/token");
                request.Content = new FormUrlEncodedContent(dicBody);

                using (var response = httpClient.SendAsync(request).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<AccessToken>(jsonResponse);
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
