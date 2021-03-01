using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;

namespace app_prova_prismatec.Helpers
{
    public static class Utils
    {
        //Método que recupera o caminho do arquivo
        public static string RecuperarDirectorioArquivo()
        {
            return Path.Combine(ConfigurationSettings.AppSettings["CaminhoPasta"],
                string.Concat(ConfigurationSettings.AppSettings["NomeArquivo"],
                DateTime.Now.ToString(ConfigurationSettings.AppSettings["FormatoNomeArquivo"])));
        }

        //Método que criar o arquivo no formato json
        public static void CriarArquivoJson<T>(T obj,string path)
        {
            using (StreamWriter file = File.CreateText(string.Concat(path,".json")))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, obj);

            }
        }
    }
}
