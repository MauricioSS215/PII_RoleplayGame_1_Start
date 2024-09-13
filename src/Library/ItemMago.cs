using System;
using System.Collections;
using System.Collections.Generic;
namespace Program;

public class Hechizo : Item
{
    public string TipoHechizo { get; set; }

    public Hechizo(string nombre, double Ataque, double Defensa, string tipoHechizo) : base(nombre, Ataque, Defensa)
    {
        TipoHechizo = tipoHechizo;
    }
    
}

public class LibroHechizo : Item, IEnumerable<Hechizo>
{
    public List<Hechizo> Libro = new List<Hechizo>();

    public LibroHechizo(string nombre, double Ataque, double Defensa):base(nombre, Ataque, Defensa)
    {
        this.Libro = new List<Hechizo>();
    }

    public void AddHechizos(Hechizo hechizo)
    {
        if (!Libro.Contains(hechizo))
        {
            Libro.Add(hechizo);
        }
    }
    public IEnumerator<Hechizo> GetEnumerator()
    {
        return Libro.GetEnumerator();
    }

    // Implementar GetEnumerator para IEnumerable (requerido por la interfaz)
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}