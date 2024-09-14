namespace Program;
using System;

public class Program 
{
    public static void Main(string[] args)
    {
        
        Mago MagoB = new Mago("MagoB", 100, new List<Item>());
        Mago MagoE = new Mago("MagoE", 150, new List<Item>());
        Hechizo Descarga = new Hechizo("Descarga", 10, 0, "Electrico");
        Hechizo Rayo = new Hechizo("Rayo", 100, 0, "Eléctrico");
        Hechizo Curacion = new Hechizo("Curacion", 0, 50, "Curar");
        MagoB.AddHechizo(Descarga);
        MagoB.AddHechizo(Rayo);
        MagoB.AddHechizo(Curacion);
        Console.WriteLine($"La vida del mago es de {MagoB.VidaActual}");
        Console.WriteLine($"Los hechizos son {Rayo.Nombre}, {Curacion.Nombre}");
        Console.WriteLine($"¿El mago {MagoB.Nombre} tiene el hechizo {Rayo.Nombre}? {MagoB.VerificarHechizo(Rayo)}");
        Console.WriteLine($"¿El mago {MagoE.Nombre} tiene el hechizo {Descarga.Nombre}? {MagoE.VerificarHechizo(Descarga)}");
        Console.WriteLine($"La vida actual del mago {MagoE.Nombre} es de {MagoE.VidaActual}");
        MagoB.UsarHechizo(MagoE, Rayo);
        Console.WriteLine($"La vida actual del mago {MagoE.Nombre} es de {MagoE.VidaActual}");
        MagoB.UsarHechizo(MagoE, Curacion);
        Console.WriteLine($"La vida actual del mago {MagoE.Nombre} es de {MagoE.VidaActual}");
        Console.WriteLine(MagoE.GetAttackValue());
    }

}

