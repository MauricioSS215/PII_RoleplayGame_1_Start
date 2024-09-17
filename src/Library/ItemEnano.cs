namespace Program;
using System;

// Clase que sera usada como base para los Items
//La letra del ejercicio pedia que cada personaje tuviera al menos 2 items
public abstract class ItemEnano
{
    public string Nombre { get; set; }
    public double Ataque { get; set; }
    public double Defensa { get; set; }

    public ItemEnano(string nombre, double ataque, double defensa)
    {
        Nombre = nombre;
        Ataque = ataque;
        Defensa = defensa;
    }
}

// Subclase para ítems de ataque
//Se creo para diferenciar los items de ataque y defensa
public class ItemDeAtaqueEnano :ItemEnano
{
    public ItemDeAtaqueEnano(string nombre, double ataque) : base(nombre, ataque, 0)
    {
        if (ataque <= 0)
            throw new ArgumentException("Un ítem de ataque debe tener un valor de ataque mayor que 0.");
    }
}

// Subclase para ítems de defensa
//Se creo para diferenciar los items de ataque y defensa
public class ItemDeDefensaEnano : ItemEnano
{
    public ItemDeDefensaEnano(string nombre, double defensa) : base(nombre, 0, defensa)
    {
        if (defensa <= 0)
            throw new ArgumentException("Un ítem de defensa debe tener un valor de defensa mayor que 0.");
    }
}

public class HachaEnana : ItemDeAtaqueEnano
{
    public HachaEnana(string nombre, double ataque, double defensa) : base(nombre, ataque)
    {
        
    }
}

public class PistolaDePerno : ItemDeAtaqueEnano
{
    public int BalasIniciales { get; set; }
    public int BalasDisponibles { get; set; }
    
    public PistolaDePerno(string nombre, double ataque, int BalasIniciales): base(nombre, ataque)
    {
        //BalaMunicion = 60;   //municion, usaria 3 balas por cargador,20 cargadores en total
        BalasIniciales = BalasIniciales;
        BalasDisponibles = BalasIniciales;
    }
    // Disminuir el número de flechas disponibles
    public void DisminuirBalas()
    {
        if (BalasDisponibles > 0)
        {
            BalasDisponibles--;
        }
        else
        {
            Console.WriteLine("No queda municion.");
        }
    }
}

