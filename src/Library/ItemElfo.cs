using System;
using System.Collections;
using System.Collections.Generic;

namespace Program
{
    public class Flecha
    {
        public string Tipo { get; set; } // "Fuego" o "Hielo"

        public Flecha(string tipo)
        {
            Tipo = tipo;
        }
    }

    public class Arco : ItemDeAtaque
    {
        public List<Flecha> Flechas { get; set; } = new List<Flecha>();

        public Arco(string nombre, double ataque) : base(nombre, ataque)
        {
        }

        public void AgregarFlecha(Flecha flecha)
        {
            if (!Flechas.Contains(flecha))
            {
                Flechas.Add(flecha);
            }
        }

        public void Atacar(string tipoFlecha)
        {
            var flecha = Flechas.Find(f => f.Tipo.Equals(tipoFlecha, StringComparison.OrdinalIgnoreCase));

            if (flecha != null)
            {
                Console.WriteLine($"Disparando flecha de {tipoFlecha} con el arco!");
            }
            else
            {
                Console.WriteLine($"No hay flechas de tipo {tipoFlecha} en el arco.");
            }
        }
    }

    public class Elfo : Item
    {
        public Arco Arco { get; set; }

        public Elfo(string nombre, double ataque, double defensa, Arco arco) : base(nombre, ataque, defensa)
        {
            Arco = arco;
        }

        public void AtacarConFlecha()
        {
            if (Arco.FlechasDisponibles > 0)
            {
                Arco.DisminuirFlechas();
                Console.WriteLine("¡Elfo ataca con el arco!");
            }
            else
            {
                Console.WriteLine("No hay flechas disponibles para atacar.");
            }
        }
    }
}