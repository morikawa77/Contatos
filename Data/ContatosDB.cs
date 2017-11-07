using System.Collections.Generic;
using System.Threading.Tasks;
using Contatos.Models;
using SQLite;
using Xamarin.Forms;

namespace Contatos.Data
{
    public class ContatosDB
    {
        readonly SQLiteAsyncConnection database;
        public ContatosDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Pessoa>().Wait();
            database.CreateTableAsync<Evento>().Wait();
            database.CreateTableAsync<Usuario>().Wait();
        }

        // listar todos os itens
        public Task<List<Pessoa>> GetPessoasAsync()
        {
            return database.Table<Pessoa>().ToListAsync();
        }

        public Task<List<Evento>> GetEventosAsync()
        {
            return database.Table<Evento>().ToListAsync();
        }

        public Task<Usuario> GetUsuariosAsync()
        {
            return database.Table<Usuario>().Where(i => i.Id == 1).FirstOrDefaultAsync();
        }


        // Query com SQL 
        /*
        public Task<List<Pessoa>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Pessoa>("SELECT * FROM [Pessoa] WHERE [CAMPO] = 0");
        }
        */

        // Query por id
        /*
        public Task<Pessoa> GetItemAsync(int id)
        {
            return database.Table<Pessoa>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }
        */

        // Create / Update
        public Task<int> SavePessoaAsync(Pessoa item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> SaveEventoAsync(Evento item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> SaveUsuarioAsync(Usuario item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }


        // Delete
        public Task<int> DeletePessoaAsync(Pessoa item)
        {
            return database.DeleteAsync(item);
        }

        public Task<int> DeleteEventoAsync(Evento item)
        {
            return database.DeleteAsync(item);
        }
    }
}