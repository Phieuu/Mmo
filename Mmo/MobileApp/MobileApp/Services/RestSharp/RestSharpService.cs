using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AUTO.HLT.MOBILE.VIP.Models.RequestProviderModel;
using RestSharp;

namespace MobileApp.Services.RestSharp
{
    public class RestSharpService : IRestSharpService
    {
        private RestClient _client;
        private RestRequest _request;
        public RestSharpService()
        {
            _client = new RestClient();
            _request = new RestRequest();
            _request.Timeout = -1;
        }
        /// <summary>
        /// them du lieu chuyen vao request
        /// </summary>
        /// <param name="parameters"></param>
        private void AddPrarameter(IReadOnlyCollection<RequestParameter> parameters)
        {
            try
            {
                foreach (var item in parameters)
                {
                    _request.AddParameter(item.Key, item.Value);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// them cookie
        /// </summary>
        /// <param name="cookie"></param>
        private void AddHeader(string cookie, string domain = ".facebook.com")
        {
            try
            {
                if (cookie != null)
                {
                    var data = cookie.Split(';');
                    if (data.Any())
                    {
                        foreach (var item in data)
                        {
                            var ckie = item?.Split('=');
                            if (ckie.Any())
                            {
                                _client.CookieContainer.Add(new Cookie
                                {
                                    Name = ckie[0],
                                    Value = ckie[1],
                                    Domain = domain,
                                    Path = "/"
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public async Task<string> GetAsync(string uri, IReadOnlyCollection<RequestParameter> parameters = null, string cookie = null)
        {
            try
            {
                _request.Method = Method.Get;
                if (parameters != null && parameters.Any())
                {
                    AddPrarameter(parameters);
                }

                if (!string.IsNullOrWhiteSpace(cookie))
                {
                    AddHeader(cookie);
                }

                var response = await _client.ExecuteAsync(_request);

                return response.Content;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<string> PostAsync(string uri, IReadOnlyCollection<RequestParameter> parameters = null, string cookie = null)
        {
            try
            {
                _request.Method = Method.Post;
                if (parameters != null && parameters.Any())
                {
                    AddPrarameter(parameters);
                }
                if (!string.IsNullOrWhiteSpace(cookie))
                {
                    AddHeader(cookie);
                }
                var response = await _client.ExecuteAsync(_request);
                return response.Content;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<string> PutAsync(string uri, IReadOnlyCollection<RequestParameter> parameters = null, string cookie = null)
        {
            try
            {
                _request.Method = Method.Put;
                if (parameters != null && parameters.Any())
                {
                    AddPrarameter(parameters);
                }
                if (!string.IsNullOrWhiteSpace(cookie))
                {
                    AddHeader(cookie);
                }
                var response = await _client.ExecuteAsync(_request);
                return response.Content;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<string> DeleteAsync(string uri, IReadOnlyCollection<RequestParameter> parameters = null, string cookie = null)
        {
            try
            {
                _request.Method = Method.Delete;
                if (parameters != null && parameters.Any())
                {
                    AddPrarameter(parameters);
                }
                if (!string.IsNullOrWhiteSpace(cookie))
                {
                    AddHeader(cookie);
                }
                var response = await _client.ExecuteAsync(_request);
                return response.Content;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}