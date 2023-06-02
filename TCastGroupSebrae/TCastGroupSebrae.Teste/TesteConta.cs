using TCastGroupSebrae.API.Interface;
using TCastGroupSebrae.API.Model;
using TCastGroupSebrae.API.Repository;

namespace TCastGroupSebrae.Teste
{
    public class TesteConta
    {
        private IContaRepositorio _contaRepositorio;
        [SetUp]
        public void Setup()
        {
            _contaRepositorio = new ContaRepositorio(new TCastGroupSebraeAPIContext( new Microsoft.EntityFrameworkCore.DbContextOptions<TCastGroupSebraeAPIContext>()));
        }

        [Test]
        public void RetornaVerdadeiroSeInserirCorreto()
        {
            var conta = new Conta()
            {
                Id = 1,
                Nome = "Nome Teste",
                Descricao = "Descricao Teste"
            };
            _contaRepositorio.Inserir(conta);
            var atual = _contaRepositorio.BuscaPorId(conta.Id);
            Assert.IsNotNull(atual);
          
        }
    }
}