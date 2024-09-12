namespace Program;
using System;

public class Program 
{
    static void Main(string[] args)
    {
        // Crear ítems de ataque y defensa
        ItemDeAtaque espada = new ItemDeAtaque("Espada Larga", 50);
        ItemDeDefensa escudo = new ItemDeDefensa("Escudo de Hierro", 30);

        // Crear personaje con los ítems
        Personaje hero = new Caballero("Meliodas", espada, escudo,100,50);
        Personaje enemigo = new Caballero("Evil", new ItemDeAtaque("Hacha", 40), new ItemDeDefensa("Escudo de madera", 20),80,50);
        //Se muestran las dos formas de inicializar los items
        
        hero.GetAttackValue();
        hero.GetDefValue(); 
        Console.WriteLine("");

        // Muestra las estadisiticas actuales del caballero
        hero.GetStats();
        Console.WriteLine("");
        Console.WriteLine("");
        enemigo.GetStats();
        Console.WriteLine("");
        hero.DealDamage(enemigo);  // Caballero ataca a enemigo
        Console.WriteLine("");
        enemigo.GetStats();
        Console.WriteLine("");
        enemigo.HealDamage();
        Console.WriteLine("");
        enemigo.GetStats();

    }
}