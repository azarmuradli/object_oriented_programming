using Assignment2;
using System.Xml.Linq;

namespace Assignment2Test;

[TestClass]
public class TestAnimal
{
    [TestMethod]

    public void TestAnimal_InitializationWithNegativeExhilaration()
    {

        try
        {
            Animal tarantula = new Tarantula("Webster", -20);
            Assert.Fail("no exception thrown");
        }
        catch (Exception ex)
        {
            Assert.IsTrue(ex is ArgumentException);
        }
        try
        {
            Animal hamster = new Hamster("Butterscotch", -20);
            Assert.Fail("no exception thrown");
        }
        catch (Exception ex)
        {
            Assert.IsTrue(ex is ArgumentException);
        }
        try
        {
            Animal cat = new Cat("Cat-man-do", -20);
            Assert.Fail("no exception thrown");
        }
        catch (Exception ex)
        {
            Assert.IsTrue(ex is ArgumentException);
        }
    }

    [TestMethod]
    public void Test_ExhilarationLevelChange()
    {
        Tarantula tarantula = new Tarantula("Webster", 20);
        Hamster hamster = new Hamster("Butterscotch", 30);
        Cat cat = new Cat("Cat-man-do", 50);

        Usual usual = Usual.Instance();
        Joyful joyful = Joyful.Instance();
        Blue blue = Blue.Instance();

        // test it for tarantula
        tarantula.Accept(usual);
        Assert.AreEqual(18, tarantula.getExhilaration());
        tarantula.Accept(joyful);
        Assert.AreEqual(19, tarantula.getExhilaration());
        tarantula.Accept(blue);
        Assert.AreEqual(16,tarantula.getExhilaration());

        // test it for hamster
        hamster.Accept(usual);
        Assert.AreEqual(27, hamster.getExhilaration());
        hamster.Accept(joyful);
        Assert.AreEqual(29, hamster.getExhilaration());
        hamster.Accept(blue);
        Assert.AreEqual(24, hamster.getExhilaration());

        // test it for cat
        cat.Accept(usual);
        Assert.AreEqual(53, cat.getExhilaration());
        cat.Accept(joyful);
        Assert.AreEqual(56, cat.getExhilaration());
        cat.Accept(blue);
        Assert.AreEqual(49, cat.getExhilaration());

    }

    [TestMethod]

    public void Test_MaxMinExhilarationLevel()
    {
        Tarantula tarantula = new Tarantula("Webster", 1);
        Hamster hamster = new Hamster("Butterscotch", 69);
        Usual usual = Usual.Instance();
        Joyful joyful = Joyful.Instance();
        Blue blue = Blue.Instance();

        tarantula.Accept(usual);
        //should give 0, not -1
        Assert.AreEqual(0, tarantula.getExhilaration());

        hamster.Accept(joyful);
        // should give 70, not 71
        Assert.AreEqual(70,hamster.getExhilaration());
    }

    [TestMethod]

    public void TestSteveUpdatingAnimals()
    {
        Tarantula tarantula = new Tarantula("Webster", 20);
        Hamster hamster = new Hamster("Butterscotch", 30);
        Cat cat = new Cat("Cat-man-do", 50);

        Usual usual = Usual.Instance();

        List<Animal> animals = new();
        animals.Add(tarantula); animals.Add(hamster);animals.Add(cat);

        Steve steve = new(animals);
        steve.setMood(usual);

        steve.updateAnimals();
        Assert.AreEqual(18, steve.getAnimals()[0].getExhilaration());
        Assert.AreEqual(27, steve.getAnimals()[1].getExhilaration());
        Assert.AreEqual(53, steve.getAnimals()[2].getExhilaration());

    }

    [TestMethod]

    public void TestSteveImprovingMood()
    {

        Tarantula tarantula = new Tarantula("Webster", 20);
        Hamster hamster = new Hamster("Butterscotch", 30);
        Cat cat = new Cat("Cat-man-do", 50);

        Usual usual = Usual.Instance();

        List<Animal> animals = new();
        animals.Add(tarantula); animals.Add(hamster); animals.Add(cat);

        Steve steve = new(animals);
        steve.setMood(usual);
        steve.improveMood();
        Assert.IsInstanceOfType(steve.getMood(), typeof(Joyful));

    }

    [TestMethod]

    public void TestSteveHighestAnimal()
    {
        Tarantula tarantula = new Tarantula("Webster", 20);
        Hamster hamster = new Hamster("Butterscotch", 30);
        Cat cat = new Cat("Cat-man-do", 50);

        Usual usual = Usual.Instance();

        List<Animal> animals = new();
        animals.Add(tarantula); animals.Add(hamster); animals.Add(cat);

        Steve steve = new(animals);
        steve.setMood(usual);
        Animal highest = steve.highestAnimal();
        Assert.AreEqual(highest, steve.getAnimals()[2]);

    }
}

  