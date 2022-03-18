using Presentation.Dao;
using Presentation.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Dal
{
    
    public class FornecedorDal
    {
        public List<FornecedorDto> ListaFornecedores(RequestFornecedorDto fornecedor)
        {
            using (var conn = new ContextSqlServer())
            {
                return conn.Fornecedor.Where(i => i.Nome.Contains(fornecedor.Nome)
                && i.Nome.Contains(fornecedor.Nome)
                && i.RazaoSocial.Contains(fornecedor.RazaoSocial)
                && i.CNPJ.Contains(fornecedor.CNPJ)
                && i.Segmento.Contains(fornecedor.Segmento)
                && i.Endereco.Contains(fornecedor.Endereco)
                && i.Telefone.Contains(fornecedor.Telefone)
                && i.Email.Contains(fornecedor.Email)).ToList();
            }
        }


        public FornecedorDto BuscaFornecedor(Int64 fornecedorId)
        {
            using (var conn = new ContextSqlServer())
            {
                return conn.Fornecedor.FirstOrDefault(i=> i.FornecedorId.Equals(fornecedorId));
            }
        }


        public FornecedorDto CriarFornecedor(RequestFornecedorDto fornecedor)
        {
            using (var conn = new ContextSqlServer())
            {
                var insert = new FornecedorDto();
                insert.Nome = fornecedor.Nome;
                insert.RazaoSocial = fornecedor.RazaoSocial;
                insert.CNPJ = fornecedor.CNPJ;
                insert.Segmento = fornecedor.Segmento;
                insert.Endereco = fornecedor.Endereco;
                insert.Telefone = fornecedor.Telefone;
                insert.Email = fornecedor.Email;

                conn.Fornecedor.Add(insert);
                conn.SaveChanges();

                return insert;
            }
        }

        public FornecedorDto AtualizarFornecedor(Int64 fornecedorId, RequestFornecedorDto fornecedor)
        {
            using (var conn = new ContextSqlServer())
            {
                var update = conn.Fornecedor.FirstOrDefault(i=> i.FornecedorId.Equals(fornecedorId));
                if(update != null)
                {
                    if(!string.IsNullOrEmpty(fornecedor.Nome))
                        update.Nome = fornecedor.Nome;

                    if (!string.IsNullOrEmpty(fornecedor.RazaoSocial))
                        update.RazaoSocial = fornecedor.RazaoSocial;
                   
                    if (!string.IsNullOrEmpty(fornecedor.CNPJ))
                        update.CNPJ = fornecedor.CNPJ;
                   
                    if (!string.IsNullOrEmpty(fornecedor.Segmento))
                        update.Segmento = fornecedor.Segmento;
                   
                    if (!string.IsNullOrEmpty(fornecedor.Endereco))
                        update.Endereco = fornecedor.Endereco;
                  
                    if (!string.IsNullOrEmpty(fornecedor.Telefone))
                        update.Telefone = fornecedor.Telefone;
                   
                    if (!string.IsNullOrEmpty(fornecedor.Email))
                        update.Email = fornecedor.Email;

                    conn.SaveChanges();

                    return update;
                }
               
                return null;
            }
        }

        public void DesabilitarFornecedor(Int64 fornecedorId)
        {
            using (var conn = new ContextSqlServer())
            {
                var delete = conn.Fornecedor.FirstOrDefault(i => i.FornecedorId.Equals(fornecedorId));
                if (delete != null)
                {
                    conn.Fornecedor.Remove(delete);

                    conn.SaveChanges();
                }
            }
        }
    }
}
