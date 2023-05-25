namespace ChaveAutenticidadeTjRs.Services.Interfaces
{
    public interface IValidacao
    {
        List<string> ValidarChavesList(List<string>chavesAutenticidade);
    

        List<string> ValidarResponse(string chave);
    }
}