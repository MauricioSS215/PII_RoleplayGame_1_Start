using Microsoft.VisualStudio.TestPlatform.TestHost;
using Program;

namespace LibraryTest;

public class CaballeroTests
{
    [Test]
    public void TestGetAttackValue()
    {
        var espada = new ItemDeAtaque("Espada Larga", 50);
        var escudo = new ItemDeDefensa("Escudo de Hierro", 30);
        var itemsArtoria = new List<Item> { espada, escudo};


        //Arrange
        var hero = new Caballero("Meliodas",itemsArtoria, 100);
        var itemDeAtaque = hero.Items.OfType<ItemDeAtaque>().FirstOrDefault();
        //Act
        double testAtaque = hero.GetAttackValue();
        //Assert
        Assert.AreEqual(itemDeAtaque.Ataque, testAtaque);
    }

    [Test]
    public void TestGetDefValue()
    {
        var espada = new ItemDeAtaque("Espada Larga", 50);
        var escudo = new ItemDeDefensa("Escudo de Hierro", 30);
        var itemsArtoria = new List<Item> { espada, escudo};


        //Arrange
        var hero = new Caballero("Meliodas",itemsArtoria, 100);
        var itemDeDefensa = hero.Items.OfType<ItemDeDefensa>().FirstOrDefault();
        //Act
        double testDefensa = hero.GetDefValue();
        //Assert
        Assert.AreEqual(itemDeDefensa.Defensa, testDefensa);
    }

    [Test]
    public void TestDealDamage()
    {
        var espada = new ItemDeAtaque("Espada Larga", 50);
        var escudo = new ItemDeDefensa("Escudo de Hierro", 30);
        var itemsArtoria = new List<Item> { espada, escudo};
        var hero = new Caballero("Meliodas",itemsArtoria, 100);
        var enemigo = new Caballero("Evil", itemsArtoria, 90);
        
        //Act
        double testDmg = hero.DealDamage(enemigo);
        //Assert
        Assert.AreEqual(55, testDmg);
    }
    [Test]
    public void TestHealDamage()
    {
        // Arrange
        ItemDeAtaque espada = new ItemDeAtaque("Espada Larga", 50);
        ItemDeDefensa escudo = new ItemDeDefensa("Escudo de Hierro", 30);
        var itemsArtoria = new List<Item> { espada, escudo};
        Caballero hero = new Caballero("Meliodas", itemsArtoria, 100); // VidaMax = 100
        hero.VidaActual = 50; // Baja la vida actual a 50

        // Act
        hero.HealDamage();

        // Assert
        Assert.AreEqual(100, hero.VidaActual);  // Verificamos que la vida se restaure a VidaMax
    }

}