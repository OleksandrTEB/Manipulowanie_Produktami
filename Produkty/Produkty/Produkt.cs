namespace Produkty
{
    class Produkt
    {
        private string _nazwa;
        public string Nazwa
        {
            get { return _nazwa; }
            set
            {
                if (value == String.Empty)
                {
                    _nazwa = "Brak nazwy";
                    throw new ArgumentException("Nazwa nie może być pusta.");
                }
                else
                {
                    _nazwa = value;
                }
            }
        }
        private double _cena;
        public double Cena
        {
            get { return _cena; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cena nie może być ujemna.");
                }
                else
                {
                    _cena = value;
                }

            }
        }

        public int MinimalnyStan { get; set; }

        public string Kategoria;
        public int Ilosc;

        public double WartoscMagazynu
        {
            get { return Cena * Ilosc; }
        }

        public Produkt(string nazwa, double cena, string kategoria)
        {
            Nazwa = nazwa;
            Cena = cena;
            Kategoria = kategoria;
            //Ilosc = ilosc;
            Ilosc = 1;
            MinimalnyStan = 1;
        }

        public string ZwracaProdukt()
        {
            return $"Nazwa: {Nazwa,-25} | Cena: {Cena,10} |" +
                $"Kategoria: {Kategoria} | Ilość: {Ilosc,5} | Wartość: {WartoscMagazynu,10:F2}";
        }

        public static double ObliczWartoszMagazynu(Produkt[] produkty)
        {
            double suma = 0;
            foreach (Produkt produkt in produkty)
            {
                suma += produkt.WartoscMagazynu;
            }
            return suma;
        }

        public static double ObliczWartoszMagazynu(List<Produkt> produkty)
        {
            return produkty.Sum(p => p.WartoscMagazynu);
        }

        public bool CzyMoznaZamuwic()
        {
            return Ilosc > MinimalnyStan;
        }

        public void Sprzedaj()
        {
            if (CzyMoznaZamuwic())
            {
                Ilosc--;
                Console.WriteLine($"Sprzedano produkt: {Nazwa}, Pozostało: {Ilosc}");
            }
            else
            {
                Console.WriteLine($"Nie można sprzedać produktu: {Nazwa}, Niema na stanie");
            }
        }

        public static Produkt ZnajdzPoNazwie(Produkt[] produkty, string nazwa)
        {
            foreach (Produkt p in produkty)
            {
                if (p.Nazwa == nazwa)
                {
                    return p;
                }
            }
            return null;
        }

        public static Produkt ZnajdzPoNazwie(List<Produkt> produkty, string nazwa)
        {
            return produkty.FirstOrDefault(p => p.Nazwa.Contains(nazwa, StringComparison.OrdinalIgnoreCase));
        }
    }
}