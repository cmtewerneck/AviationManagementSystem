namespace AviationManagementApi.Business.Models.Validations
{
    public class FornecedorValidation : PessoaValidation<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(x => x.Endereco).SetValidator(new EnderecoValidation());
        }
    }
}
