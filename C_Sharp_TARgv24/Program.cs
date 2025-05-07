public interface ITööline
{
    double ArvutaPalk();
}
// Добавляем базовый класс Inimene
public class Inimene
{
    public string Nimi { get; set; }
    public int Vanus { get; set; }
}


public class Tootaja : Inimene, ITööline
{
    public double Tunnitasu;
    public int Tunnid;

    public double ArvutaPalk()
    {
        return Tunnitasu * Tunnid;
    }

    public override string ToString()
    {
        return $"{Nimi}, Vanus: {Vanus}, Palk: {ArvutaPalk()}";
    }
}
    
public class Pank
{
    private double saldo;

    public double Saldo
    {
        get { return saldo; }
        set
        {
            if (value >= 0)
                saldo = value;
        }
    }
}
public interface IHeliline
{
    void TeeHääl();
}
public class Kass : IHeliline
{
    public void TeeHääl()
    {
        Console.WriteLine("Mjäu!");
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        Pank pank = new Pank();
        pank.Saldo = 100;
        Console.WriteLine("Saldo: " + pank.Saldo);

        Kass kass = new Kass();
        kass.TeeHääl(); // Выведет "Mjäu!"

        Tootaja tootaja = new Tootaja
        {
            Nimi = "Mari",
            Vanus = 25,
            Tunnitasu = 10.5,
            Tunnid = 40
        };

        Console.WriteLine(tootaja); // вызовет ToString()
    }
}

