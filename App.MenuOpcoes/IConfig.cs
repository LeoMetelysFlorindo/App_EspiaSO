using SQLite.Net.Interop;

namespace AppEspiaSo
{
    public interface IConfig
    {
        string DiretorioSQLite { get; }
        ISQLitePlatform Plataforma { get; }
    }
}