using System;
using System.Collections.Generic;

namespace AppEspiaSo
{
    class FavoritoRepositorio
    {
        public static List<Favorito> Favoritos { get; private set; }

        static FavoritoRepositorio()
        {
            Favoritos = new List<Favorito>();
        }

        public static void DeletaFavoritos()
        {
            Favoritos.Clear();
        }
        
        public static void AddFavoritos(int codigo, string sNome, string stipolei)
        {
            
            Favoritos.Add(new Favorito 
            {
                Id = codigo, 
                Nome = sNome,
                TipoLei = stipolei               
            });
        }
    }
}