namespace Program;

public class Caballero : Personaje
{
    public double Armadura { get; set; }
    public Caballero(string nombre, ItemDeAtaque arma, ItemDeDefensa escudo, double vida, double armadura)
        : base(nombre, arma, escudo, vida)
    {
        Armadura = armadura;
    }
}

public override void Atacar()
{
    Console.WriteLine($"{Nombre} ataca con su {Arma}.");
}