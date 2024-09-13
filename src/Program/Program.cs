namespace Program;
using System;

public class Program 
{
    public static void Main(string[] args)
    {
        LibroHechizo LibroH = new LibroHechizo("Libro1", 0, 0);
        Mago MagoB = new Mago("MagoB", new ItemDeAtaque("espada?", 10), new ItemDeDefensa("escudo?", 10), 100, LibroH);
        Mago MagoE = new Mago("MagoE", new ItemDeAtaque("espada?", 10), new ItemDeDefensa("escudo?", 10), 150, LibroH);
        Hechizo Descarga = new Hechizo("Descarga", 10, 0, "Electrico");
        Hechizo Rayo = new Hechizo("Rayo", 100, 0, "Eléctrico");
        Hechizo Curacion = new Hechizo("Curacion", 0, 50, "Curar");
        LibroH.AddHechizos(Rayo);
        LibroH.AddHechizos(Curacion);
        LibroH.AddHechizos((Descarga));
        Console.WriteLine($"La vida del mago es de {MagoB.VidaActual}");
        Console.WriteLine($"Los hechizos son {Rayo.Nombre}, {Curacion.Nombre}");
        foreach (Hechizo hechizo in LibroH)
        {
            Console.WriteLine(hechizo.Nombre);
        }
        Console.WriteLine($"¿El mago {MagoB.Nombre} tiene el hechizo {Rayo.Nombre}? {MagoB.VerificarHechizo(Rayo, LibroH)}");
        Console.WriteLine($"¿El mago {MagoE.Nombre} tiene el hechizo {Descarga.Nombre}? {MagoE.VerificarHechizo(Descarga, LibroH)}");
        Console.WriteLine($"La vida actual del mago {MagoE.Nombre} es de {MagoE.VidaActual}");
        MagoB.UsarHechizo(LibroH, MagoE, Rayo);
        Console.WriteLine($"La vida actual del mago {MagoE.Nombre} es de {MagoE.VidaActual}");
        MagoB.UsarHechizo(LibroH, MagoE, Curacion);
        Console.WriteLine($"La vida actual del mago {MagoE.Nombre} es de {MagoE.VidaActual}");
        Console.WriteLine(MagoE.GetAttackValue());
    }
}