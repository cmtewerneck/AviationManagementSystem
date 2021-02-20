using System.Threading.Tasks;
using AviationManagementApi.Business.Models;

namespace AviationManagementApi.Business.Interfaces
{
    public interface IFornecedorServices : IPessoaServices<Fornecedor>
    {
        Task AtualizarEndereco(Endereco endereco);
    }
}
