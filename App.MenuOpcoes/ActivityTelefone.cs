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
using System.IO;
using Android.Content.PM;
using Android.Graphics;
using Android.Views.Animations;
using Plugin.WifiInfo;
using System.Net;
using Android.Content.Res;
using RestSharp;

namespace AppEspiaSo
{
    [Activity(Label = " FONES ÚTEIS ", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActivityTelefone : Activity
    {
        public ArrayList lista;
        public string fone1 = "";
        public string fone2 = "";
        public string fone3 = "";
        public string fone4 = "";
        public string fone5 = "";
        public string fone6 = "";
        public string fone7 = "";
        public string fone8 = "";


        [Export("btnHomeClicked")]
        public void btnHomeClicked_Click(View v)
        {
                    
            //Fechar a tela atual
            this.Finish();
        }

        [Export("btnPoliciaClicked")]
        public void btnPoliciaClicked_Click(View v)
        {

            // 08/04/2017 17:51h Fazer uma chamada pelo telefone
            var uri = Android.Net.Uri.Parse("tel:"+ fone1);
            var intent = new Intent(Intent.ActionDial, uri);
            StartActivity(intent);

        }

        [Export("btnDireitoClicked")]
        public void btnDireitoClicked_Click(View v)
        {

            // 08/04/2017 17:51h Fazer uma chamada pelo telefone
            var uri = Android.Net.Uri.Parse("tel:" + fone2);
            var intent = new Intent(Intent.ActionDial, uri);
            StartActivity(intent);

        }

        [Export("btndenunciaClicked")]
        public void btndenunciaClicked_Click(View v)
        {

            // 08/04/2017 17:51h Fazer uma chamada pelo telefone
            var uri = Android.Net.Uri.Parse("tel:" + fone3);
            var intent = new Intent(Intent.ActionDial, uri);
            StartActivity(intent);

        }

        [Export("btnCivilClicked")]
        public void btnCivilClicked_Click(View v)
        {

            // 08/04/2017 17:51h Fazer uma chamada pelo telefone
            var uri = Android.Net.Uri.Parse("tel:"+ fone4);
            var intent = new Intent(Intent.ActionDial, uri);
            StartActivity(intent);

        }

        [Export("btnSamuClicked")]
        public void btnSamuClicked_Click(View v)
        {

            // 08/04/2017 17:51h Fazer uma chamada pelo telefone
            var uri = Android.Net.Uri.Parse("tel:"+fone5);
            var intent = new Intent(Intent.ActionDial, uri);
            StartActivity(intent);

        }

        [Export("btnBombeiroClicked")]
        public void btnBombeiroClicked_Click(View v)
        {

            // 08/04/2017 17:51h Fazer uma chamada pelo telefone
            var uri = Android.Net.Uri.Parse("tel:"+fone6);
            var intent = new Intent(Intent.ActionDial, uri);
            StartActivity(intent);

        }

        [Export("btnTransitoClicked")]
        public void btnTransitoClicked_Click(View v)
        {

            // 08/04/2017 17:51h Fazer uma chamada pelo telefone
            var uri = Android.Net.Uri.Parse("tel:"+fone7);
            var intent = new Intent(Intent.ActionDial, uri);
            StartActivity(intent);

        }

        [Export("btnDefesaCivilClicked")]
        public void btnDefesaCivilClicked_Click(View v)
        {
            // 08/04/2017 17:51h Fazer uma chamada pelo telefone
            var uri = Android.Net.Uri.Parse("tel:"+fone8);
            var intent = new Intent(Intent.ActionDial, uri);
            StartActivity(intent);

        }

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //detectar o tamanho da tela em uso
            var metrics = Resources.DisplayMetrics;
            var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

            //remove título desta Activity
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeLarge)
            {
                //Toast.MakeText(this, "Large screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Telefone_1080);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeNormal)
            {
                //Toast.MakeText(this, "Normal screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Telefone);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeSmall)
            {
               // Toast.MakeText(this, "Small screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Telefone_800);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeXlarge)
            {
                //Toast.MakeText(this, "XLarge screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Telefone_1080);
            }
            else
            {
               // Toast.MakeText(this, "Screen size is neither large, normal or small", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Telefone_1080);
            }

            var cliente = new RestClient("http://www.ale.am.gov.br/wp-content/uploads/2017/05/telefones_app.xml");
            var request = new RestRequest("/", Method.GET);
            request.AddHeader("Content-type", "application/json");
            cliente.ExecuteAsync(request, response =>
            {
                RunOnUiThread(delegate
                {
               
                    var responseXML = response.Content;

                    //30/05/2017 11:26h
                    // Abrir arquivo na rede
                    string sfonetel = "";
                    string snumerofone = "";
                    bool sNumero = false;
                    bool sFone = false;

                    string xmlStream = responseXML.ToString();
                    //Toast.MakeText(this, "reposta", ToastLength.Long);

                    // 20/06/2017 23:13h
                    //Ler XML como um texto e apresentar
                    lista = new ArrayList();
                    var list = new List<string>();
                    var listNew = new List<string>();
                    //int contaexclui = 0;

                    using (var streamReader = new StreamReader(xmlStream))
                    {
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            list.Add(line);
                        }

                    }


                });
            });


        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }
    }
}