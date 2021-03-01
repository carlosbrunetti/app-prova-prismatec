using Serilog;

namespace app_prova_prismatec.Helpers
{    
    public static class Logger
    {
        //Método que cria o Serialog
        public static void CriarLogger()
        {
            Log.Logger = new LoggerConfiguration()
              .WriteTo.Console()
              .CreateLogger();
        }

        //Método que imprime o log no console
        public static void ImprimirLog(string msg)
        {
            Log.Information(msg);
        }
    }
}
