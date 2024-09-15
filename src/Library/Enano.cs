namespace Program;
using System;
using System.Collections;
using System.Collections.Generic;


public partial class Enano : EnanoPersonaje
{ 
    public string HabPasiva  { get; set; }//habilidad pasiva del enano
    public string Cerveza  { get; set; }
    public PistolaDePerno PistolaDePerno { get; set; }
    private bool usandoPistola;
    public HachaEnana HachaEnana  { get; set; }
    public Enano(string nombre, List<ItemEnano> itemsEnanos, double vida, PistolaDePerno pistolaDePerno, HachaEnana hachaEnana)
        : base(nombre, itemsEnanos, vida)
    {
        HachaEnana = hachaEnana;
        PistolaDePerno = pistolaDePerno;
        HabPasiva = "Resistencia alta a la borrachera";//agregar
        usandoPistola = false; // Comienza con el arma principal
    }

    public void AlternarArma()
    {
        usandoPistola = !usandoPistola; //cambia de arma
        string armaActual = usandoPistola ? "Pistola de perno" : "HachaEnana";
        Console.WriteLine($"{Nombre} ha cambiado su arma a {armaActual}");
    }
}
