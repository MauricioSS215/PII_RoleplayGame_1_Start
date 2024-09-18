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
public class Baston : Item
{
    public Baston(string nombre, double Ataque, double Defensa) : base(nombre, Ataque, Defensa)
    {
        
    }
}