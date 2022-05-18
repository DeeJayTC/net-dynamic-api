using Microsoft.AspNetCore.Http;

namespace TCDev.APIGenerator.Data
{
    public class ApplicationDataService
    {
        public GenericDbContext GenericData {get;set;}
        public AuthDbContext AuthData { get; set; }
        public HttpContext Context { get; set; }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDataService(GenericDbContext genericData, AuthDbContext authData, IHttpContextAccessor contextAccessor)
        {
            GenericData = genericData;
            AuthData = authData;
            Context = contextAccessor.HttpContext;
            _httpContextAccessor = contextAccessor;
        }
    }
}
