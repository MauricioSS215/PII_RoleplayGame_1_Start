namespace Program;
using System;
using System.Collections.Generic;


public partial class Enano : EnanoPersonaje
{
    public string HabPasiva { get; set; } //habilidad pasiva del enano
    public PistolaDePerno PistolaDePerno { get; set; }
    public bool usandoPistola;
    public HachaEnana HachaEnana { get; set; }

    public Enano(string nombre, List<ItemEnano> itemsEnanos, double vida, PistolaDePerno pistolaDePerno,
        HachaEnana hachaEnana)
        : base(nombre, itemsEnanos, vida)
    {
        HachaEnana = hachaEnana;
        PistolaDePerno = pistolaDePerno;
        HabPasiva = "Resistencia alta a la borrachera"; //agregar
        usandoPistola = false; // Comienza con el arma principal
    }

    public void AlternarArma()
    {
        usandoPistola = !usandoPistola; //cambia de arma
        string armaActual = usandoPistola ? "Pistola de perno" : "Hacha doble pesada";
        Console.WriteLine($"{Nombre} ha cambiado su arma a {armaActual}");
    }
}