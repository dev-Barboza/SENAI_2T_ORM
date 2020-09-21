using EntityFramework.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Interfaces
{
    public interface IProdutoRepository
    {
        List<Produto> Listar();
        Produto BuscarPorId(Guid id);
        Produto BiscarPorNome(string nome);
        void Adicionar(Produto produto);
        void Editar(Produto produto);
        void Remover(Guid id);
    }
}
