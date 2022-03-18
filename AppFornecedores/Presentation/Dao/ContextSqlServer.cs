using Presentation.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Dao
{
    public class ContextSqlServer : DbContext
    {
        public ContextSqlServer() : base("Data Source=(local);Initial Catalog=Fornecedores;Integrated Security=True")
        {
        }



        public DbSet<FornecedorDto> Fornecedor { get; set; }
       
    }
}
