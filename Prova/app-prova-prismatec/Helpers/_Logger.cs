using Serilog;

namespace app_prova_prismatec.Helpers
{
    public static class _Logger
    {
        public static void CriarLogger()
        {
            Log.Logger = new LoggerConfiguration()
              .WriteTo.Console()
              .CreateLogger();
        }

        public static void ImprimirLog(string msg)
        {
            Log.Information(msg);
        }
    }
}
