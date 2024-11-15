using Trabalho_3.Data;
using Trabalho_3.Models;

namespace Trabalho_3.Repositorio
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {

        private readonly BancoContext _bancoContext;

        public FornecedorRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public FornecedorModel ListarPorId(int id)
        {
            return _bancoContext.Fazenda2.FirstOrDefault(x => x.id == id);
        }

        public List<FornecedorModel> BuscarTodos()
        {
            return _bancoContext.Fazenda2.ToList();
        }

        public FornecedorModel Adicionar(FornecedorModel fornecedor)
        {
            _bancoContext.Fazenda2.Add(fornecedor);
            _bancoContext.SaveChanges();
            return fornecedor;
        }

        public FornecedorModel Atualizar(FornecedorModel fornecedor)
        {
            FornecedorModel fornecedorDB = ListarPorId(fornecedor.id);

            if (fornecedorDB == null) throw new System.Exception("Houve um erro na atualização do fornecedor!");

            fornecedorDB.CNPJ = fornecedor.CNPJ;
            fornecedorDB.Empresa = fornecedor.Empresa;
            fornecedorDB.Telefone = fornecedor.Telefone;

            _bancoContext.Fazenda2.Update(fornecedorDB);
            _bancoContext.SaveChanges();
            return fornecedorDB;
        }

        public bool Apagar(int id)
        {
            FornecedorModel fornecedorDB = ListarPorId(id);

            if (fornecedorDB == null) throw new System.Exception("Houve um erro na deleção do fornecedor!");

            _bancoContext.Fazenda2.Remove(fornecedorDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
