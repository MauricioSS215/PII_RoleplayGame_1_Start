namespace Program;
using System;
using System.Collections.Generic;
public class Program 
{
    static void Main(string[] args)
    {
        // Crear ítems de ataque y defensa
        var pistolaDePerno1 = new PistolaDePerno("Pistola de Perno de 3 tiros",ataque:5,BalasIniciales:60);
        var hachaEnano = new HachaEnana(nombre: "Hacha doble pesada", ataque: 40,defensa:0);//enano
        var armaduraEnano = new ItemDeDefensaEnano(nombre: "Armadura de acero enana", defensa: 30);//enano
        var arma1 = new ItemDeAtaque("Espada", 25);
        var escudo1 = new ItemDeDefensa("Escudo de hierro", 20);
        var armadura1 = new ItemDeDefensa("Armadura de placas", 15);
        var arma2 = new ItemDeAtaque("Daga Oscura", 15);
        var escudo2 = new ItemDeDefensa("Escudo encantado", 15);
        var armadura2 = new ItemDeDefensa("Armadura del Norte", 30);
        var arco1 = new Arco("Flechas de hielo", 10, 15);

        var itemsArtoria = new List<Item> { arma1, escudo1, armadura1 };
        var itemsEvil = new List<Item> { arma2, escudo2, armadura2 };
        var itemsElfo = new List<Item> { arco1, escudo2, armadura2 };
        var itemsEnano = new List<ItemEnano> { hachaEnano, armaduraEnano };
        var enano = new Enano(nombre: "Karaz Ankor", itemsEnano, vida: 250, pistolaDePerno1,hachaEnano);//enano
        var hero = new Caballero("Artoria", itemsArtoria, 100);
        var enemigo = new Caballero("Evil", itemsEvil, 100);
        var elfo  = new Elfo("Legolas", itemsElfo, 120, arco1);
        
        //Mostramos el ataque y la defensa total del nuestro caballero Artoria.
        hero.GetAttackValue();
        hero.GetDefValue(); 
        Console.WriteLine("");

        // Muestra las estadisiticas actuales de los personajes
        hero.GetStats();
        enemigo.GetStats();
        elfo.GetStats();
        enano.GetStats();
        
        //Aplicamos metodos para mostrar su funcionamiento
        hero.DealDamage(enemigo);  // Caballero ataca a enemigo
        elfo.DealDamage(enemigo);
        elfo.DealDamage(enemigo); // Elfo ataca con arco 2 veces, la flechas bajar en 2 
        enano.AlternarArma();//enano alterna el arma entre la pistola de perno o el hacha
        enano.DealDamage(enemigo);// enano ataca a un enemigo
        
        //Mostramos nuevamente el status actual del enemigo, deberia tener menos vida
        enemigo.GetStats();
        //Por ultimo llamamos al metodo HealDamage y luego mostramos sus stats para ver que realmente se curo
        enemigo.HealDamage();
        enemigo.GetStats();
    }
}