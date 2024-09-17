using System.ComponentModel;
using System.Runtime.InteropServices.Marshalling;

namespace Program;

public class Mago : Personaje
{
    private Baston? baston;
    public Baston? Baston
    {
        get { return baston; }
        set
        {
            if (value != null)
            {
                foreach (Hechizo i in Items)
                {
                    i.Ataque *= 1.5;
                    i.Defensa *= 1.5;
                }
            }
            else if (baston != null)
            {
                foreach (Hechizo i in Items)
                {
                    i.Ataque /= 1.5;
                    i.Defensa /= 1.5;
                }
            }
            baston = value;
        }
    }
    public Mago(string nombre, double vida, List<Item> listaItems) : base(nombre, listaItems, vida)
    { 
        
    }

    public void AddHechizo(Hechizo hechizo)
    {
        Items.Add(hechizo);
        if (baston != null)
        {
            hechizo.Ataque *= 1.5;
            hechizo.Defensa*=1.5;
        }
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

    public void CambiarBaston(Baston Bastonnuevo)
    {
        baston = Bastonnuevo;
    }
}

    