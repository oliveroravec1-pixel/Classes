class Program
{ 
    static void Main(string[] args)
    {
        Console.WriteLine("Morituri te salutant.");
        Hrdina nasPrvyHrdina = new Hrdina();
        nasPrvyHrdina.Meno = "Superman";
        nasPrvyHrdina.Zdravie = 50;
        nasPrvyHrdina.Energia = 150;
        Hrdina nasDruhyHrdina = new Hrdina();
        nasDruhyHrdina.Meno = "Batman";
        nasDruhyHrdina.Zdravie = 45;
        nasDruhyHrdina.Energia = 100;
        Random randomizer = new Random();
        while (nasPrvyHrdina.Zdravie > 0 && nasDruhyHrdina.Zdravie > 0)
        {
            nasPrvyHrdina.Regeneruj();
            nasDruhyHrdina.Regeneruj();
            int silaUtoku = randomizer.Next(10, 31);
            if (nasPrvyHrdina.Utok(silaUtoku))
            {
                Console.WriteLine("Hrdina zaútočil!");
                nasDruhyHrdina.PrijmiZranenie(silaUtoku);
            }
            else
            {
                Console.WriteLine("Hrdina musí oddychovať.");
            }
            silaUtoku = randomizer.Next(10, 31);
            if (nasDruhyHrdina.Utok(silaUtoku))
            {
                Console.WriteLine("Hrdina zaútočil!");
                nasPrvyHrdina.PrijmiZranenie(silaUtoku);
            }
            else
            {
                Console.WriteLine("Hrdina musí oddychovať.");
            }
        }
        nasPrvyHrdina.VypisAktualnyStav();
        nasDruhyHrdina.VypisAktualnyStav();
        if (nasPrvyHrdina.Zdravie == 0 && nasDruhyHrdina.Zdravie == 0)
        {
            Console.WriteLine("Remíza!");
        }
        else if (nasPrvyHrdina.Zdravie == 0)
        {
            Console.WriteLine($"Vyhral {nasDruhyHrdina.Meno}!");
        }
        else
        {
            Console.WriteLine($"Vyhral {nasPrvyHrdina.Meno}!");
        }
        Ucet nasPrvyUcet = new Ucet();
        nasPrvyUcet.Cislo = "SK0001";
        nasPrvyUcet.Majitel = "Jožko";
        nasPrvyUcet.Zostatok = 500;
        Ucet nasDruhyUcet = new Ucet();
        nasDruhyUcet.Cislo = "SK0002";
        nasDruhyUcet.Majitel = "Fero";
        nasDruhyUcet.Zostatok = 100;
        nasPrvyUcet.VlozPeniaze(200);
        nasPrvyUcet.VypisAktualnyStav();
        nasPrvyUcet.VlozPeniaze(-50);
        nasPrvyUcet.VypisAktualnyStav();
        if (nasPrvyUcet.VyberPeniaze(300))
        {
            Console.WriteLine("Výber úspešný.");
        }
        else
        {
            Console.WriteLine("Nedostatok prostriedkov.");
        }
        nasPrvyUcet.VypisAktualnyStav();
        nasDruhyUcet.VlozPeniaze(50);
        nasDruhyUcet.VypisAktualnyStav();
        if (nasDruhyUcet.VyberPeniaze(1000))
        {
            Console.WriteLine("Výber úspešný.");
        }
        else
        {
            Console.WriteLine("Nedostatok prostriedkov.");
        }
        nasDruhyUcet.VypisAktualnyStav();
        if (nasDruhyUcet.VyberPeniaze(-20))
        {
            Console.WriteLine("Výber úspešný.");
        }
        else
        {
            Console.WriteLine("Zápornú sumu nie je možné vybrať.");
        }
        nasDruhyUcet.VypisAktualnyStav();
        nasPrvyUcet.PosliPeniaze(200, nasDruhyUcet);
        nasPrvyUcet.VypisAktualnyStav();
        nasDruhyUcet.VypisAktualnyStav();
        nasDruhyUcet.PosliPeniaze(1000, nasPrvyUcet);
        nasPrvyUcet.VypisAktualnyStav();
        nasDruhyUcet.VypisAktualnyStav();
        Datum prvyDatum = new Datum();
        prvyDatum. Den = 15;
        prvyDatum.Mesiac = 3;
        prvyDatum.Rok = 2024;
        Datum druhyDatum = new Datum();
        druhyDatum.Den = 2;
        druhyDatum.Mesiac = 11;
        druhyDatum.Rok = 2023;
        prvyDatum.Porovnaj(druhyDatum);
        prvyDatum.Porovnaj(prvyDatum);
    }
}
class Hrdina
{
    public string Meno = "";
    public int Zdravie = 100;
    public int Energia = 50;
    public bool Utok(int cenaUtoku)
    {
        if (Energia < cenaUtoku)
        {
            return false;
        }
        else
        {
            Energia = Energia - cenaUtoku;
            return true;
        }
    }
    public int PrijmiZranenie(int sila)
    {
        Zdravie = Zdravie - sila;
        if (Zdravie < 0)
        {
            Zdravie = 0;
        }
        return Zdravie;
    }
    public void Regeneruj()
    {
        Energia = Energia + 5;
    }
    public void VypisAktualnyStav()
    {
        Console.WriteLine($"Meno: {Meno}");
        Console.WriteLine($"Zdravie: {Zdravie}");
        Console.WriteLine($"Energia: {Energia}");
    }
}
class Ucet
{
    public string Cislo = "";
    public decimal Zostatok = 0;
    public string Majitel = "";
    public decimal VlozPeniaze(decimal suma)
    {
        if (suma < 0)
        {
            return Zostatok;
        }
        Zostatok = Zostatok + suma;
        return Zostatok;
    }
    public bool VyberPeniaze(decimal suma)
    {
        if (suma < 0 || Zostatok < suma)
        {
            return false;
        }
        else
        {
            Zostatok = Zostatok - suma;
            return true;
        }
    }
    public void PosliPeniaze(decimal suma, Ucet cielovyUcet)
    {
        if (VyberPeniaze(suma))
        {
            cielovyUcet.VlozPeniaze(suma);
        }
    }
    public void VypisAktualnyStav()
    {
        Console.WriteLine($"Číslo účtu: {Cislo}");
        Console.WriteLine($"Majiteľ: {Majitel}");
        Console.WriteLine($"Zostatok: {Zostatok}");
    }
}
class Datum
{
    public int Den = 1;
    public int Mesiac = 1;
    public int Rok = 2000;
    public void Porovnaj(Datum inyDatum)
    {
        if (Rok < inyDatum. Rok)
        {
            Console.WriteLine("Prvý dátum je skôr.");
        }
        else if (Rok > inyDatum.Rok)
        {
            Console.WriteLine("Druhý dátum je skôr.");
        }
        else if (Mesiac < inyDatum.Mesiac)
        {
            Console.WriteLine("Prvý dátum je skôr.");
        }
        else if (Mesiac > inyDatum.Mesiac)
        {
            Console.WriteLine("Druhý dátum je skôr.");
        }
        else if (Den < inyDatum.Den)
        {
            Console.WriteLine("Prvý dátum je skôr.");
        }
        else if (Den > inyDatum.Den)
        {
            Console.WriteLine("Druhý dátum je skôr.");
        }
        else
        {
            Console.WriteLine("Dátumy sú rovnaké.");
        }
    }
}