using System;
using System.Collections.Generic;

namespace AppEspiaSo
{
    public class LeisRepositorio
    {
        public static List<Lei> Leis { get; private set; }

        static LeisRepositorio()
        {
            Leis = new List<Lei>();

        }

        public static void DeletaLeis()
        {   
            Leis.Clear();
        }
        
        public static void AddLeis(int codigo, string NumeroLei, string NomeLei)
        {
           
            Leis.Add(new Lei
            {
                Id = codigo,
                NumeroLei = NumeroLei,
                NomeLei = NomeLei
            });
        }



    }
}