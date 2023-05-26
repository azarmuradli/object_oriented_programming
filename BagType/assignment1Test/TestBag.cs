using assignment1;

namespace assignment1Test;

[TestClass]
public class TestBag
{
    [TestMethod]

    public void TestInsert()
    {
        Bag bag = new Bag();
        bag.Insert(1);
        bag.Insert(1);
        bag.Insert(2);
        bag.Insert(3);
        bag.Insert(2);
        bag.Insert(4);

        Assert.AreEqual(2, bag.getNumOfOneOccur());
        Assert.AreEqual(2, bag.Frequency(1));
        Assert.AreEqual(2, bag.Frequency(2));
        Assert.AreEqual(1, bag.Frequency(3));
        Assert.AreEqual(1, bag.Frequency(4));
    }

    [TestMethod]

    public void TestRemove()
    {
        Bag bag = new Bag();
        try
        {
            bag.Remove(1);
            Assert.Fail("no exception thrown");
        }
        catch (Exception ex)
        {
            Assert.IsTrue(ex is Bag.BagDoesntContainThisElement);
        }
        bag.Insert(1);
        bag.Insert(1);
        Assert.AreEqual(1, bag.Remove(1));
        bag.Insert(3);
        bag.Insert(2);
        bag.Insert(2);
        bag.Insert(4);
        bag.Insert(2);
        Assert.AreEqual(2, bag.Remove(2));
        Assert.AreEqual(3, bag.getNumOfOneOccur());
        Assert.AreEqual(2, bag.Frequency(2));
    }

    [TestMethod]

    public void TestFrequency()
    {
        Bag bag = new Bag();
        bag.Insert(5);
        bag.Insert(4);
        bag.Insert(5);
        bag.Insert(3);
        bag.Insert(3);
        bag.Insert(3);
        Assert.AreEqual(2, bag.Frequency(5));
        Assert.AreEqual(1, bag.Frequency(4));
        Assert.AreEqual(3, bag.Frequency(3));
        Assert.AreEqual(0, bag.Frequency(7));
    }

    [TestMethod]

    public void TestNumOfOneOccur()
    {
        Bag bag = new Bag();
        bag.Insert(5);
        bag.Insert(4);
        bag.Insert(5);
        bag.Insert(3);
        bag.Insert(3);
        bag.Insert(3);
        bag.Insert(2);

        Assert.AreEqual(2, bag.getNumOfOneOccur());

    }
}