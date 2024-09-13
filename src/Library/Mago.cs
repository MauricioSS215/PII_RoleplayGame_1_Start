using System.Runtime.InteropServices.Marshalling;

namespace Program;

public class Mago : Personaje 
{
    public LibroHechizo Librohechizo { get; set; }

    public Mago(string nombre, ItemDeAtaque arma, ItemDeDefensa escudo, double vida, LibroHechizo librohechizo) : base(nombre, arma, escudo, vida)
    {
        Librohechizo = librohechizo;
    }
    public bool VerificarHechizo(Hechizo H, LibroHechizo Libro)
    {
        foreach (Hechizo i in Libro)
        {
            if (i.Equals(H))
            {
                return true; 
            }
        }
        return false;
    }
    public void UsarHechizo(LibroHechizo Libro, Personaje personaje, Hechizo H)
    {
        foreach (Hechizo i in Libro)
        {
            if (i.Equals(H))
            {
                personaje.VidaActual -= H.Ataque;
                personaje.VidaActual += H.Defensa;
            }
        }
    }
}

    