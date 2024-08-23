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
using System.Collections;
using Java.Interop;
using Android.Content.PM;
using System.Xml;
using System.IO;
using Java.Lang;
using Android.Content.Res;

namespace AppEspiaSo
{
    [Activity(Label = " COMPRAS ", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActivityCompras : Activity
    {

        string sNome = "";
        string sDesc = "";
        int Posicao;

        [Export("btnHomeClicked")]
        public void btnHomeClicked_Click(View v)
        {

            // Chamar a tela de Lazer
            // var atividadeLazer = new Intent(this, typeof(MainActivity));
            // StartActivity(atividadeLazer);
            //this.CloseContextMenu();

            // Limpar a Tabela de leis
            LeisRepositorio.DeletaLeis();

            this.Finish();

        }

        // Declarações das variáveis da lista
        public ArrayList lista;
        public ArrayAdapter adp1;
        public ListView lv1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
                     

            //Algoritimo a desenvolver: 09/04/2017 14:48h

            //detectar o tamanho da tela em uso
            var metrics = Resources.DisplayMetrics;
            var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

            //remove título desta Activity
            Window.RequestFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeLarge)
            {
                // Toast.MakeText(this, "Large screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Compras_1080);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeNormal)
            {
                // Toast.MakeText(this, "Normal screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Compras);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeSmall)
            {
                // Toast.MakeText(this, "Small screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Compras_800);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeXlarge)
            {
                // Toast.MakeText(this, "XLarge screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Compras_1080);
            }
            else
            {
                //  Toast.MakeText(this, "Screen size is neither large, normal or small", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Compras_1080);
            }

            // Se for um Nexus 4 - Resolução 768 x 1280
            //if (widthInDp == 384 && heightInDp == 592)
            //{
            //    SetContentView(Resource.Layout.Compras);

            //}

            //// Se for um Nexus 5 - Resolução 1080 x 1980
            //if (widthInDp == 360 && heightInDp == 592)
            //{
            //    SetContentView(Resource.Layout.Compras_1080);
            //}

            //// Se for um Nexus S - Resolução 480 x 800
            //if (widthInDp == 329 && heightInDp == 501)
            //{
            //    SetContentView(Resource.Layout.Compras_800);

            //}
            //else
            //{
            //    SetContentView(Resource.Layout.Compras);
            //}

            //08/04/2017 19:55h - FAZER LENDO O XML
            //Mostrar as leis de lazer no ListView

            lista = new ArrayList();
            bool sLeiServico = false;
            bool sLeisdeServico = false;
            bool sDescLeiLazer = false;
            string sTipoLei = "";
            string TagName = "";
            string Efavoritos = "0";

            XmlReader xReader = XmlReader.Create(Assets.Open("Leis.xml"));

            while (xReader.Read())
            {
                switch (xReader.NodeType)
                {
                    case XmlNodeType.Element:

                        // Lê a tag inicial
                        TagName = xReader.Name;

                        // se for tipoLei marca sLeiLazer como verdadeiro
                        if (xReader.Name == "tipolei")
                        {
                            sLeiServico = true;
                        }

                        if (xReader.Name == "nome")
                        {
                            sLeisdeServico = true;
                        }

                        if (xReader.Name == "desc")
                        {
                            sDescLeiLazer = true;
                        }

                        break;


                    case XmlNodeType.Text:

                        // Pega o valor do tipo de lei
                        if ((sLeiServico == true) && (TagName == "tipolei"))
                        {
                            // Identifica o tipo da lei
                            sTipoLei = xReader.Value;
                            sTipoLei = sTipoLei.Replace("\n", "");
                            sTipoLei = sTipoLei.Replace(" ", "");

                            // Se for do tipo Serviço marca verdadeira, senão marca false
                            if (sTipoLei == "compras")
                            {
                                sLeisdeServico = true;
                            }
                            else { sLeisdeServico = false; }

                        }

                        //preenche o cabeçalho da lei
                        if ((sDescLeiLazer == true) && (sTipoLei == "compras"))
                        {
                            lista.Add(xReader.Value);
                            sLeiServico = false;
                            sLeisdeServico = false;
                            sDescLeiLazer = false;
                        }

                        // Só prenche a lista com as leis de Servico
                        if ((sLeisdeServico == true) && (sTipoLei == "compras"))
                        {
                            lista.Add(xReader.Value);
                            sLeiServico = false;
                            sLeisdeServico = false;
                            sDescLeiLazer = false;
                        }

                        break;

                }
            }

            // 25/04/2017 20:38h
            // Carrega as leis em um vetor e as prepara para a tabela criada

            lista.RemoveAt(0);
            int y = lista.Count;
            for (int x = 0; x < y; x++)
            {

                // Se for par é a tag nome
                if (x % 2 == 0)
                {
                    LeisRepositorio.AddLeis(x, lista[x].ToString(), "");
                    //AddLeis(x+1, "", lista[x].ToString());
                }
                // se for ímpar é a tag desc
                else
                {
                    LeisRepositorio.AddLeis(x, "", lista[x].ToString());
                }

            }

            // 25/04/2017 20:32h
            // Apresenta a Lista de Leis com cores diferentes e destacadas

            var leisListView = FindViewById<ListView>(Resource.Id.listView1);
            leisListView.FastScrollEnabled = true;
            //filmesListView.ItemClick += FilmesListView_ItemClick;
            var leisAdapter = new LeiAdapter(this, LeisRepositorio.Leis);
            leisListView.Adapter = leisAdapter;

            // Pintar de uma cor e abrir a nova janela com a lei 
            leisListView.ItemClick += (sender, e) => {

                int Pos = e.Position;

                Posicao = Pos;

                // Se for par é a tag nome
                if (Pos % 2 == 0)
                {
                    //pegar o número da lei e repassar para a próxima tela
                    sDesc = lista[Pos].ToString();
                    //sDesc = lv1.GetItemAtPosition(e.Position).ToString();
                    sNome = lista[Pos + 1].ToString();
                }
                // se for ímpar é a tag desc
                else
                {
                    //pegar o número da lei e repassar para a próxima tela                    
                    sDesc = lista[Pos - 1].ToString();
                    sNome = lista[Pos].ToString();
                }

                // esperar meio segundo e abrir nova janela
                Thread.Sleep(500);

                sTipoLei = "compras";
                //repassar o valor para a nova tela
                var activity2 = new Intent(this, typeof(MostrarLei));
                if (sNome != "")
                {
                    activity2.PutExtra("MyDataNome", sNome);
                    activity2.PutExtra("MyDataDesc", sDesc);
                    activity2.PutExtra("MyDataTipoLei", sTipoLei);
                    activity2.PutExtra("MyDataFav", Efavoritos);
                }
                if (sDesc != "")
                {
                    activity2.PutExtra("MyDataNome", sNome);
                    activity2.PutExtra("MyDataDesc", sDesc);
                    activity2.PutExtra("MyDataTipoLei", sTipoLei);
                    activity2.PutExtra("MyDataFav", Efavoritos);
                }

                //Abrir a tela 
                StartActivity(activity2);
                //lv1.GetChildAt(e.Position).SetBackgroundColor(Android.Graphics.Color.Transparent);

            };

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
        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }
    }
}