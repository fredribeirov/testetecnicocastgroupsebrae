using TCastGroupSebrae.API.Interface;
using TCastGroupSebrae.API.Model;

namespace TCastGroupSebrae.API.Repository
{
    public class ContaRepositorio : IContaRepositorio
    {
        readonly TCastGroupSebraeAPIContext _castGroupSebraeAPIContext;
        public ContaRepositorio(TCastGroupSebraeAPIContext castGroupSebraeAPIContext)
        {
            _castGroupSebraeAPIContext = castGroupSebraeAPIContext;
        }
        public Conta Atualizar(Conta conta)
        {
            throw new NotImplementedException();
        }

        public Conta BuscaPorId(int id)
        {
            return _castGroupSebraeAPIContext.Conta.Find(id);
           
        }

        public List<Conta> BuscaTodos()
        {
            return _castGroupSebraeAPIContext.Conta.ToList();
        }

        public Conta Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Conta Inserir(Conta conta)
        {
            throw new NotImplementedException();
        }
    }
}
