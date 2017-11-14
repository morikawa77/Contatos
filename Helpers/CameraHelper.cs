using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Plugin.Media;

namespace Contatos.Helpers
{
    public static class CameraHelper
    {
        public static async Task<MediaFile> TirarFotoAsync(string nomeArquivo)
        {
            // Inicializar a câmera do dispositivo
            await CrossMedia.Current.Initialize();

            // Verifica se existe uma camera e esta preparada para tirar fotos
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await App.DialogoAlerta("Atenção", "Câmera não suportada", "Fechar");

                return null;
            }

            // Verifica se foi informado um nome para o arquivo
            if (string.IsNullOrWhiteSpace(nomeArquivo))
            {
                // Guid gera nome randomico
                nomeArquivo = Guid.NewGuid().ToString();
                nomeArquivo += ".jpg";
            }

            // Armazena a foto tirada
            var midia = new StoreCameraMediaOptions();

            // Salva no album de foto do dispositivo
            midia.SaveToAlbum = true;
            midia.CompressionQuality = 60;
            midia.PhotoSize = PhotoSize.Medium;
            midia.Name = nomeArquivo;

            // retorna o arquivo
            var foto = await CrossMedia.Current.TakePhotoAsync(midia);
            return foto;
        }

        public static async Task<MediaFile> EscolheFotoAsync()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await App.DialogoAlerta("Atenção", "Câmera não suportada", "Fechar");
                return null;
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Medium,

            });


            if (file == null)
                return null;

            //var foto = await CrossMedia.Current.PickPhotoAsync();
            //return foto;

            return file;
        }
    }
}
