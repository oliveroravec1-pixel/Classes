class Program
{
    static void Main(string[] args)
    {
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
    public void VypisAktualnyStav()
    {
        Console.WriteLine($"Číslo účtu: {Cislo}");
        Console.WriteLine($"Majiteľ: {Majitel}");
        Console.WriteLine($"Zostatok: {Zostatok}");
    }
}