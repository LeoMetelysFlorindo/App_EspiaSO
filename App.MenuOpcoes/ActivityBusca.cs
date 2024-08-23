// ****************************************************
// Data criação: 06/05/2017 21:00h
// Pesquisa de termos no APP ESPIASO
// Desenvolvedor: Leonardo Metelys
// ****************************************************
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
using Plugin.DeviceInfo;
using Android.Content.Res;

namespace AppEspiaSo
{
    [Activity(Label = " BUSCA ", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActivityBusca : Activity
    {

        bool eTelaBusca = false;
        public ArrayList lista;
        public ArrayAdapter adp1;
        public ListView lv1;
        SearchView sBusca;

        [Export("btnHomeClicked")]
        public void btnHomeClicked_Click(View v)
        {
            //Sair da aplicação    
            this.Finish();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Algoritimo a desenvolver: 09/04/2017 14:48h         
            var metrics = Resources.DisplayMetrics;
            var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

            //remove título desta Activity
            Window.RequestFeature(WindowFeatures.NoTitle);

            // PEGAR MODELO DO CELULAR E COLOCAR NA RESOLUÇÃO ESPECÍFICA
            // 08/05/2017 11:26h
            // DESENVOLVEDOR: LEO METELYS
            var platform = CrossDeviceInfo.Current.Platform;
            var versao = CrossDeviceInfo.Current.Version;
            var modelo = CrossDeviceInfo.Current.Model;

            string ModeloCelular = modelo.ToString();

            if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeLarge)
            {
               // Toast.MakeText(this, "Large screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Busca_1080);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeNormal)
            {
               // Toast.MakeText(this, "Normal screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Busca);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeSmall)
            {
               // Toast.MakeText(this, "Small screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Busca_800);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeXlarge)
            {
               // Toast.MakeText(this, "XLarge screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Busca_1080);
            }
            else
            {
              //  Toast.MakeText(this, "Screen size is neither large, normal or small", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Busca_1080);
            }

            //setar apropriadamente qual layout apresentar na tela
            //base.OnCreate(bundle);
            // Se for um Nexus 4 - Resolução 768 x 1280 - Galaxy J3
            //if (widthInDp == 384 && heightInDp == 592)
            //{
            //    SetContentView(Resource.Layout.Busca);
            //}

            //// Se for um Nexus 5 - Resolução 1080 x 1980 Motorola G4 5,5 polegadas
            //if (widthInDp == 360 && heightInDp == 592)
            //{
            //    SetContentView(Resource.Layout.Busca_1080);
            //}

            //// Para o Galaxy J3
            //if (widthInDp == 360 && heightInDp == 640)
            //{
            //    SetContentView(Resource.Layout.Busca);
            //}

            //// Se for um Nexus S - Resolução 480 x 800
            //if (widthInDp == 329 && heightInDp == 501)
            //{
            //    SetContentView(Resource.Layout.Busca_800);
            //}

            //// NOTES 5
            //if (widthInDp == 411 && heightInDp == 731)
            //{
            //    SetContentView(Resource.Layout.Main_1080);
            //}


            //// Definindo o que abrir pelos modelos dos celulares
            //if (ModeloCelular == "Nexus 4 (KitKat)")
            //{
            //    SetContentView(Resource.Layout.Busca);
            //}

            //// SAMSUNG DUOS
            //if (ModeloCelular == "SM-G530BT")
            //{
            //    SetContentView(Resource.Layout.MostraLei);
            //}

            //// GALAXY J3
            //if (ModeloCelular == "SM-J320M")
            //{
            //    SetContentView(Resource.Layout.Busca);
            //}

            //// ZENFONE 3 5,5"
            //if (ModeloCelular == "ASUS_Z012DC")
            //{
            //    SetContentView(Resource.Layout.Busca_1080);
            //}

            sBusca = FindViewById<SearchView>(Resource.Id.svw1);
            lv1 = FindViewById<ListView>(Resource.Id.lvw1);
            AdicionarDados();

            adp1 = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, lista);
            lv1.Adapter = adp1;
            sBusca.QueryTextChange += sBusca_QueryTextChange;
            lv1.ItemClick += Lv1_ItemClick;

        }

        private void sBusca_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            adp1.Filter.InvokeFilter(e.NewText);
        }

        private void Lv1_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Ativa a seleção da busca realizada
            string sSelecao = adp1.GetItem(e.Position).ToString();

            if (sSelecao == "Compras")
            {
                eTelaBusca = true;
                var atividadeFavoritos = new Intent(this, typeof(ActivityCompras));
                StartActivity(atividadeFavoritos);
            }

            if (sSelecao == "Lazer")
            {
                eTelaBusca = true;
                var atividadeFavoritos = new Intent(this, typeof(ActivityLazer));
                StartActivity(atividadeFavoritos);
            }

            if (sSelecao == "Leis de Compras")
            {
                eTelaBusca = true;
                var atividadeFavoritos = new Intent(this, typeof(ActivityCompras));
                StartActivity(atividadeFavoritos);
            }

            if (sSelecao == "Leis de Lazer")
            {
                eTelaBusca = true;
                var atividadeFavoritos = new Intent(this, typeof(ActivityLazer));
                StartActivity(atividadeFavoritos);
            }

            if (sSelecao == "Leis de Saúde")
            {
                eTelaBusca = true;
                var atividadeFavoritos = new Intent(this, typeof(ActivitySaude));
                StartActivity(atividadeFavoritos);
            }

            if (sSelecao == "Leis de Serviço")
            {
                eTelaBusca = true;
                var atividadeFavoritos = new Intent(this, typeof(ActivityServico));
                StartActivity(atividadeFavoritos);
            }

            if (sSelecao == "Ouvidoria")
            {
                eTelaBusca = true;
                var atividadeFavoritos = new Intent(this, typeof(ActivityOuvidoria));
                StartActivity(atividadeFavoritos);
            }

            if (sSelecao == "Saúde")
            {
                eTelaBusca = true;
                var atividadeFavoritos = new Intent(this, typeof(ActivitySaude));
                StartActivity(atividadeFavoritos);
            }

            if (sSelecao == "Serviço")
            {
                eTelaBusca = true;
                var atividadeFavoritos = new Intent(this, typeof(ActivityServico));
                StartActivity(atividadeFavoritos);
            }

            if (sSelecao == "Telefones")
            {
                eTelaBusca = true;
                var atividadeFavoritos = new Intent(this, typeof(ActivityTelefone));
                StartActivity(atividadeFavoritos);
            }


            if (sSelecao == "Direitos Humanos")
            {
                eTelaBusca = true;
                // 08/04/2017 17:51h Fazer uma chamada pelo telefone
                var uri = Android.Net.Uri.Parse("tel:100");
                var intent = new Intent(Intent.ActionDial, uri);
                StartActivity(intent);
            }

            if (sSelecao == "Disque Denúncia")
            {
                eTelaBusca = true;
                // 08/04/2017 17:51h Fazer uma chamada pelo telefone
                var uri = Android.Net.Uri.Parse("tel:181");
                var intent = new Intent(Intent.ActionDial, uri);
                StartActivity(intent);
            }

            if (sSelecao == "Policia Civil")
            {
                eTelaBusca = true;
                // 08/04/2017 17:51h Fazer uma chamada pelo telefone
                var uri = Android.Net.Uri.Parse("tel:190");
                var intent = new Intent(Intent.ActionDial, uri);
                StartActivity(intent);
            }

            if (sSelecao == "Policia Militar")
            {
                eTelaBusca = true;
                // 08/04/2017 17:51h Fazer uma chamada pelo telefone
                var uri = Android.Net.Uri.Parse("tel:191");
                var intent = new Intent(Intent.ActionDial, uri);
                StartActivity(intent);
            }

            if (sSelecao == "Samu")
            {
                eTelaBusca = true;
                // 08/04/2017 17:51h Fazer uma chamada pelo telefone
                var uri = Android.Net.Uri.Parse("tel:192");
                var intent = new Intent(Intent.ActionDial, uri);
                StartActivity(intent);
            }

            if (sSelecao == "Bombeiros")
            {
                eTelaBusca = true;
                // 08/04/2017 17:51h Fazer uma chamada pelo telefone
                var uri = Android.Net.Uri.Parse("tel:193");
                var intent = new Intent(Intent.ActionDial, uri);
                StartActivity(intent);
            }

            if (sSelecao == "Trânsito")
            {
                eTelaBusca = true;
                // 08/04/2017 17:51h Fazer uma chamada pelo telefone
                var uri = Android.Net.Uri.Parse("tel:194");
                var intent = new Intent(Intent.ActionDial, uri);
                StartActivity(intent);
            }

            if (sSelecao == "Defesa Civil")
            {
                eTelaBusca = true;
                // 08/04/2017 17:51h Fazer uma chamada pelo telefone
                var uri = Android.Net.Uri.Parse("tel:199");
                var intent = new Intent(Intent.ActionDial, uri);
                StartActivity(intent);
            }

            if (sSelecao == "Conheça a ALEAM")
            {
                // SOBRE A ALEAM
                var atividadeConheca = new Intent(this, typeof(ActivityConheca));
                StartActivity(atividadeConheca);
            }

            if (sSelecao == "Sobre")
            {
                // SOBRE O APP                 
                var atividadeConhecaAleam = new Intent(this, typeof(ActivityConhecaaALEAM));
                StartActivity(atividadeConhecaAleam);
            }

            // Toast.MakeText(this, adp1.GetItem(e.Position).ToString(), ToastLength.Short).Show();
        }

        private void AdicionarDados()
        {
            lista = new ArrayList();

            lista.Add("Bombeiros");
            lista.Add("Compras");
            lista.Add("Conheça a ALEAM");
            lista.Add("Defesa Civil");
            lista.Add("Direitos Humanos");
            lista.Add("Disque Denúncia");
            lista.Add("Lazer");
            lista.Add("Leis de Compras");
            lista.Add("Leis de Lazer");
            lista.Add("Leis de Saúde");
            lista.Add("Leis de Serviço");
            lista.Add("Ouvidoria");
            lista.Add("Policia Civil");
            lista.Add("Policia Militar");
            lista.Add("Samu");
            lista.Add("Saúde");
            lista.Add("Serviço");
            lista.Add("Sobre");
            lista.Add("Telefones");
            lista.Add("Trânsito");
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }

        public override bool DispatchKeyEvent(KeyEvent e)
        {
            if (e.KeyCode == Keycode.Back)
            {
                if (eTelaBusca == true)
                {
                    // Limpar a Tabela de leis
                    LeisRepositorio.DeletaLeis();
                    this.Finish();
                    eTelaBusca = false;

                }
                else
                {
                    // Limpar a Tabela de leis
                    LeisRepositorio.DeletaLeis();
                    this.Finish();
                }

            }
            //return base.DispatchKeyEvent(e);
            return true;
        }
    }
}