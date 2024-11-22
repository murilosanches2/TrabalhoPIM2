using Trabalho_3.Data;
using Trabalho_3.Models;

namespace Trabalho_3.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {

        private readonly BancoContext _bancoContext;

        public ProdutoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ProdutoModel ListarPorId(int id)
        {
            return _bancoContext.Produtos.FirstOrDefault(x => x.Id == id);
        }

        public List<ProdutoModel> BuscarTodos()
        {
            return _bancoContext.Produtos.ToList();
        }

        public ProdutoModel Adicionar(ProdutoModel produto)
        {
            produto.DataRegistro = DateTime.Now;
            _bancoContext.Produtos.Add(produto);
            _bancoContext.SaveChanges();
            return produto;
        }

        public ProdutoModel Atualizar(ProdutoModel produto)
        {
            ProdutoModel produtoDB = ListarPorId(produto.Id);

            if (produtoDB == null) throw new System.Exception("Houve um erro na atualização do produto!");

            produtoDB.Produto = produto.Produto;
            produtoDB.Quantidade = produto.Quantidade;
            produtoDB.Tipo = produto.Tipo;
            produtoDB.Total = produto.Total;
            produtoDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Produtos.Update(produtoDB);
            _bancoContext.SaveChanges();
            return produtoDB;
        }

        public bool Apagar(int id)
        {
            ProdutoModel produtoDB = ListarPorId(id);

            if (produtoDB == null) throw new System.Exception("Houve um erro na deleção do produto!");

            _bancoContext.Produtos.Remove(produtoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
