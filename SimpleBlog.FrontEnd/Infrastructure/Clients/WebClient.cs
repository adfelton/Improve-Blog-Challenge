using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleBlog.FrontEnd.Infrastructure 
{
    public class WebClient : IWebClient
    {
        #region "Props"
        
        public enum EnumEntityType 
        {
            posts = 1,
            comments = 2
        }

        public EnumEntityType EntityType { get; set; }

        public readonly HttpClient _httpClient;

        private readonly IOptions<AppSettings> _appSettings;

        #endregion

        #region "Methods"

        public WebClient(HttpClient httpClient, IOptions<AppSettings> appSettings) 
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
        }

        public async Task<string> GetData(string suffix = "") 
        {
            var domain = _appSettings.Value.APIUrl;
            var address =  domain + GetPathFromEntityType() + suffix;
            
            return await _httpClient.GetStringAsync(address);
        }

        private string GetPathFromEntityType()
        {
            switch(EntityType)
            {
                default:
                case EnumEntityType.posts:
                    return "api/posts";

                case EnumEntityType.comments:
                    return "api/comments?postId=";
            }
        }

        #endregion
    }
}