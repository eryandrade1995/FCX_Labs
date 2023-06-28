using FCX_Labs.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FCX_Labs.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public User GetSession()
        {
            string userSession = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(userSession)) return null;

            return JsonConvert.DeserializeObject<User>(userSession);
        }

        public void CreateSession(User user)
        {
            string val = JsonConvert.SerializeObject(user);

            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", val);
        }

        public void ClearSession()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}