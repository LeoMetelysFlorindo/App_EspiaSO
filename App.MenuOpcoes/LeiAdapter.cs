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
    class LeiAdapter : BaseAdapter<Lei>
    {
        private readonly Activity context;
        private readonly List<Lei> leis;

        public LeiAdapter(Activity context, List<Lei> leis)
        {
            this.context = context;
            this.leis = leis;
        }

        public override Lei this[int position]
        {
            get
            {
                return leis[position];
            }
        }

        public override int Count
        {
            get
            {
                return leis.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return leis[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.ListaLei, parent, false);
            var txtTitulo = view.FindViewById<TextView>(Resource.Id.tituloTextView);
            var txtDiretor = view.FindViewById<TextView>(Resource.Id.diretorTextView);

            txtTitulo.SetTextColor(Android.Graphics.Color.Gold);
            //txtTitulo.SetBackgroundColor(Android.Graphics.Color.Gold);

            txtDiretor.SetTextColor(Android.Graphics.Color.White);
            //txtDiretor.SetBackgroundColor(Android.Graphics.Color.Blue);

            txtTitulo.Text = leis[position].NumeroLei;
            txtDiretor.Text = leis[position].NomeLei;

            return view;
        }
    }
}