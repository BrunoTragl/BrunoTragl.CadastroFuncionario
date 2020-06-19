namespace BrunoTragl.CadastroFuncionario.Business.Service.Configuration
{
    public static class APIConfigurations
    {
        public static string UrlFuncionario() => $"funcionario";
        public static string UrlFuncionario(int id) => $"funcionario/{id}";
        public static string UrlFuncionarios(int pageSize, int page) => $"funcionario?page_size={pageSize}&page={page}";
        public static string UrlHabilidade() => $"habilidade";
        public static string UrlHabilidade(int id) => $"habilidade/{id}";
        public static string UrlHabilidades(int funcionarioId, int pageSize, int page) => $"habilidade?funcionarioId={funcionarioId}&page_size={pageSize}&page={page}";
        public static string UrlHabilidadeUnico() => $"habilidadeunico";
        public static string UrlHabilidadeUnico(int id) => $"habilidadeunico/{id}";
    }
}
