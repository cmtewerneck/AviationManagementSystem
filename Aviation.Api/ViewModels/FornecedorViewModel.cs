using System.Collections.Generic;

namespace AviationManagementApi.Api.ViewModels
{
    public class FornecedorViewModel : PessoaViewModel
    {
        public EnderecoViewModel Endereco { get; set; }
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
