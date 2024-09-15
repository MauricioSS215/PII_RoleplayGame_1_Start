namespace Program;
using System;

public class Program 
{
    public static void Main(string[] args)
    {
        Baston baston1 = new Baston("Baston1", 0, 0);
        List<Item> Lista2 = new List<Item>();
        Mago MagoB = new Mago("MagoB", 100, new List<Item>());
        Mago MagoE = new Mago("MagoE", 150, Lista2);
        Hechizo Descarga = new Hechizo("Descarga", 10, 0, "Eléctrico");
        Hechizo Rayo = new Hechizo("Rayo", 100, 0, "Eléctrico");
        Hechizo Curacion = new Hechizo("Curacion", 0, 50, "Curar");
        MagoB.AddHechizo(Descarga);
        MagoB.AddHechizo(Rayo);
        MagoB.AddHechizo(Curacion);
        Lista2.Add(Descarga);
        Lista2.Add(Rayo);
        Lista2.Add(Curacion);
        MagoB.Baston = baston1;
        foreach (Hechizo i in MagoE.Items)
        {
            Console.WriteLine($"{i.Ataque}, {i.Defensa}");
        }
        
        foreach (Hechizo i in MagoB.Items)
        {
            Console.WriteLine($"{i.Ataque}, {i.Defensa}");
        }
    }

}

