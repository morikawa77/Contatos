using System;
using System.Collections.ObjectModel;
using System.Linq;
using Contatos.Models;

namespace Contatos.ViewModels
{
    public class PessoaViewModelMem
    {
        public PessoaViewModelMem()
        {
        }

        public ObservableCollection<Pessoa> Lista { get; set; }

        public void Salvar(Pessoa item) {
            // Se o id for 0, entao é um novo registro
            if (item.Id == 0) {
                item.Id = DateTime.Now.Minute;
                Lista.Add(item); 
            } else {
                var existente = Lista.Where(r => r.Id == item.Id).FirstOrDefault();

                if (existente != null) {
                    //Remover e acrescentar
                    Lista.Remove(existente);
                    Lista.Add(item);
                }
            }
        }
    }
}
