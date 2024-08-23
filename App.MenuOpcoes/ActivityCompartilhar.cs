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
using Java.Lang;
using Java.Interop;
using System.Collections;
using System.Xml;
using System.Drawing;
using System.IO;
using Android.Content.PM;
using System.Net;
using Android.Content.Res;

namespace AppEspiaSo
{
    [Activity(Label = "ActivityCompartilhar")]
    public class ActivityCompartilhar : Activity
    {

        public Button BotaoFacebook;
        public Button BotaoTwitter;
        public Button BotaoGoogle;
        public Button BotaoWhatsapp;

        [Export("btnHomeClicked")]
        public void btnHomeClicked_Click(View v)
        {

            // Limpar a Tabela de leis
            LeisRepositorio.DeletaLeis();

            //Sair da aplicação    
            this.Finish();

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //remove título desta Activity
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);                      

            // pegar o dado do link da lei selecionada
            string sLinkdaLei = Intent.GetStringExtra("MyLinkLei");

            // Abrir a View 

            //detectar o tamanho da tela em uso
            var metrics = Resources.DisplayMetrics;
            var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);


            if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeLarge)
            {
                // Toast.MakeText(this, "Large screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Compartilhar_1080);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeNormal)
            {
                // Toast.MakeText(this, "Normal screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Compartilhar);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeSmall)
            {
                // Toast.MakeText(this, "Small screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Compartilhar_800);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeXlarge)
            {
                //  Toast.MakeText(this, "XLarge screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Compartilhar_1080);
            }
            else
            {
                //  Toast.MakeText(this, "Screen size is neither large, normal or small", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Compartilhar_1080);
            }

            // Se for um Nexus 4 - Resolução 768 x 1280
            //if (widthInDp == 384 && heightInDp == 592)
            //{
            //    SetContentView(Resource.Layout.Compartilhar);

            //}

            //// Se for um Nexus 5 - Resolução 1080 x 1980
            //if (widthInDp == 360 && heightInDp == 592)
            //{
            //    SetContentView(Resource.Layout.Compartilhar_1080);
            //}

            //// Se for um Nexus S - Resolução 480 x 800
            //if (widthInDp == 329 && heightInDp == 501)
            //{
            //    SetContentView(Resource.Layout.Compartilhar_800);

            //}
            //else
            //{
            //    SetContentView(Resource.Layout.Compartilhar);
            //}

            //28/04/2017 13:19h
            // Botões na tela
            BotaoFacebook = (Button)FindViewById(Resource.Id.btnFace);
            BotaoTwitter = (Button)FindViewById(Resource.Id.btnTwitter);
            BotaoGoogle = (Button)FindViewById(Resource.Id.btnGoogle);
            BotaoWhatsapp = (Button)FindViewById(Resource.Id.btnWhatsapp);
            // Compartilhar no Facebook
            BotaoFacebook.Click += (sender, e) =>
            {
                string scompartilhar = "http://www.facebook.com/sharer.php?u=" + sLinkdaLei;

                // 31/05/2017 13:42h
                // Testar se o arquivo na WEB está acessível via WIFI
                try
                {
                    ////Tentar abrir a URL na Internet
                    //HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(scompartilhar);

                    //// Tempo de resposta para abrir o arquivo
                    //iNetRequest.Timeout = 9000;

                    //// Se abrir com sucesso
                    //WebResponse iNetResponse = iNetRequest.GetResponse();

                    //// Fecha o Console
                    //iNetResponse.Close();
                    
                    //Compartilhar no Facebook
                    // 02/05/2017 10:23h - Leo Metelys
                    var uri = Android.Net.Uri.Parse(scompartilhar);
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }

                catch (WebException ex)
                {
                    Android.Widget.Toast.MakeText(this, "Sem conexão com a Internet...", Android.Widget.ToastLength.Short).Show();
                }

             };

            //Compartilhar no Twitter
            BotaoTwitter.Click += (sender, e) =>
            {
                string scompartilhar = "http://twitter.com/home?status=APPALEAM Leis olhem só está lei: " + sLinkdaLei;

                // 31/05/2017 13:42h
                // Testar se o arquivo na WEB está acessível via WIFI
                try
                {
                    ////Tentar abrir a URL na Internet
                    //HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(scompartilhar);

                    //// Tempo de resposta para abrir o arquivo
                    //iNetRequest.Timeout = 9000;

                    //// Se abrir com sucesso
                    //WebResponse iNetResponse = iNetRequest.GetResponse();

                    //// Fecha o Console
                    //iNetResponse.Close();

                    //Compartilhar no Twitter
                    // 02/05/2017 10:23h - Leo Metelys
                    var uri = Android.Net.Uri.Parse(scompartilhar);
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }

                catch (WebException ex)
                {

                    Android.Widget.Toast.MakeText(this, "Sem conexão com a Internet...", Android.Widget.ToastLength.Short).Show();

                }
                
            };


            BotaoGoogle.Click += (sender, e) =>
            {

                string scompartilhar = "https://plus.google.com/share?url=" + sLinkdaLei;

                // 31/05/2017 13:42h
                // Testar se o arquivo na WEB está acessível via WIFI
                try
                {
                    //Tentar abrir a URL na Internet
                    //HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(scompartilhar);

                    //// Tempo de resposta para abrir o arquivo
                    //iNetRequest.Timeout = 9000;

                    //// Se abrir com sucesso
                    //WebResponse iNetResponse = iNetRequest.GetResponse();

                    //// Fecha o Console
                    //iNetResponse.Close();

                    //Compartilhar no Twitter
                    // 02/05/2017 10:23h - Leo Metelys
                    var uri = Android.Net.Uri.Parse(scompartilhar);
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }

                catch (WebException ex)
                {

                    Android.Widget.Toast.MakeText(this, "Sem conexão com a Internet...", Android.Widget.ToastLength.Short).Show();

                }

            };

            BotaoWhatsapp.Click += (sender, e) =>
            {

                string scompartilhar = "whatsapp://send?text=" + sLinkdaLei;

                // 31/05/2017 13:42h
                // Testar se o arquivo na WEB está acessível via WIFI
                try
                {
                    ////Tentar abrir a URL na Internet
                    //HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(scompartilhar);

                    //// Tempo de resposta para abrir o arquivo
                    //iNetRequest.Timeout = 9000;

                    //// Se abrir com sucesso
                    //WebResponse iNetResponse = iNetRequest.GetResponse();

                    //// Fecha o Console
                    //iNetResponse.Close();

                    //Compartilhar no Twitter
                    // 02/05/2017 10:23h - Leo Metelys
                    var uri = Android.Net.Uri.Parse(scompartilhar);
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                }

                catch (WebException ex)
                {

                    Android.Widget.Toast.MakeText(this, "Sem conexão com a Internet...", Android.Widget.ToastLength.Short).Show();

                }

                ////Compartilhar no Google+
                //// 02/05/2017 11:17h - Leo Metelys
                //var uri = Android.Net.Uri.Parse(scompartilhar);
                //var intent = new Intent(Intent.ActionView, uri);
                //StartActivity(intent);

            };

        }

        public override bool DispatchKeyEvent(KeyEvent e)
        {
            if (e.KeyCode == Keycode.Back)
            {
                this.Finish();
            }
            //return base.DispatchKeyEvent(e);
            return true;
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }


    }
}