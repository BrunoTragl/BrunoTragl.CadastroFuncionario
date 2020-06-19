using BrunoTragl.CadastroFuncionario.Domain.Model;

namespace BrunoTragl.CadastroFuncionario.Presentation.WebAPI.Helpers
{
    public static class HabilidadeUnicoHelpers
    {
        public static bool RequestValido(HabilidadeUnico habilidade, out string campo)
        {
            campo = "Habilidade";
            if (string.IsNullOrEmpty(Helper.BuscarValorCampo(habilidade, campo)))
                return false;

            return true; 
        }
    }
}