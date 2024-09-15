using System.ComponentModel;
using System.Runtime.InteropServices.Marshalling;

namespace Program;

public class Mago : Personaje 
{ 
    public Baston? Baston { get; set; }
    public Mago(string nombre, double vida, List<Item> listaItems) : base(nombre, listaItems, vida)
    { 
        
    }

    public void AddHechizo(Hechizo hechizo)
    {
        Items.Add(hechizo);
    }
    public void CambiarLibro (List<Item> ListaNueva)
    {
        Items = ListaNueva;
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

    public void HechizosEnLibro()
    {
        foreach (Hechizo hechizo in Items)
        {
            Console.WriteLine(hechizo.Nombre);
        }
    }

    public void BastonUso()
    {
        if (Baston != null)
        {
            foreach (Hechizo i in Items)
            {
                i.Ataque *= 1.5;
                i.Defensa *= 1.5;
            }
        }
    }
}

    