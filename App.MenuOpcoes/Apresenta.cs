using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading;

namespace AppEspiaSo
{
    [Activity(Theme = "@style/EspiaSo.Theme", MainLauncher = true, NoHistory = true)]
    public class Apresenta : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Apresentação em 4 segundos
            Thread.Sleep(1000);
           
            //Chamada do Menu da Aplicação
            StartActivity(typeof(MainActivity));
            

            // Finalizar o Splash
            Finish();


        }

       

    }
}