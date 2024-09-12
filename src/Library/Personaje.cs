namespace Program;

using System;

// Ejemplo de uso en un personaje
public abstract class Personaje
{
    public string Nombre { get; set; }
    public double VidaMax { get; set; }
    public double VidaActual { get; set; }
    public ItemDeAtaque Arma { get; set; }
    public ItemDeDefensa Escudo { get; set; }

    public Personaje(string nombre, ItemDeAtaque arma, ItemDeDefensa escudo, double vida)
    {
        Nombre = nombre;
        Arma = arma;
        Escudo = escudo;
        VidaMax = vida;
        VidaActual = vida; //Al comenzar, la vidaActual y la maxima seran iguales
    }
    
    public double GetAttackValue()
    {
        Console.WriteLine($"El valor de ataque de {Nombre} es de {Arma.Ataque}.");
        return Arma.Ataque; //Retorna el valor(double) del atributo del objeto itemDeAtaque
    }
    
    public double GetDefValue()
    {
        Console.WriteLine($"El valor de defensa de {Nombre} es de {Escudo.Defensa}.");
        return Escudo.Defensa; //Retorna el valor(double) del atributo del objeto itemDeDefensa
    }
    public double DealDamage(Personaje enemigo)//Sirve para atacar otro Caballero
    {
        double damage = this.Arma.Ataque;
        double realDamage = damage*(1-((enemigo.Escudo.Defensa)/100));//Se inmplemento que la defensa disminuye el valor del ataque en un porcentaje
        //Por ejemplo:Si la defensa es 20, el valor del ataque se vera disminuido en %20.
        enemigo.VidaActual = enemigo.VidaActual - realDamage;
        Console.WriteLine($"{Nombre} ha atacado a {enemigo.Nombre} y le ha hecho {realDamage} de daño.");
        Console.WriteLine($"La vida restante de {enemigo.Nombre} es {enemigo.VidaActual}.");
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
    public void GetStats()
    {
        Console.WriteLine($"{Nombre} tiene los siguientes stats: \nNivel de vida: {VidaActual}\nArma: {Arma.Nombre} (Ataque: {Arma.Ataque}) \nEscudo: {Escudo.Nombre} (Defensa: {Escudo.Defensa})");
    }
}