using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Android.Content.PM;
using Android.Views.Animations;
using System.Linq;
using Android.Graphics;
using Android.Content.Res;

namespace AppEspiaSo
{
    
    [Activity(Label = "ESPIA SÓ", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        bool eTelaInicial = false;
        
        GestureDetector gestureDetector;
        GestureListener gestureListener;
        ListView menuListView;
        MenuListAdapterClass objAdapterMenu;
        ImageView menuIconImageView;
        int intDisplayWidth;        
        bool isSingleTapFired = false;


        [Export("btnBuscaClicked")]
        public void btnBusca_Click(View v)
        {
            eTelaInicial = true;
            Intent intent = new Intent(this, typeof(ActivityBusca));
            this.StartActivity(intent);
        }

        [Export("btnLazerClicked")]
        public void button_Click(View v)
        {
            // Chamar a tela de Lazer
            eTelaInicial = true;
            var atividadeLazer = new Intent(this, typeof(ActivityLazer));
            StartActivity(atividadeLazer);
        }

        [Export("btnServicosClicked")]
        public void btnServicos_Click(View v)
        {
            eTelaInicial = true;
            Intent intent = new Intent(this, typeof(ActivityServico));
            this.StartActivity(intent);
        }

        [Export("btnSaudeClicked")]
        public void btnSaudeClicked_Click(View v)
        {
            eTelaInicial = true;
            Intent intent = new Intent(this, typeof(ActivitySaude));
            this.StartActivity(intent);           
        }

        [Export("btnComprasClicked")]
        public void btnComprasClicked_Click(View v)
        {
            eTelaInicial = true;
            Intent intent = new Intent(this, typeof(ActivityCompras));
            this.StartActivity(intent);           

        }

        [Export("btnOuvidoriaClicked")]
        public void btnOuvidoriaClicked_Click(View v)
        {
            eTelaInicial = true;
            Intent intent = new Intent(this, typeof(ActivityOuvidoria));
            this.StartActivity(intent);                    

        }

        [Export("btnFonesClicked")]
        public void btnFonesClicked_Click(View v)
        {
            eTelaInicial = true;
            Intent intent = new Intent(this, typeof(ActivityTelefone));
            this.StartActivity(intent);
        }

        [Export("btnFavoritosClicked")]
        public void btnFavoritosClicked_Click(View v)
        {
            eTelaInicial = true;            
            Intent intent = new Intent(this, typeof(ActivityFavoritos));
            this.StartActivity(intent);           
        }
        
        protected override void OnCreate(Bundle bundle)
        {
            //Algoritimo a desenvolver: 09/04/2017 14:48h
            //detectar o tamanho da tela em uso
            var metrics = Resources.DisplayMetrics;
            var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

            //remove título desta Activity
            Window.RequestFeature(WindowFeatures.NoTitle);

            //setar apropriadamente qual layout apresentar na tela
            base.OnCreate(bundle);

            
            //Determine screen size
            if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeLarge)
            {
                Toast.MakeText(this, "Large screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Main_1080);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeNormal)
            {
                Toast.MakeText(this, "Normal screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Main);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeSmall)
            {
                Toast.MakeText(this, "Small screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Main_800);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeXlarge)
            {
                Toast.MakeText(this, "XLarge screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Main_1080);
            }
            else
            {
                Toast.MakeText(this, "Screen size is neither large, normal or small", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Main_1080);
            }

            // Se for um Nexus 4 - Resolução 768 x 1280 - Galaxy J3
            //if (widthInDp == 384 && heightInDp == 592){               
            //    SetContentView(Resource.Layout.Main);  
            //}

            //// Se for um Nexus 5 - Resolução 1080 x 1980 Motorola G4 5,5 polegadas
            //if (widthInDp == 360 && heightInDp == 592)
            //{               
            //    SetContentView(Resource.Layout.Main_1080);
            //}

            //// Se for um Nexus S - Resolução 480 x 800
            //if (widthInDp == 329 && heightInDp == 501)
            //{  
            //    SetContentView(Resource.Layout.Main_800);
            //}
            //else
            //{
            //    SetContentView(Resource.Layout.Main);
            //}

            // Chamado do Botão lateral 16/04/2017 22:07h 
            FnInitialization();
            TapEvent();
            FnBindMenu();

        }

        //Começo da construção do menu Lateral
        void TapEvent()
        {
            menuIconImageView.Click += delegate (object sender, EventArgs e)
            {
                if (!isSingleTapFired)
                {
                    FnToggleMenu();
                    isSingleTapFired = false;
                }
            };         
        }

        //Finalização do Menu Lateral
        void FnInitialization()
        {
            //gesture initialization
            gestureListener = new GestureListener();
            gestureListener.LeftEvent += GestureLeft;
            gestureListener.RightEvent += GestureRight;
            gestureListener.SingleTapEvent += SingleTap;
            gestureDetector = new GestureDetector(this, gestureListener);
            menuListView = FindViewById<ListView>(Resource.Id.menuListView);
            menuIconImageView = FindViewById<ImageView>(Resource.Id.menuIconImgView);            
            Display display = this.WindowManager.DefaultDisplay;
            var point = new Point();
            display.GetSize(point);
            intDisplayWidth = point.X;
            intDisplayWidth = intDisplayWidth - (intDisplayWidth / 3);
            using (var layoutParams = (RelativeLayout.LayoutParams)menuListView.LayoutParameters)
            {
                layoutParams.Width = intDisplayWidth;
                layoutParams.Height = ViewGroup.LayoutParams.MatchParent;
                menuListView.LayoutParameters = layoutParams;
            }

            // Limpar a Tabela de leis
            LeisRepositorio.DeletaLeis();
        }

        #region " Menu related"
        void FnBindMenu()
        {
            //Itens do Menu Lateral
            string[] strMnuText = {"Favoritos", "Conheça a ALEAM", "Sobre" };
            
            if (objAdapterMenu != null)
            {
                objAdapterMenu.actionMenuSelected -= FnMenuSelected;
                objAdapterMenu = null;
            }

            objAdapterMenu = new MenuListAdapterClass(this, strMnuText);
            objAdapterMenu.actionMenuSelected += FnMenuSelected;
            menuListView.Adapter = objAdapterMenu;

        }

        //Seleção do Menu Lateral
        void FnMenuSelected(string strMenuText)
        {
            //Carrega o menu lateral
            if (strMenuText == "Favoritos")
            {
                var atividadeFavoritos = new Intent(this, typeof(ActivityFavoritos));
                StartActivity(atividadeFavoritos);
            }

            if (strMenuText == "Conheça a ALEAM")
            {
                // SOBRE A ALEAM
                var atividadeConheca = new Intent(this, typeof(ActivityConheca));
                StartActivity(atividadeConheca);     
            }

            if (strMenuText == "Sobre")
            {
                // SOBRE O APP                 
                var atividadeConhecaAleam = new Intent(this, typeof(ActivityConhecaaALEAM));
                StartActivity(atividadeConhecaAleam);
            }

        }
        void FnToggleMenu()
        {
            Console.WriteLine(menuListView.IsShown);
            if (menuListView.IsShown)
            {
                menuListView.Animation = new TranslateAnimation(0f, -menuListView.MeasuredWidth, 0f, 0f);
                menuListView.Animation.Duration = 300;
                menuListView.Visibility = ViewStates.Gone;
            }
            else
            {
                menuListView.Visibility = ViewStates.Visible;
                menuListView.RequestFocus();
                menuListView.Animation = new TranslateAnimation(-menuListView.MeasuredWidth, 0f, 0f, 0f);//starting edge of layout 
                menuListView.Animation.Duration = 300;
            }
        }
        #endregion

        #region "Gesture function "
        void GestureLeft()
        {
            if (!menuListView.IsShown)
                FnToggleMenu();
            isSingleTapFired = false;
        }
        void GestureRight()
        {
            if (menuListView.IsShown)
                FnToggleMenu();
            isSingleTapFired = false;
        }
        void SingleTap()
        {
            if (menuListView.IsShown)
            {
                FnToggleMenu();
                isSingleTapFired = true;
            }
            else
            {
                isSingleTapFired = false;
            }
        }
        public override bool DispatchTouchEvent(MotionEvent ev)
        {
            gestureDetector.OnTouchEvent(ev);
            return base.DispatchTouchEvent(ev);
        }
        #endregion
        

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }
        

        public void onBackPressed()
        {
            // Limpar a Tabela de leis
            LeisRepositorio.DeletaLeis();

            SetContentView(Resource.Layout.Main);
        }

        public override bool DispatchKeyEvent(KeyEvent e)
        {

            if (e.KeyCode == Keycode.Back)
            {
                // Só fechar se for na tela inicial
                if (eTelaInicial == false)
                {
                    // Limpar a Tabela de leis
                    LeisRepositorio.DeletaLeis();
                    FavoritoRepositorio.DeletaFavoritos();
                    this.Finish();
                }
            }

            eTelaInicial = false;
            return true;
        }

    }
    #region " Menu list adapter"
    public class MenuListAdapterClass : BaseAdapter<string>
    {
        Activity _context;
        string[] _mnuText;
        //int[] _mnuUrl;
        internal event Action<string> actionMenuSelected;
        public MenuListAdapterClass(Activity context, string[] strMnu)
        {
            _context = context;
            _mnuText = strMnu;            
        }
        public override string this[int position]
        {
            get { return this._mnuText[position]; }
        }

        public override int Count
        {
            get { return this._mnuText.Count(); }
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            MenuListViewHolderClass objMenuListViewHolderClass;
            View view;
            view = convertView;
            if (view == null)
            {
                view = _context.LayoutInflater.Inflate(Resource.Layout.MenuCustomLayout, parent, false);
                objMenuListViewHolderClass = new MenuListViewHolderClass();

                objMenuListViewHolderClass.txtMnuText = view.FindViewById<TextView>(Resource.Id.txtMnuText);
                objMenuListViewHolderClass.ivMenuImg = view.FindViewById<ImageView>(Resource.Id.ivMenuImg);

                objMenuListViewHolderClass.initialize(view);
                view.Tag = objMenuListViewHolderClass;
            }
            else
            {
                objMenuListViewHolderClass = (MenuListViewHolderClass)view.Tag;
            }
            objMenuListViewHolderClass.viewClicked = () =>
            {
                if (actionMenuSelected != null)
                {
                    actionMenuSelected(_mnuText[position]);
                }
            };
            objMenuListViewHolderClass.txtMnuText.Text = _mnuText[position];
            //objMenuListViewHolderClass.ivMenuImg.SetImageResource(_mnuUrl[position]);
            return view;
        }
    }
    internal class MenuListViewHolderClass : Java.Lang.Object
    {
        internal Action viewClicked { get; set; }
        internal TextView txtMnuText;
        internal ImageView ivMenuImg;
        public void initialize(View view)
        {
            view.Click += delegate
            {
                viewClicked();
            };
        }

    }

    #endregion
}

