namespace Program;

public class Arco : ItemDeAtaque
{
    public int FlechasIniciales { get; set; }
    public int FlechasDisponibles { get; set; }

    public Arco(string nombre, double ataque, int flechasIniciales) 
        : base(nombre, ataque)
    {
        FlechasIniciales = flechasIniciales;
        FlechasDisponibles = flechasIniciales;
    }

    // Disminuir el número de flechas disponibles
    public void DisminuirFlechas()
    {
        if (FlechasDisponibles > 0)
        {
            FlechasDisponibles--;
        }
        else
        {
            Console.WriteLine("No quedan flechas disponibles.");
        }
    }
}

public class CapaElfo : ItemDeDefensa
{
    public double BonusDefensa { get; set; }
    public CapaElfo(string nombre, double defensa, double bonusDefensa)
        : base(nombre, defensa)
    {
        BonusDefensa = bonusDefensa;
    }
}
