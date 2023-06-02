using TCastGroupSebrae.API.Model;

namespace TCastGroupSebrae.API.Interface
{
    public interface IContaRepositorio
    {
        Conta Inserir(Conta conta);
        Conta Atualizar(Conta conta);
        Conta Excluir(int id);       
        Conta BuscaPorId(int id);

    }
}
