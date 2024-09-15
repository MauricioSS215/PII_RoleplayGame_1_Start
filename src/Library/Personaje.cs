namespace Program;
using System;
using System.Collections;
using System.Collections.Generic;

// Ejemplo de uso en un personaje
public abstract class Personaje
{
    public string Nombre { get; set; }
    public double VidaMax { get; set; }
    public double VidaActual { get; set; }
    //public ItemDeAtaque Arma { get; set; }
    //public ItemDeDefensa Escudo { get; set; }
    public List<Item> Items { get; set; }  // Lista de ítems

    public Personaje(string nombre, List<Item> items, double vida)
    {
        Nombre = nombre;
        Items = items;
        //Arma = arma;
        //Escudo = escudo;
        VidaMax = vida;
        VidaActual = vida; //Al comenzar, la vidaActual y la maxima seran iguales
    }
    
    public double GetAttackValue()
    {
        double totalAtaque = 0;
        foreach (var item in Items)
        {
            if (item is ItemDeAtaque)
            {
                totalAtaque += item.Ataque;
            }
        }
        return totalAtaque;
    }
    
    public double GetDefValue()
    {
       double totalDefensa = 0;
       foreach (var item in Items)
       {
            if (item is ItemDeDefensa)
            {
                totalDefensa += item.Defensa;
            }
       }
       return totalDefensa;
    }
    public virtual double DealDamage(Personaje enemigo)//Sirve para atacar otro Personaje
    {
        double damage = GetAttackValue();
        double realDamage = damage*(1-( enemigo.GetDefValue() /100));//Se inmplemento que la defensa disminuye el valor del ataque en un porcentaje
        //Por ejemplo:Si la defensa es 20, el valor del ataque se vera disminuido en %20.
        enemigo.VidaActual = enemigo.VidaActual - realDamage;
        Console.WriteLine($"{Nombre} ha atacado a {enemigo.Nombre} y le ha hecho {realDamage} de daño.");
        Console.WriteLine($"La vida restante de {enemigo.Nombre} es {enemigo.VidaActual}.");
        Console.WriteLine("");
        return enemigo.VidaActual;
    }

    public void HealDamage()
    {
        if (this.VidaActual < VidaMax)
        {
            this.VidaActual = VidaMax;
        }
        Console.WriteLine($"El caballero {Nombre} ha sido curado, su vida actual es {VidaActual}");
    }
    public virtual void GetStats()
    {
        Console.WriteLine($"{Nombre} tiene los siguientes stats:\n \nNivel de vida: {VidaActual}");
        foreach (var item in Items)
        {
            Console.WriteLine($"{item.Nombre} - Ataque: {item.Ataque}, Defensa: {item.Defensa}");
        }
        Console.WriteLine("");
    }
}

public class Elfo : Personaje
{
    public Arco ArcoElfo { get; set; }
    public Elfo(string nombre, List<Item> items, double vida, Arco arcoElfo)
        : base(nombre, items, vida)
    {
        ArcoElfo = arcoElfo;
    }

    // Sobrescribe el método DealDamage para manejar el caso del arco
    public override double DealDamage(Personaje enemigo)
    {
        if (ArcoElfo != null && ArcoElfo.FlechasDisponibles > 0)
        {
            ArcoElfo.DisminuirFlechas();  // Disminuir el número de flechas
            double damage = GetAttackValue();  // Obtener el valor de ataque del elfo
            double realDamage = damage * (1 - (enemigo.GetDefValue() / 100));  // Calcular el daño real, teniendo en cuenta la defensa del enemigo
            enemigo.VidaActual = enemigo.VidaActual - realDamage;  // Aplicar el daño al enemigo

            // Mensajes en consola sobre el ataque y el estado actual
            Console.WriteLine($"{Nombre} ha disparado una flecha a {enemigo.Nombre} y le ha hecho {realDamage} de daño.");
            Console.WriteLine($"La vida restante de {enemigo.Nombre} es {enemigo.VidaActual}.");
            Console.WriteLine($"Flechas restantes: {ArcoElfo.FlechasDisponibles}");
        }
        else
        {
            Console.WriteLine("No hay flechas disponibles para atacar.");
        }
        Console.WriteLine("");
        return enemigo.VidaActual;  // Retornar la vida actual del enemigo después del ataque
    }

    public override void GetStats()
    {
        Console.WriteLine($"{Nombre} tiene los siguientes stats:\n \nNivel de vida: {VidaActual}");
        foreach (var item in Items)
        {
            Console.WriteLine($"{item.Nombre} - Ataque: {item.Ataque}, Defensa: {item.Defensa}");
        }
        Console.WriteLine($"Le quedan {ArcoElfo.FlechasDisponibles} flechas disponibles");
        Console.WriteLine("");
    }
}