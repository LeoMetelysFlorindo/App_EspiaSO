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
using Java.Lang;
using System.Xml;
using System.IO;
using Android.Content.PM;
using System.Collections;
using Android.Graphics;
using Android.Views.Animations;
using Android.Content.Res;

namespace AppEspiaSo
{
    [Activity(Label = " FAVORITOS ", ScreenOrientation = ScreenOrientation.Portrait)]


        public class ActivityFavoritos : Activity
        {

        

        [Export("btnHomeClicked")]
        public void btnHomeClicked_Click(View v)
        {
            FavoritoRepositorio.DeletaFavoritos();
            this.Finish();
        }

        string sNome = "";
        string sDesc = "";
        public ArrayList lista;
        public ArrayList listaSalva;
        public ArrayAdapter adp1;
        public  ListView lv1;
        public Button BotaoApagar;
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
                //  Toast.MakeText(this, "Large screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Favoritos_1080);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeNormal)
            {
                //   Toast.MakeText(this, "Normal screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Favoritos);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeSmall)
            {
                // Toast.MakeText(this, "Small screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Favoritos_800);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeXlarge)
            {
                Toast.MakeText(this, "XLarge screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Favoritos_1080);
            }
            else
            {
                //Toast.MakeText(this, "Screen size is neither large, normal or small", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Favoritos_1080);
            }

            // Se for um Nexus 4 - Resolução 768 x 1280
            //if (widthInDp == 384 && heightInDp == 592)
            //{
            //    SetContentView(Resource.Layout.Favoritos);
            //}

            //// Se for um Nexus 5 - Resolução 1080 x 1980
            //if (widthInDp == 360 && heightInDp == 592)
            //{
            //    SetContentView(Resource.Layout.Favoritos_1080);
            //}

            //// Se for um Nexus S - Resolução 480 x 800
            //if (widthInDp == 329 && heightInDp == 501)
            //{
            //    SetContentView(Resource.Layout.Favoritos_800);

            //}
            //else
            //{
            //    // evitar abrir a tela duas vezes 16/04/2017 22:42h
            //    SetContentView(Resource.Layout.Favoritos);
            //}

            //30/05/2017 Ativar tela de favoritos
             

            // 24/05/2017 10:50h
            // Apagar a tabela de Favoritos e preencher de novo!!
            FavoritoRepositorio.DeletaFavoritos();

            // Lista o conteúdo do arquivo XML de Favoritos

            //23/0/2017 09:31h
            // Fazer a lista de compartilhamento ser exibida ao usuário
            //ListView firstListView = (ListView)FindViewById(Resource.Id.listViewFav);
            //firstListView.FastScrollEnabled = true;

            //var leisAdapter = new FavoritoAdapter(this, FavoritoRepositorio.Favoritos);
            //firstListView.Adapter = leisAdapter;

            // 23/05/2017 20:37h
            // Pega o arquivo-texto criado, abre-o e lê o seu conteúdo
            lista = new ArrayList();
            
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string filename = System.IO.Path.Combine(path, "favoritos.txt");
            var list = new List<string>();

            //24/05/2017 10:29h Só fazer se o arquivo realmente existir
            if (System.IO.File.Exists(filename))
            {
                using (var streamReader = new StreamReader(filename))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        list.Add(line);
                    }

                }

                string sdescricaoLei;
                string sAux = "";
                string sTexto = "";
                string stipoLei = "";
                string Efavoritos = "1"; 
                listaSalva = new ArrayList();
                //Joga o conteúdo do arquivo-texto em um vetor e depois dentro do tabela criada
                int y = list.Count;
                int n = 0;
                for (int x = 0; x < y; x++)
                {
                    sdescricaoLei = list[x].ToString();
                    sTexto = "";
                    for (int z = 0; z < sdescricaoLei.Length; z++)
                    {
                        sAux = sdescricaoLei.Substring(z, 1);
                        if (sAux != ";")
                        {
                            sTexto = sTexto + sdescricaoLei.Substring(z, 1);
                        }
                        else
                        {
                            int m = z + 1;
                            n = sdescricaoLei.Length - m;
                            stipoLei = sdescricaoLei.Substring(m, n);
                            z = sdescricaoLei.Length;
                        }
                    }

                    
                    // Elimina os brancos da lista de Favoritos
                    if (list[x].ToString() != "")
                    {
                        int cont = 0;
                        FavoritoRepositorio.AddFavoritos(cont, sTexto, stipoLei);                        
                        listaSalva.Add(list[x].ToString());
                        cont++;
                    }

                }

                // Pega a tabela criada e mostra ao usuário adaptada
                ListView firstListView = (ListView)FindViewById(Resource.Id.listViewFav);
                firstListView.FastScrollEnabled = true;
                var leisAdapter = new FavoritoAdapter(this, FavoritoRepositorio.Favoritos);
                firstListView.Adapter = leisAdapter;


                // Apresentar a Lei ao Usuário
                firstListView.ItemClick += (sender, e) =>
                {

                    sTexto = "";
                    int Pos = e.Position;
                    stipoLei = listaSalva[Pos].ToString();
                    for (int z = 0; z < stipoLei.Length; z++)
                    {
                        sAux = stipoLei.Substring(z, 1);
                        if (sAux != ";")
                        {
                            sTexto = sTexto + stipoLei.Substring(z, 1);
                        }
                        else
                        {
                            int p = z + 1;
                            n = stipoLei.Length - p;
                            stipoLei = stipoLei.Substring(p, n);
                            z = stipoLei.Length;
                        }
                    }
                    sDesc = sTexto;

                    // esperar meio segundo e abrir nova janela
                    Thread.Sleep(500);

                    //sTipoLei = "lazer";
                    //repassar o valor para a nova tela
                    var activity2 = new Intent(this, typeof(MostrarLei));
                    if (sDesc != "")
                    {
                        //activity2.PutExtra("MyDataNome", sNome);
                        activity2.PutExtra("MyDataDesc", sDesc);
                        activity2.PutExtra("MyDataTipoLei", stipoLei);
                        activity2.PutExtra("MyDataFav", Efavoritos);
                    }

                    //Abrir a tela 
                    StartActivity(activity2);
                    //lv1.GetChildAt(e.Position).SetBackgroundColor(Android.Graphics.Color.Transparent);

                };
                

            }
            else
            {
                Android.Widget.Toast.MakeText(this, "Sem lista de Favoritos!", Android.Widget.ToastLength.Short).Show();
            }


        } // fim do OnCreate


        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }
    }
}