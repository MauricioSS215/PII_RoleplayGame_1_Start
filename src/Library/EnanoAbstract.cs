﻿namespace Program;
using System;
using System.Collections.Generic;
public abstract class EnanoPersonaje
{
    public string Nombre { get; set; }
    public double VidaMax { get; set; }
    public double VidaActual { get; set; }
    //public ItemDeAtaque Arma { get; set; }
    //public ItemDeDefensa Escudo { get; set; }
    
    public List<ItemEnano> ItemsEnanos { get; set; }  // Lista de ítems

    public EnanoPersonaje(string nombre, List<ItemEnano> itemsEnanos, double vida)
    {
        Nombre = nombre;
        ItemsEnanos = itemsEnanos;
        //Arma = arma;
        //Escudo = escudo;
        VidaMax = vida;
        VidaActual = vida; //Al comenzar, la vidaActual y la maxima seran iguales
    }
    
    public double GetAttackValue()
    {
        double totalAtaque = 0;
        foreach (var item in ItemsEnanos)
        {
            if (item is ItemDeAtaqueEnano)
            {
                totalAtaque += item.Ataque;
            }
        }
        return totalAtaque;
    }
    
    public double GetDefValue()
    {
       double totalDefensa = 0;
       foreach (var item in ItemsEnanos)
       {
            if (item is ItemDeDefensaEnano)
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
        Console.WriteLine($"El Enano {Nombre} ha sido curado, su vida actual es {VidaActual}");
    }
    public virtual void GetStats()
    {
        Console.WriteLine($"{Nombre} tiene los siguientes stats:\n \nNivel de vida: {VidaActual}");
        foreach (var itemEnano in ItemsEnanos)
        {
            Console.WriteLine($"{itemEnano.Nombre} - Ataque: {itemEnano.Ataque}, Defensa: {itemEnano.Defensa}");
        }
        Console.WriteLine("");
    }
}


public partial class Enano
{
    public override double DealDamage(Personaje enemigo)
    {
        if (usandoPistola && PistolaDePerno != null && PistolaDePerno.BalasDisponibles > 0)
        {
            // Si estamos usando la pistola, ejecutamos el código para disparar 3 balas
            int balasDisparadas = 3;
            int balasAcertadas = 0;
            double probabilidadDeFallo = 0.3; // 30% de fallar cada disparo
            Random rand = new Random();
            
            for (int i = 0; i < balasDisparadas; i++)
            {
                if (rand.NextDouble() > probabilidadDeFallo)
                {
                    balasAcertadas++;
                    double damage = GetAttackValue();  // Obtener el valor de ataque del enano
                    enemigo.VidaActual -= damage; // Ignora la defensa

                    Console.WriteLine($"{Nombre} ha disparado una bala y acertado en {enemigo.Nombre}, haciendo {damage - enemigo.GetDefValue()} de daño");
                }
                else
                {
                    Console.WriteLine($"{Nombre} ha disparado una bala y ha fallado.");
                }
                PistolaDePerno.DisminuirBalas(); // Disminuir balas tras cada disparo
            }

            Console.WriteLine($"Se dispararon {balasDisparadas}, de las cuales {balasAcertadas} acertaron en {enemigo.Nombre}.");
            Console.WriteLine($"Municion restantes: {PistolaDePerno.BalasDisponibles}");
        }
        else if (!usandoPistola && HachaEnana != null)
        {
            // Si estamos usando el hacha
            double damage = HachaEnana.Ataque;  // Obtener el valor de daño del hacha
            enemigo.VidaActual -= damage - enemigo.GetDefValue();  // Aplicar el daño considerando la defensa del enemigo

            Console.WriteLine($"{Nombre} ha atacado con su hacha a {enemigo.Nombre}, causando {damage - enemigo.GetDefValue()} de daño.");
        }
        else
        {
            Console.WriteLine($"{Nombre} no tiene un arma disponible para atacar.");
        }

        return enemigo.VidaActual;  // Retornar la vida actual del enemigo
    }

    public override void GetStats()
    {
        Console.WriteLine($"{Nombre} tiene los siguientes stats:\n \nNivel de vida: {VidaActual}");
        foreach (var item in ItemsEnanos)
        {
            Console.WriteLine($"{item.Nombre} - Ataque: {item.Ataque}, Defensa: {item.Defensa}");
        }
        Console.WriteLine($"Municion restante: {PistolaDePerno.BalasDisponibles}");
        Console.WriteLine("");
    }
}