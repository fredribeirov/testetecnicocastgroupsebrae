using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
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
        public async void Atualizar(Conta conta)
        {
            _castGroupSebraeAPIContext.Entry(conta).State = EntityState.Modified;
            _castGroupSebraeAPIContext.SaveChangesAsync();
        }

        public async Task<Conta> BuscaPorId(int id)
        {
            return await _castGroupSebraeAPIContext.Conta.FindAsync(id);
           
        }
 

        public async Task<bool> Excluir(int id)
        {
            var conta = _castGroupSebraeAPIContext.Conta.Find(id);
            if(conta != null)
            {
                _castGroupSebraeAPIContext.Conta.Remove(conta);
                _castGroupSebraeAPIContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async void Inserir(Conta conta)
        {
            _castGroupSebraeAPIContext.Conta.Add(conta);
            await _castGroupSebraeAPIContext.SaveChangesAsync();
             
        }
    }
}
