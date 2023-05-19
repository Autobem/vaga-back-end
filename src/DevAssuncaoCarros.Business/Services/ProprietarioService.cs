using DevAssuncaoCarros.Business.Interfaces;
using DevAssuncaoCarros.Business.Models;

namespace DevAssuncaoCarros.Business.Services
{
    public class ProprietarioService : IProprietarioService
    {
        private readonly IProprietarioRepository _propRepo;
        private readonly IEnderecoRepository _enderecoRepo;

        public ProprietarioService(IProprietarioRepository propRepo, IEnderecoRepository endereco)
        {
            _propRepo = propRepo;
            _enderecoRepo = endereco;
        }

        public async Task<bool> AddProprietario(Proprietario proprietario)
        {

            if (proprietario == null)
            {
                return false;
            }

            try
            {
                await _propRepo.Adicionar(proprietario);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return true;
        }

        public async Task<bool> AtualizarProprietario (Proprietario proprietario)
        {
            if (proprietario == null)
            {
                return false;
            }

            try
            {
                await _propRepo.Atualizar(proprietario);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return true;
        }

        public async Task<bool> RemoveProprietario(Guid id)
        {
            var buscarProp = await _propRepo.ObterPorId(id);
            if(buscarProp == null)
            {
                throw new ArgumentException("Nao encontrado o proprietario");
            }

            await _propRepo.Remover(id);

            return true;
        }


        public async Task AtualizarEndereco(Endereco endereco)
        {
            try
            {
                await _enderecoRepo.Atualizar(endereco);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Dispose()
        {
            _propRepo?.Dispose();
            _enderecoRepo?.Dispose();
        }


    }
}
