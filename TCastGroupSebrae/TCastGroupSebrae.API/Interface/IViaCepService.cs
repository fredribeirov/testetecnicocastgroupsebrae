using TCastGroupSebrae.API.Model;

namespace TCastGroupSebrae.API.Interface
{
    public interface IViaCepService
    {
        Task<ViaCep> BuscaCep(string cep);
    }
}
