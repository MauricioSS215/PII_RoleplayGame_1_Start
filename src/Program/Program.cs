namespace Program;
using System;

public class Program 
{
    public static void Main(string[] args)
    {
        List<Item> Lista2 = new List<Item>();
        Mago MagoB = new Mago("MagoB", 100, new List<Item>());
        Mago MagoE = new Mago("MagoE", 150, new List<Item>());
        Hechizo Descarga = new Hechizo("Descarga", 10, 0, "Eléctrico");
        Hechizo Rayo = new Hechizo("Rayo", 100, 0, "Eléctrico");
        Hechizo Curacion = new Hechizo("Curacion", 0, 50, "Curar");
        MagoB.AddHechizo(Descarga);
        MagoB.AddHechizo(Rayo);
        MagoB.AddHechizo(Curacion);
        Lista2.Add(Rayo);
        Console.WriteLine($"La vida del mago es de {MagoB.VidaActual}");
        Console.WriteLine($"Los hechizos son {Rayo.Nombre}, {Curacion.Nombre}");
        Console.WriteLine($"¿El mago {MagoB.Nombre} tiene el hechizo {Rayo.Nombre}? {MagoB.VerificarHechizo(Rayo)}");
        Console.WriteLine($"La vida actual del mago {MagoE.Nombre} es de {MagoE.VidaActual}");
        MagoB.HechizosEnLibro();
        MagoB.CambiarLibro(Lista2);
        Console.WriteLine($"{MagoB.VerificarHechizo(Descarga)}");
        MagoB.HechizosEnLibro();
        MagoB.UsarHechizo(MagoE, Rayo);
        Console.WriteLine($"La vida del magoE es: {MagoE.VidaActual}");

    }

}

