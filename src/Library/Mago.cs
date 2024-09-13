using System.Runtime.InteropServices.Marshalling;

namespace Program;

public class Mago : Personaje 
{
    public LibroHechizo Librohechizo { get; set; }

    public Mago(string nombre, ItemDeAtaque arma, ItemDeDefensa escudo, double vida, LibroHechizo librohechizo) : base(nombre, arma, escudo, vida)
    {
        Librohechizo = librohechizo;
    }
    public string UsarHechizo(Hechizo H, LibroHechizo Libro)
    {
        foreach (Hechizo i in Libro)
        {
            if (i.Equals(H))
            {
                return i.Nombre; 
            }
        }

        return null;
    }
    public void Atacar(LibroHechizo Libro, Mago MagoR, Hechizo H)
    {
        foreach (Hechizo i in Libro)
        {
            if (i.Equals(H))
            {
                MagoR.VidaActual -= H.Ataque;
            }
        }
    }
}

    