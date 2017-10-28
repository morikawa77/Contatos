using System.IO;
using System.Threading.Tasks;

namespace Contatos.Pages
{
    public interface IPicturePicker
    {
        Task<Stream> GetImageStreamAsync();
    }
}