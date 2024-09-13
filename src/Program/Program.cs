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
        Console.WriteLine($"El mago {MagoB.Nombre} usó el hechizo {MagoB.UsarHechizo(Rayo, LibroH)}");
        Console.WriteLine($"El mago {MagoE.Nombre} usó el hechizo {MagoE.UsarHechizo(Descarga, LibroH)}");
        Console.WriteLine($"La vida actual del mago {MagoE.Nombre} es de {MagoE.VidaActual}");
        MagoB.Atacar(LibroH, MagoE, Descarga);
        Console.WriteLine($"La vida actual del mago {MagoE.Nombre} es de {MagoE.VidaActual}");
    }
}