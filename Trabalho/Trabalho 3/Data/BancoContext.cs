using Microsoft.EntityFrameworkCore;
using Trabalho_3.Models;

namespace Trabalho_3.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options){}
        public DbSet<FornecedorModel> Fazenda2 { get; set; }
        public DbSet<UsuarioModel> Usuarios {  get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}
