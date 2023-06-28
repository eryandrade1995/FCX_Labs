using FCX_Labs.Models;

namespace FCX_Labs.Helper
{
    public interface ISessao
    {
        void CreateSession(User usuario);
        void ClearSession();
        User GetSession();
    }
}