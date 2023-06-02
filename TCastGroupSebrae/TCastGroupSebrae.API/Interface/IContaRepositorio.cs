using TCastGroupSebrae.API.Model;

namespace TCastGroupSebrae.API.Interface
{
    public interface IContaRepositorio
    {
        void Inserir(Conta conta);
        void Atualizar(Conta conta);
        Task<bool> Excluir(int id);
        Task<Conta> BuscaPorId(int id);

    }
}
