using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;

namespace app_prova_prismatec.Helpers
{
    public static class Utils
    {
        public static string _recuperarDirectorioArquivo()
        {
            return Path.Combine(ConfigurationSettings.AppSettings["CaminhoPasta"],
                string.Concat(ConfigurationSettings.AppSettings["NomeArquivo"],
                DateTime.Now.ToString(ConfigurationSettings.AppSettings["FormatoNomeArquivo"]),
                ConfigurationSettings.AppSettings["Extensao"]));
        }

        public static void CriarArquivo<T>(T obj,string path)
        {
            using (StreamWriter file = File.CreateText(path))
            {

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, obj);

            }
        }
    }
}
