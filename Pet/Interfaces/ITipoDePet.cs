using Pet.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pet.Interfaces
{
    interface ITipoDePet
    {
        List<TipoDePet> ListarTodos();
        TipoDePet BuscarPorID(int Id);
        TipoDePet Cadastrar(TipoDePet e);
        TipoDePet Alterar(TipoDePet e, int id);
        TipoDePet Excluir(TipoDePet e, int id);
    }
}
