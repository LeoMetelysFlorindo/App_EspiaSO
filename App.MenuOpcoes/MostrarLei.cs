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
using Android.Content.Res;

namespace AppEspiaSo
{
    [Activity(Label = "MOSTRAR LEI", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MostrarLei : Activity
    {

        string sTextoIntegral = "";
        string sLinkLei = "";
        public Button BotaLei;
        public Button BotaoShare;
        public Button BotaoFavoritos;
        public Button BotaoExcluir;

        public int y;
        public ArrayList lista;

        [Export("btnHomeClicked")]
        public void btnHomeClicked_Click(View v)
        {

            // Chamar a tela de Lazer
            // var atividadeLazer = new Intent(this, typeof(MainActivity));
            // StartActivity(atividadeLazer);
            //this.CloseContextMenu();

            this.Finish();

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeLarge)
            {
                //Toast.MakeText(this, "Large screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Main_1080);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeNormal)
            {
                //Toast.MakeText(this, "Normal screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Main);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeSmall)
            {
                //Toast.MakeText(this, "Small screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Main_800);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeXlarge)
            {
                //Toast.MakeText(this, "XLarge screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Main_1080);
            }
            else
            {
               // Toast.MakeText(this, "Screen size is neither large, normal or small", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Main_1080);
            }

            y = 0;

            //remove título desta Activity
            Window.RequestFeature(WindowFeatures.NoTitle);

            // Receber dados da lei selecionada
            string snome = Intent.GetStringExtra("MyDataNome");
            string sdesc = Intent.GetStringExtra("MyDataDesc");
            string stipolei = Intent.GetStringExtra("MyDataTipoLei");
            string sAtivaFavExcluidos = Intent.GetStringExtra("MyDataFav");

            SetContentView(Resource.Layout.MostraLei);

            var TxtNumeroLei = FindViewById<TextView>(Resource.Id.txtNoLei);
            TxtNumeroLei.SetTextColor(Android.Graphics.Color.Yellow);

            //repassar o valor
            TxtNumeroLei.Text = sdesc;

            var TxtEmenta = FindViewById<TextView>(Resource.Id.txtEmenta);
            TxtEmenta.SetTextColor(Android.Graphics.Color.White);

            //30/05/2017 09:37h Ativar botão de Excluir Favoritos
            BotaoExcluir = (Button)FindViewById(Resource.Id.btnExcluiFav);
           
            if (sAtivaFavExcluidos =="1")
            {
                BotaoExcluir.Visibility = ViewStates.Visible; 
            }


            //23/04/2017 20:12h
            // Leis de Lazer
            if (stipolei == "lazer")
            {

                //Pegar os outros dados da lei e mostrar ao usuário                              

                bool sEmentaLeiLazer = false;
                bool sTextoLei = false;
                bool sLinkdaLei = false;
                string sTipoLei = "";
                string TagName = "";
                string sNoLei = "";
                string sEmentaLei = "";

                XmlReader xReader = XmlReader.Create(Assets.Open("Leis.xml"));

                while (xReader.Read())
                {


                    switch (xReader.NodeType)
                    {

                        case XmlNodeType.Element:

                            // Lê a tag inicial
                            TagName = xReader.Name;

                            break;

                        case XmlNodeType.Text:

                            if (TagName == "tipolei")
                            {
                                sTipoLei = xReader.GetAttribute("tipolei");
                                sTipoLei = xReader.Value;
                                sTipoLei = sTipoLei.Replace("\n", "");
                                sTipoLei = sTipoLei.Replace(" ", "");
                            }
                            
                            if (TagName == "desc")
                            {
                                if (sdesc != "")
                                {
                                    if (sTipoLei == "lazer")
                                    {
                                        sNoLei = xReader.Value;
                                        if (sdesc == sNoLei)
                                        {
                                            sEmentaLeiLazer = true;
                                            sTextoLei = true;
                                        }
                                    }
                                }
                            }
                            
                            if (TagName == "ementa")
                            {
                                if (sEmentaLeiLazer == true)
                                {
                                    TxtEmenta.Text = xReader.Value;
                                    sEmentaLei = xReader.Value;
                                    sEmentaLeiLazer = false;

                                }

                            }

                            // Só faz se for true
                            if (TagName == "texto")
                            {
                                if (sTextoLei == true)
                                {
                                    sTextoIntegral = xReader.Value;
                                    sTextoLei = false;
                                    sLinkdaLei = true;
                                }

                            }

                            // Só faz se for true
                            if (TagName == "linkSAPL")
                            {
                                if (sLinkdaLei == true)
                                {
                                    sLinkLei = xReader.Value;
                                    sTextoLei = false;
                                    sLinkdaLei = false;
                                }

                            }
                            break;


                    } // fim switch (xReader.NodeType)


                } // fim do while

            }// fim do if das leis de lazer


            //23/04/2017 20:12h
            // Leis de Serviço
            if (stipolei == "servico")
            {

                //Pegar os outros dados da lei e mostrar ao usuário                              

                bool sEmentaLeiLazer = false;
                bool sTextoLei = false;
                bool sLinkdaLei = false;
                string sTipoLei = "";
                string TagName = "";
                string sNoLei = "";
                string sEmentaLei = "";

                XmlReader xReader = XmlReader.Create(Assets.Open("Leis.xml"));

                while (xReader.Read())
                {


                    switch (xReader.NodeType)
                    {

                        case XmlNodeType.Element:

                            // Lê a tag inicial
                            TagName = xReader.Name;

                            break;

                        case XmlNodeType.Text:

                            if (TagName == "tipolei")
                            {
                                sTipoLei = xReader.GetAttribute("tipolei");
                                sTipoLei = xReader.Value;
                                sTipoLei = sTipoLei.Replace("\n", "");
                                sTipoLei = sTipoLei.Replace(" ", "");
                            }


                            if (TagName == "desc")
                            {
                                if (sdesc != "")
                                {
                                    if (sTipoLei == "servico")
                                    {
                                        sNoLei = xReader.Value;
                                        if (sdesc == sNoLei)
                                        {
                                            sEmentaLeiLazer = true;
                                            sTextoLei = true;
                                        }
                                    }
                                }

                            }



                            if (TagName == "ementa")
                            {
                                if (sEmentaLeiLazer == true)
                                {
                                    TxtEmenta.Text = xReader.Value;
                                    sEmentaLei = xReader.Value;
                                    sEmentaLeiLazer = false;

                                }

                            }

                            // Só faz se for true
                            if (TagName == "texto")
                            {
                                if (sTextoLei == true)
                                {
                                    sTextoIntegral = xReader.Value;
                                    sTextoLei = false;
                                    sLinkdaLei = true;
                                }

                            }

                            // Só faz se for true
                            if (TagName == "linkSAPL")
                            {
                                if (sLinkdaLei == true)
                                {
                                    sLinkLei = xReader.Value;
                                    sTextoLei = false;
                                    sLinkdaLei = false;
                                }

                            }
                            break;


                    } // fim switch (xReader.NodeType)


                } // fim do while

            }// fim do if das leis de servico



            //23/04/2017 20:19h
            // Leis de Saúde
            if (stipolei == "saude")
            {

                //Pegar os outros dados da lei e mostrar ao usuário                              

                bool sEmentaLeiLazer = false;
                bool sTextoLei = false;
                bool sLinkdaLei = false;
                string sTipoLei = "";
                string TagName = "";
                string sNoLei = "";
                string sEmentaLei = "";

                XmlReader xReader = XmlReader.Create(Assets.Open("Leis.xml"));

                while (xReader.Read())
                {


                    switch (xReader.NodeType)
                    {

                        case XmlNodeType.Element:

                            // Lê a tag inicial
                            TagName = xReader.Name;

                            break;

                        case XmlNodeType.Text:

                            if (TagName == "tipolei")
                            {
                                sTipoLei = xReader.GetAttribute("tipolei");
                                sTipoLei = xReader.Value;
                                sTipoLei = sTipoLei.Replace("\n", "");
                                sTipoLei = sTipoLei.Replace(" ", "");
                            }


                            if (TagName == "desc")
                            {
                                if (sdesc != "")
                                {
                                    if (sTipoLei == "saude")
                                    {
                                        sNoLei = xReader.Value;
                                        if (sdesc == sNoLei)
                                        {
                                            sEmentaLeiLazer = true;
                                            sTextoLei = true;
                                        }
                                    }
                                }

                            }



                            if (TagName == "ementa")
                            {
                                if (sEmentaLeiLazer == true)
                                {
                                    TxtEmenta.Text = xReader.Value;
                                    sEmentaLei = xReader.Value;
                                    sEmentaLeiLazer = false;

                                }

                            }

                            // Só faz se for true
                            if (TagName == "texto")
                            {
                                if (sTextoLei == true)
                                {
                                    sTextoIntegral = xReader.Value;
                                    sTextoLei = false;
                                    sLinkdaLei = true;
                                }

                            }

                            // Só faz se for true
                            if (TagName == "linkSAPL")
                            {
                                if (sLinkdaLei == true)
                                {
                                    sLinkLei = xReader.Value;
                                    sTextoLei = false;
                                    sLinkdaLei = false;
                                }

                            }
                            break;


                    } // fim switch (xReader.NodeType)


                } // fim do while

            }// fim do if das leis de saude


            //23/04/2017 20:23h
            // Leis de Saúde
            if (stipolei == "compras")
            {

                //Pegar os outros dados da lei e mostrar ao usuário                              

                bool sEmentaLeiLazer = false;
                bool sTextoLei = false;
                bool sLinkdaLei = false;
                string sTipoLei = "";
                string TagName = "";
                string sNoLei = "";
                string sEmentaLei = "";
                XmlReader xReader = XmlReader.Create(Assets.Open("Leis.xml"));

                while (xReader.Read())
                {
                    switch (xReader.NodeType)
                    {

                        case XmlNodeType.Element:

                            // Lê a tag inicial
                            TagName = xReader.Name;
                            break;

                        case XmlNodeType.Text:

                            if (TagName == "tipolei")
                            {
                                sTipoLei = xReader.GetAttribute("tipolei");
                                sTipoLei = xReader.Value;
                                sTipoLei = sTipoLei.Replace("\n", "");
                                sTipoLei = sTipoLei.Replace(" ", "");
                            }


                            if (TagName == "desc")
                            {
                                if (sdesc != "")
                                {
                                    if (sTipoLei == "compras")
                                    {
                                        sNoLei = xReader.Value;
                                        if (sdesc == sNoLei)
                                        {
                                            sEmentaLeiLazer = true;
                                            sTextoLei = true;
                                        }
                                    }
                                }

                            }

                            if (TagName == "ementa")
                            {
                                if (sEmentaLeiLazer == true)
                                {
                                    TxtEmenta.Text = xReader.Value;
                                    sEmentaLei = xReader.Value;
                                    sEmentaLeiLazer = false;
                                }
                            }

                            // Só faz se for true
                            if (TagName == "texto")
                            {
                                if (sTextoLei == true)
                                {
                                    sTextoIntegral = xReader.Value;
                                    sTextoLei = false;
                                    sLinkdaLei = true;
                                }

                            }

                            // Só faz se for true
                            if (TagName == "linkSAPL")
                            {
                                if (sLinkdaLei == true)
                                {
                                    sLinkLei = xReader.Value;
                                    sTextoLei = false;
                                    sLinkdaLei = false;
                                }

                            }

                            break;


                    } // fim switch (xReader.NodeType)


                } // fim do while

            }// fim do if das leis de saude

            // Botões na tela
            BotaLei = (Button)FindViewById(Resource.Id.BtnLei);
            BotaoShare = (Button)FindViewById(Resource.Id.btnShare);
            BotaoFavoritos = (Button)FindViewById(Resource.Id.btnFavoritos);
            

            //Clique no Botão Visualizar Lei
            BotaLei.Click += (sender, e) =>
            {
                //Colocar botão invisível
                BotaLei.Visibility = ViewStates.Invisible;

                // Exibir o texto integral de toda a lei
                var TxtTexto = FindViewById<TextView>(Resource.Id.txtIntegral);
                TxtTexto.Text = sTextoIntegral;
                TxtTexto.SetTextColor(Android.Graphics.Color.White);
                TxtTexto.Visibility = ViewStates.Visible;

                // Torna os botões Visíveis no final
                BotaoFavoritos.Visibility = ViewStates.Visible;
                BotaoShare.Visibility = ViewStates.Visible;

            };

            //Clique no Botão Compartilhar
            BotaoShare.Click += (sender, e) =>
            {
                var activity2 = new Intent(this, typeof(ActivityCompartilhar));
                activity2.PutExtra("MyLinkLei", sLinkLei);

                //Abrir a tela 
                StartActivity(activity2);

            };

           

            // Clicar no botão Favoritar uma Lei
            BotaoFavoritos.Click += (sender, e) =>
            {
                
                //23/05/2017 22:11h
                //Abrir o arquivo-texto criado e acrescentar as leis que foram colocadas em favoritos
                string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string filename = System.IO.Path.Combine(path, "favoritos.txt");
                bool JaExiste = false;
                //24/05/2017 11:02h Verificar se o arquivo já existe
                if (System.IO.File.Exists(filename))
                {
                    //Se o arquivo existir, pega a lista de dados dele
                    lista = new ArrayList();
                    var list = new List<string>();

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
                    string sverificaTexto = "";
                    string stipoLei = "";

                    //Joga o conteúdo do arquivo-texto em um vetor e depois dentro do tabela criada
                    int y = list.Count;
                    int n = 0;
                    for (int x = 0; x < y; x++)
                    {
                        sdescricaoLei = list[x].ToString();
                        for (int z = 0; z < sdescricaoLei.Length; z++)
                        {
                            sAux = sdescricaoLei.Substring(z, 1);
                            if (sAux != ";")
                            {
                                sverificaTexto = sverificaTexto + sdescricaoLei.Substring(z, 1);
                            }
                            else
                            {
                                int m = z + 1;
                                n = sdescricaoLei.Length - m;
                                stipoLei = sdescricaoLei.Substring(m, n);
                                z = sdescricaoLei.Length;
                            }

                        }

                        if (sdesc == sverificaTexto)
                        {
                            JaExiste = true;
                        }

                    }

                    if (JaExiste == false)
                    {
                        // acrescentar no arquivo texto a descrição e o tipo da lei selecionada
                        string sTexto = "";
                        sTexto = sdesc + ";" + stipolei  + "\n";
                        using (var streamWriter = new StreamWriter(filename, true))
                        {
                            streamWriter.WriteLine(sTexto);
                        }

                        Android.Widget.Toast.MakeText(this, "Lei acrescentada à lista de Favoritos!", Android.Widget.ToastLength.Short).Show();
                    }
                    else
                    {
                        Android.Widget.Toast.MakeText(this, "Lei já existe na lista de Favoritos!", Android.Widget.ToastLength.Short).Show();
                    }

                }
                else
                {
                    //24/05/2017 11:01h cria o arquivo
                    string sTexto = sdesc + ";" + stipolei + "\n";
                    using (var streamWriter = new StreamWriter(filename, true))
                    {
                        streamWriter.WriteLine(sTexto);
                    }

                    Android.Widget.Toast.MakeText(this, "Lei acrescentada à lista de Favoritos!", Android.Widget.ToastLength.Short).Show();

                }
                
            };

            BotaoExcluir.Click += (sender, e) =>
            {
                string path2 = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string filename2 = System.IO.Path.Combine(path2, "favoritos.txt");
                if (System.IO.File.Exists(filename2))
                {                    
                    //Se o arquivo existir, pega a lista de dados dele
                    lista = new ArrayList();
                    var list = new List<string>();
                    var listNew = new List<string>();
                    int contaexclui = 0;

                    using (var streamReader = new StreamReader(filename2))
                    {
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            list.Add(line);
                        }

                    }
                    string sdescricaoLei;
                    string sAux = "";
                    string sverificaTexto = "";
                    string stipoLei = "";

                    //Joga o conteúdo do arquivo-texto em um vetor e depois dentro do tabela criada
                    int y = list.Count;
                    int n = 0;
                    int zAux = 0;
                    for (int x = 0; x < y; x++)
                    {
                        sdescricaoLei = list[x].ToString();
                        for (int z = 0; z < sdescricaoLei.Length; z++)
                        {
                            sAux = sdescricaoLei.Substring(z, 1);
                            if (sAux != ";")
                            {
                                sverificaTexto = sverificaTexto + sdescricaoLei.Substring(z, 1);
                            }
                            else
                            {
                                zAux = x;
                                int m = z + 1;
                                n = sdescricaoLei.Length - m;
                                stipoLei = sdescricaoLei.Substring(m, n);
                                z = sdescricaoLei.Length;
                            }

                        }

                        //Apagar o item selecionado da lista 
                        if (sdesc == sverificaTexto)
                        {
                            contaexclui++;
                        }
                        else
                        {
                            listNew.Add(sdescricaoLei); 
                        }

                    }

                    // Deletar o arquivo antigo
                    System.IO.File.Delete(filename2);

                    // 30/05/2017 10:51h
                    //Criar o novo arquivo de favoritos sem o item excluído
                    string path3 = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                    string filename3 = System.IO.Path.Combine(path3, "favoritos.txt");
                    int w = listNew.Count;
                    for (int x = 0; x < w; x++)
                    {
                        sdescricaoLei = listNew[x].ToString();
                        using (var streamWriter = new StreamWriter(filename3, true))
                        {
                            streamWriter.WriteLine(sdescricaoLei);
                        }
                    }

                    Android.Widget.Toast.MakeText(this, "Item excluído da lista de Favoritos!", Android.Widget.ToastLength.Short).Show();
                }

            };

        }
    }
}