using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22f_keresofa
{
	internal class Program
	{
		class Halmaz_BKF
		{
			int ertek;
			Halmaz_BKF bal;
			Halmaz_BKF jobb;

			public Halmaz_BKF(int ertek, Halmaz_BKF bal, Halmaz_BKF jobb)
			{
				this.ertek = ertek;
				this.bal = bal;
				this.jobb = jobb;
			}
			private Halmaz_BKF Helye(int elem) // a fa ilyen értékkel, vagy a szülő, ahol elakad.
			{
				if (ertek == elem)  // amit nézünk, az az elem, amit keresünk?
					return this;    // ha igen, akkor ezt kerestük, adjuk vissza!
				if (ertek > elem)   // Ha nem az az elem, de amit keresünk az nagyobb?
					return jobb != null? jobb.Helye(elem): this; // Ha nagyobb, akkor van gyereke? Ha van, akkor arra hívd meg, ha nincs, akkor ezt add vissza!
				return bal != null? bal.Helye(elem): this; // Ha kisebb, akkor van gyereke? Ha van, akkor arra hívd meg, ha nincs, akkor azt add vissza
			}
			public void Add(int elem)
			{
				Halmaz_BKF h = Helye(elem);
				if (h.ertek < elem)
					h.bal = new Halmaz_BKF(elem, null, null);
				if (h.ertek > elem)
					h.jobb = new Halmaz_BKF(elem, null, null);
			}

			public void Remove(int elem)
			{
				throw new NotImplementedException();
			}
			public bool Contains(int ertek) => Helye(ertek).ertek == ertek;

			public string Diagnosztika()
			{
				string s = "";
				if (bal != null)
					s += $"{ertek} -> {bal.ertek}\n\t{bal.Diagnosztika()}";
				if (jobb != null)
					s += $"{ertek} -> {jobb.ertek}\n\t{jobb.Diagnosztika()}";
				return s;
			}

			public override string ToString()
			{
				throw new NotImplementedException();
			}

			public static Halmaz_BKF operator +(Halmaz_BKF a, Halmaz_BKF b)
			{
				throw new NotImplementedException();
			}
			public static Halmaz_BKF operator *(Halmaz_BKF a, Halmaz_BKF b)
			{
				throw new NotImplementedException();
			}
			public static Halmaz_BKF operator -(Halmaz_BKF a, Halmaz_BKF b)
			{
				throw new NotImplementedException();
			}

		}
		static void Main(string[] args)
		{
			Halmaz_BKF h = new Halmaz_BKF(5, null, null);

			h.Add(7);
			h.Add(3);
			h.Add(9);
			h.Add(10);
			h.Add(4);
			h.Add(1);
			h.Add(2);
            Console.WriteLine(h.Diagnosztika());


        }
	}
}
