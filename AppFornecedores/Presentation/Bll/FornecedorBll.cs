using Presentation.Dal;
using Presentation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Bll
{
    public class FornecedorBll
    {

        public Dictionary<int, object> ListaFornecedores(string nome, string razaoSocial, string cnpj, string segmento, string endereco, string telefone, string email)
        {
            try
            {                
                return new Dictionary<int, object> { { 200, new FornecedorDal().ListaFornecedores(new RequestFornecedorDto {
                    Nome =nome??"",
                    RazaoSocial=razaoSocial??"",
                    CNPJ=cnpj??"",
                    Segmento=segmento??"",
                    Endereco=endereco??"",
                    Telefone=telefone??"",
                    Email=email??""
                }) } };
            }
            catch (Exception ex)
            {
                return new Dictionary<int, object> { { 400, ex.Message } };
            }
        }


        public Dictionary<int, object> BuscaFornecedor(string fornecedorId)
        {
            try
            {
                if(Int64.TryParse(fornecedorId, out Int64 id))
                {
                    return new Dictionary<int, object> { { 200, new FornecedorDal().BuscaFornecedor(id) } };
                }
                return new Dictionary<int, object> { { 400, "FornecedorId não é válido!" } };
            }
            catch (Exception ex)
            {
                return new Dictionary<int, object> { { 400, ex.Message } };
            }
        }


        public Dictionary<int, object> CriarFornecedor(RequestFornecedorDto fornecedor)
        {
            try
            {
                return new Dictionary<int, object> { { 200, new FornecedorDal().CriarFornecedor(fornecedor) } };
            }
            catch (Exception ex)
            {
                return new Dictionary<int, object> { { 400, ex.Message } };
            }
        }

        public Dictionary<int, object> AtualizarFornecedor(string fornecedorId, RequestFornecedorDto fornecedor)
        {
            try
            {
                if (Int64.TryParse(fornecedorId, out Int64 id))
                {
                    return new Dictionary<int, object> { { 200, new FornecedorDal().AtualizarFornecedor(id, fornecedor) } };
                }
                return new Dictionary<int, object> { { 400, "FornecedorId não é válido!" } };
            }
            catch (Exception ex)
            {
                return new Dictionary<int, object> { { 400, ex.Message } };
            }
        }

        public Dictionary<int, object> DesabilitarFornecedor(string fornecedorId)
        {
            try
            {
                if (Int64.TryParse(fornecedorId, out Int64 id))
                {
                    new FornecedorDal().DesabilitarFornecedor(id);
                    return new Dictionary<int, object> { { 200, "Fornecedor removido com sucesso!" } };
                }
                return new Dictionary<int, object> { { 400, "FornecedorId não é válido!" } };
            }
            catch (Exception ex)
            {
                return new Dictionary<int, object> { { 400, ex.Message } };
            }
        }
    }
}
