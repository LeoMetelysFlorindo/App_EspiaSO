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

namespace AppEspiaSo
{
    class FavoritoAdapter : BaseAdapter<Favorito>
    {

        private readonly Activity context;
        private readonly List<Favorito> favoritos;

        public FavoritoAdapter(Activity context, List<Favorito> favoritos)
        {
            this.context = context;
            this.favoritos = favoritos;
        }

        public override Favorito this[int position]
        {
            get
            {
                return favoritos[position];
            }
        }

        public override int Count
        {
            get
            {
                return favoritos.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return favoritos[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.ListaFavorito, parent, false);
            var txtLeiFavorito = view.FindViewById<TextView>(Resource.Id.txtLeiFavorito);            

            txtLeiFavorito.SetTextColor(Android.Graphics.Color.Gold);
            txtLeiFavorito.Text = favoritos[position].Nome; 
            
            return view;
        }

    }
}