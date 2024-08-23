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
using Java.Interop;
using Android.Content.PM;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Plugin.DeviceInfo;
using Android.Content.Res;

namespace AppEspiaSo
{
    [Activity(Label = " OUVIDORIA ALEAM ", ScreenOrientation = ScreenOrientation.Portrait)]

    public class ActivityOuvidoria : Activity
    {
        // 03/05/2017  Definição do botão para enviar e-mail        
        // By Leonardo Metelys

        public Button BotaoEnviar;

        [Export("btnHomeClicked")]
        public void btnHomeClicked_Click(View v)
        {
            this.Finish();
        }


        [Export("TelOuvidoriaClicked")]
        public void TelOuvidoriaClicked_Click(View v)
        {
            // 08/04/2017 17:51h Fazer uma chamada pelo telefone
            var uri = Android.Net.Uri.Parse("tel:9231834630");
            var intent = new Intent(Intent.ActionDial, uri);
            StartActivity(intent);

        }

        [Export("TelOuvidoria2Clicked")]
        public void TelOuvidoria2Clicked_Click(View v)
        {

            // Chamar a tela de Lazer
            // var atividadeLazer = new Intent(this, typeof(MainActivity));
            // StartActivity(atividadeLazer);
            //this.CloseContextMenu();

            // 08/04/2017 17:51h Fazer uma chamada pelo telefone
            var uri = Android.Net.Uri.Parse("tel:9231834565");
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

            // PEGAR MODELO DO CELULAR E COLOCAR NA RESOLUÇÃO ESPECÍFICA
            // 08/05/2017 11:26h
            // DESENVOLVEDOR: LEO METELYS
            var platform = CrossDeviceInfo.Current.Platform;
            var versao = CrossDeviceInfo.Current.Version;
            var modelo = CrossDeviceInfo.Current.Model;

            string ModeloCelular = modelo.ToString();

            base.OnCreate(savedInstanceState);

            //// Se for um Nexus 4 - Resolução 768 x 1280 - Galaxy J3
            //if (widthInDp == 384 && heightInDp == 592)
            //{
            //    SetContentView(Resource.Layout.Ouvidoria);
            //}

            //// Se for um Nexus 5 - Resolução 1080 x 1980 Motorola G4 5,5 polegadas
            //if (widthInDp == 360 && heightInDp == 592)
            //{
            //    SetContentView(Resource.Layout.Ouvidora_1080);
            //}

            //// Para o Zenfone 3, do Sandro Mourão
            //if (widthInDp == 360 && heightInDp == 640)
            //{
            //    SetContentView(Resource.Layout.Ouvidoria);
            //}

            //// Se for um Nexus S - Resolução 480 x 800
            //if (widthInDp == 329 && heightInDp == 501)
            //{
            //    SetContentView(Resource.Layout.Ouvidoria_800);
            //}

            // NOTES 5
            //if (widthInDp == 411 && heightInDp == 731)
            //{
            //    SetContentView(Resource.Layout.Ouvidora_1080);
            //}

            //// Definindo o que abrir pelos modelos dos celulares
            //if (ModeloCelular == "Nexus 4 (KitKat)")
            //{
            //    SetContentView(Resource.Layout.Ouvidoria);
            //}

            //// SAMSUNG DUOS
            //if (ModeloCelular == "SM-G530BT")
            //{
            //    SetContentView(Resource.Layout.MostraLei);
            //}

            //// GALAXY J3
            //if (ModeloCelular == "SM-J320M")
            //{
            //    SetContentView(Resource.Layout.Ouvidoria);
            //}

            //// ZENFONE 3 5,5"
            //if (ModeloCelular == "ASUS_Z012DC")
            //{
            //    SetContentView(Resource.Layout.Ouvidora_1080);
            //}

            if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeLarge)
            {
                //  Toast.MakeText(this, "Large screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Ouvidora_1080);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeNormal)
            {
                //   Toast.MakeText(this, "Normal screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Ouvidoria);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeSmall)
            {
                // Toast.MakeText(this, "Small screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Ouvidoria_800);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeXlarge)
            {
                Toast.MakeText(this, "XLarge screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Ouvidora_1080);
            }
            else
            {
                //Toast.MakeText(this, "Screen size is neither large, normal or small", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Ouvidora_1080);
            }

            Button btnEnviar = (Button)FindViewById(Resource.Id.BtnEnviar);
            btnEnviar.RequestFocus();

            var TxtNome = FindViewById<TextView>(Resource.Id.EdtNome);
            var TxtEmail = FindViewById<TextView>(Resource.Id.EdtEmail);
            var TxtMensagem = FindViewById<TextView>(Resource.Id.EdtMensagem);

            var TxtCorEmail = FindViewById<TextView>(Resource.Id.txtViewEmail);
            var TxtCorFone = FindViewById<TextView>(Resource.Id.textViewFone);
            var TxtCorCarta = FindViewById<TextView>(Resource.Id.textViewCarta);

            // Põe a cor do texto em amarelo
            TxtCorEmail.SetTextColor(Android.Graphics.Color.Yellow);
            TxtCorFone.SetTextColor(Android.Graphics.Color.Yellow);
            TxtCorCarta.SetTextColor(Android.Graphics.Color.Yellow);

            BotaoEnviar = (Button)FindViewById(Resource.Id.BtnEnviar);

            // 02/05/2017 20:09h
            // Enviar e-mail para a Ouvidoria da ALE-AM
            BotaoEnviar.Click += (sender, e) =>
            {
                try
                {
                    string sCorpoEmail = "Mensagem enviada por " + TxtNome.Text + "." + "\r\n" + "E-mail: " + TxtEmail.Text + "." + "\r\n" + "Mensagem: " + TxtMensagem.Text;
                    string sAssunto = "APP LEIS ALEAM - MENSAGEM ENVIADA PELO APLICATIVO DE LEIS ANDROID";

                    var emailIntent = new Intent(Android.Content.Intent.ActionSend);
                    emailIntent.PutExtra(Android.Content.Intent.ExtraEmail, new[] { "ouvidoria@aleam.gov.br" });
                    //emailIntent.PutExtra(Android.Content.Intent.ExtraCc, new[] { "gerencia.aplicativos@gmail.com" });
                    emailIntent.PutExtra(Android.Content.Intent.ExtraSubject, sAssunto);
                    emailIntent.SetType("text/plain");
                    emailIntent.PutExtra(Android.Content.Intent.ExtraText, sCorpoEmail);
                    StartActivity(Intent.CreateChooser(emailIntent, "Enviar e-mail"));

                    TxtNome.Text = "";
                    TxtEmail.Text = "";
                    TxtMensagem.Text = "";
                    Toast.MakeText(Application.Context, "E-mail enviado com sucesso!", ToastLength.Long);

                }
                catch
                {
                    Toast.MakeText(Application.Context, "Erro no envio do E-mail!!", ToastLength.Long);
                }

            };

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
                // Limpar a Tabela de leis
                LeisRepositorio.DeletaLeis();
                this.Finish();

            }
            //return base.DispatchKeyEvent(e);
            return true;
        }

    }
}