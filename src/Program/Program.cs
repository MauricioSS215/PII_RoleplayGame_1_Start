namespace Program;
using System;

public class Program
{
    static void Main(string[] args)
    {
        // Crear ítems de ataque y defensa
        // Crear ítems de ataque y defensa{
        var pistolaDePerno1 = new PistolaDePerno("Pistola de Perno de 3 tiros", ataque: 5, BalasIniciales: 60);
        var hachaEnano = new HachaEnana(nombre: "Hacha doble pesada", ataque: 40, defensa: 0); //enano
        var armaduraEnano = new ItemDeDefensaEnano(nombre: "Armadura de acero enana", defensa: 30); //enano
        var arma1 = new ItemDeAtaque("Espada", 25);
        var escudo1 = new ItemDeDefensa("Escudo de hierro", 20);
        var armadura1 = new ItemDeDefensa("Armadura de placas", 15);
        var arma2 = new ItemDeAtaque("Daga Oscura", 15);
        var escudo2 = new ItemDeDefensa("Escudo encantado", 15);
        var armadura2 = new ItemDeDefensa("Armadura del Norte", 30);
        var arco1 = new Arco("Flechas de hielo", 10, 15);
        var capaElfo = new CapaElfo("Capa magica", 10, 30);
        Baston baston1 = new Baston("Baston1", 0, 0);
        List<Item> Lista2 = new List<Item>();
        Mago MagoB = new Mago("MagoB", 100, new List<Item>());
        Mago MagoE = new Mago("MagoE", 150, Lista2);
        Hechizo Descarga = new Hechizo("Descarga", 10, 0, "Eléctrico");
        Hechizo Rayo = new Hechizo("Rayo", 100, 0, "Eléctrico");
        Hechizo Curacion = new Hechizo("Curacion", 0, 50, "Curar");
        MagoB.AddHechizo(Descarga);
        MagoB.AddHechizo(Rayo);
        MagoB.AddHechizo(Curacion);
        Lista2.Add(Descarga);
        Lista2.Add(Rayo);
        Lista2.Add(Curacion);
        MagoB.Baston = baston1;
        foreach (Hechizo i in MagoE.Items)
        {
            Console.WriteLine($"{i.Ataque}, {i.Defensa}");
        }

        var itemsEnano = new List<ItemEnano> { hachaEnano, armaduraEnano };
        var enano = new Enano(nombre: "Karaz Ankor", itemsEnano, vida: 250, pistolaDePerno1, hachaEnano); //enano
        var itemsArtoria = new List<Item> { arma1, escudo1, armadura1 };
        var itemsEvil = new List<Item> { arma2, escudo2, armadura2 };
        var itemsElfo = new List<Item> { arco1, escudo2, armadura2, capaElfo };
        var hero = new Caballero("Artoria", itemsArtoria, 100);
        var enemigo = new Caballero("Evil", itemsEvil, 100);
        var elfo = new Elfo("Legolas", itemsElfo, 120, arco1);


        //Mostramos el ataque y la defensa total del nuestro caballero Artoria.
        hero.GetAttackValue();
        hero.GetDefValue();
        Console.WriteLine("");
        foreach (Hechizo i in MagoB.Items)
        {
            Console.WriteLine($"{i.Ataque}, {i.Defensa}");
        }

        // Muestra las estadisiticas actuales de los personajes
        hero.GetStats();
        enemigo.GetStats();
        elfo.GetStats();
        enano.GetStats();

        //Aplicamos metodos para mostrar su funcionamiento
        hero.DealDamage(enemigo); // Caballero ataca a enemigo
        elfo.DealDamage(enemigo);
        elfo.DealDamage(enemigo); // Elfo ataca con arco 2 veces, la flechas bajar en 2 

        enano.AlternarArma(); //enano alterna el arma entre la pistola de perno o el hacha
        enano.DealDamage(enemigo); // enano ataca a un enemigo
        enano.AlternarArma(); //cambia de arma para atacar con el hacha/pistola
        enano.DealDamage(enemigo); //ataca con el

        //Mostramos nuevamente el status actual del enemigo, deberia tener menos vida
        enemigo.GetStats();

        //Por ultimo llamamos al metodo HealDamage y luego mostramos sus stats para ver que realmente se curo
        enemigo.HealDamage();
        enemigo.GetStats();
    }
}