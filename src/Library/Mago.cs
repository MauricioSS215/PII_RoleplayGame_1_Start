using System.ComponentModel;
using System.Runtime.InteropServices.Marshalling;

namespace Program;

public class Mago : Personaje 
{ 
    public Mago(string nombre, double vida, List<Item> listaItems) : base(nombre, listaItems, vida)
    {
        
    }

    public void AddHechizo(Hechizo hechizo)
    {
        Items.Add(hechizo);
    }
    public bool VerificarHechizo(Hechizo H)
    {
        foreach (Hechizo i in Items)
        {
            if (i.Equals(H))
            {
                return true; 
            }
        }
        return false;
    }
    public void UsarHechizo(Personaje personaje, Hechizo H)
    {
        foreach (Hechizo i in Items)
        {
            if (i.Equals(H))
            {
                personaje.VidaActual -= H.Ataque;
                personaje.VidaActual += H.Defensa;
            }
        }
    }
}

    