using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DbrainApi
{
    /// <summary>
    /// Класс для работы с DBrain API.
    /// </summary>
    public class DbrainApi : IDbrainApi
    {
        private readonly string _token;
        private readonly string _baseUrl;
        private HttpClient _httpClient;

        public DbrainApi(string token, string baseUrl = "https://latest.dbrain.io", int timeoutSec = 300)
        {
            _token = token;
            _baseUrl = baseUrl;
            _httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(timeoutSec)
            };
        }

        /// <inheritdoc/>
        public string Classify(byte[] passData, string fileExtension = ".jpg")
        {
            try
            {
                var url = $"{_baseUrl}/classify?token={_token}&return_crops=false";
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), url))
                {
                    request.Headers.TryAddWithoutValidation("accept", "application/json");
                    var multipartContent = new MultipartFormDataContent();
                    var file1 = new ByteArrayContent(passData);
                    file1.Headers.Add("Content-Type", "image/jpeg");
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + fileExtension;
                    multipartContent.Add(file1, "image", fileName);
                    request.Content = multipartContent;

                    var response = _httpClient.SendAsync(request).GetAwaiter().GetResult();
                    return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {
                return "{\"Message\":" + $"{ex.Message} {ex.InnerException?.Message}" + "}";
            }
        }

        /// <inheritdoc/>
        public async Task<string> ClassifyAsync(byte[] passData, string fileExtension = ".jpg")
        {
            try
            {
                var url = $"{_baseUrl}/classify?token={_token}&return_crops=false";
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), url))
                {
                    request.Headers.TryAddWithoutValidation("accept", "application/json");

                    var multipartContent = new MultipartFormDataContent();
                    var file1 = new ByteArrayContent(passData);
                    file1.Headers.Add("Content-Type", "image/jpeg");
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + fileExtension;
                    multipartContent.Add(file1, "image", fileName);
                    request.Content = multipartContent;

                    var response = await _httpClient.SendAsync(request);
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return "{\"Message\":\"" + $"{ex.Message} {ex.InnerException?.Message}" + "\"}";
            }
        }

        /// <inheritdoc/>
        public string Recognize(byte[] passData, bool async = false, bool hands = false, bool handsAsync = false, string fileExtension = ".jpg")
        {
            try
            {
                var url = $"{_baseUrl}/recognize?token={_token}&return_crops=false" +
                            $"&async={async.ToString().ToLower()}" +
                            $"&with_hitl={hands.ToString().ToLower()}" +
                            $"&hitl_async={handsAsync.ToString().ToLower()}";
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), url))
                {
                    request.Headers.TryAddWithoutValidation("accept", "application/json");

                    var multipartContent = new MultipartFormDataContent();
                    var file1 = new ByteArrayContent(passData);
                    file1.Headers.Add("Content-Type", "image/jpeg");
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + fileExtension;
                    multipartContent.Add(file1, "image", fileName);
                    request.Content = multipartContent;

                    var response = _httpClient.SendAsync(request).GetAwaiter().GetResult();
                    return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {
                return "{\"Message\":\"" + $"{ex.Message} {ex.InnerException?.Message}" + "\"}";
            }
        }

        /// <inheritdoc/>
        public async Task<string> RecognizeAsync(byte[] passData, bool async = false, bool hands = false, bool handsAsync = false, string fileExtension = ".jpg")
        {
            try
            {
                var url = $"{_baseUrl}/recognize?token={_token}&return_crops=false" +
                            $"&async={async.ToString().ToLower()}" +
                            $"&with_hitl={hands.ToString().ToLower()}" +
                            $"&hitl_async={handsAsync.ToString().ToLower()}";
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), url))
                {
                    request.Headers.TryAddWithoutValidation("accept", "application/json");

                    var multipartContent = new MultipartFormDataContent();
                    var file1 = new ByteArrayContent(passData);
                    file1.Headers.Add("Content-Type", "image/jpeg");
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + fileExtension;
                    multipartContent.Add(file1, "image", fileName);
                    request.Content = multipartContent;

                    var response = await _httpClient.SendAsync(request);
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return "{\"Message\":\"" + $"{ex.Message} {ex.InnerException?.Message}" + "\"}";
            }
        }

        /// <inheritdoc/>
        public async Task<string> ResultAsync(string taskId)
        {
            try
            {
                var url = $"{_baseUrl}/result/{taskId}?return_crops=false&token={_token}";                
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), url))
                {
                    request.Headers.TryAddWithoutValidation("accept", "application/json");

                    var response = await _httpClient.SendAsync(request);
                    return await response.Content.ReadAsStringAsync();
                }                
            }
            catch (Exception ex)
            {
                return "{\"Message\":\"" + $"{ex.Message} {ex.InnerException?.Message}" + "\"}";
            }
        }
    }
}
