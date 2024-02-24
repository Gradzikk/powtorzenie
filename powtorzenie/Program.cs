using System;
using System.Collections.Generic;   

internal class Programm
{

    public interface IProdukt
    {
        string WyswietlInfo();
        int AktualnaCena();
        int DostępnaIlosc();

    }

    public abstract class Produkt : IProdukt
    {
        public string Nazwa { get; set; }
        public int Cena { get; set; }
        public int Ilosc { get; set; }

        protected Produkt(string nazwa, int cena, int ilosc)
        {
            Nazwa = nazwa;
            Cena = cena;
            Ilosc = ilosc;
        }

        public string WyswietlInfo()
        {
            return Nazwa;
        }

        public int AktualnaCena()
        {
            return Cena;
        }

        public int DostępnaIlosc()
        {
            return Ilosc;
        }
    }

    public class Ksiazka : Produkt
    {
        public Ksiazka(string nazwa, int cena, int ilosc) : base(nazwa, cena, ilosc)
        {
        }
    }

    public class Elektronika : Produkt
    {
        public Elektronika(string nazwa, int cena, int ilosc) : base(nazwa, cena, ilosc)
        {
        }
    }

    public class Odziez : Produkt
    {
        public Odziez(string nazwa, int cena, int ilosc) : base(nazwa, cena, ilosc)
        {
        }
    }

    public abstract class Osoba
    {
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }

        protected Osoba(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }
    }

    public class Klient : Osoba
    {

        private List<IProdukt> koszyk = new List<IProdukt>();

        public Klient(string imie, string nazwisko) : base(imie, nazwisko)
        {
        }
        public int Ilosc { get; set; }

        public void DodajDoKoszyka(IProdukt produkt)
        {
            int ilosc = produkt.DostępnaIlosc();


            if (produkt != null && produkt.DostępnaIlosc() > 0)
            {
                koszyk.Add(produkt);
                produkt.DostępnaIlosc();
            }
        }

        public int ObliczCeneKoszyka()
        {
            int suma = 0;
            foreach (var produkt in koszyk)
            {
                suma += produkt.AktualnaCena();
            }
            return suma;
        }
    }
}