using Pet.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet.Interfaces
{
    interface IRaca
    {
        List<Raca> ListarTodos();
        Raca BuscarPorID(int Id);
        Raca Cadastrar(Raca a);
        Raca Alterar(Raca a, int id);
        Raca Excluir(Raca a, int id);
    }
}
