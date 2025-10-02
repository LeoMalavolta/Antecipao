namespace Antecipacao.Domain.Cache
{
   public class CacheKeys
    {
        private const string PREFIXO_CACHE_KEY_EMPRESA = "Empresa:";

        public static string ObterCacheKeyEmpresas(Guid idEmpresa) => $"{PREFIXO_CACHE_KEY_EMPRESA}{idEmpresa}";
    }
}
