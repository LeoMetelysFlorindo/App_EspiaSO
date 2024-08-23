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
using Android.Content.Res;

namespace AppEspiaSo
{
    [Activity(Label = " SOBRE ", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ActivityConhecaaALEAM : Activity
    {
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
                SetContentView(Resource.Layout.Sobre_1080);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeNormal)
            {
                // Toast.MakeText(this, "Normal screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.ConhecaAleam);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeSmall)
            {
                // Toast.MakeText(this, "Small screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Sobre_800);
            }
            else if ((Application.Context.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeXlarge)
            {
                // Toast.MakeText(this, "XLarge screen", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Sobre_1080);
            }
            else
            {
                // Toast.MakeText(this, "Screen size is neither large, normal or small", ToastLength.Short).Show();
                SetContentView(Resource.Layout.Sobre_1080);
            }


            //// Se for um Nexus 4 - Resolução 768 x 1280
            //if (widthInDp == 384 && heightInDp == 592)
            //{
            //    SetContentView(Resource.Layout.ConhecaAleam);
            //}

            //// Se for um Nexus 5 - Resolução 1080 x 1980
            //if (widthInDp == 360 && heightInDp == 592)
            //{
            //    SetContentView(Resource.Layout.Sobre_1080);
            //}

            //// Se for um Nexus S - Resolução 480 x 800
            //if (widthInDp == 329 && heightInDp == 501)
            //{
            //    SetContentView(Resource.Layout.Sobre_800);
            //}

            //else
            //{
            //    SetContentView(Resource.Layout.ConhecaAleam);
            //}

        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }
    }
}