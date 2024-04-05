using System;
using NUnit.Framework;
using Assignment3.Utility;
using Assignment3.ProblemDomain;


[TestFixture]
public class LinkedListTests
{
    private SLL<User> list;

    [SetUp]
    public void Setup()
    {
        list = new SLL<User>();
    }

    [TearDown]
    public void TearDown()
    {
        list = null;
    }

    [Test]
    public void ListIsEmpty()
    {
        Assert.AreEqual(0, list.Count());
    }

    [Test]
    public void PrependItem()
    {
        list.AddFirst(new User { Name = "Joe Blow" });
        Assert.AreEqual(new User { Name = "Joe Blow" }, list.GetValue(0));
    }

    [Test]
    public void AppendItem()
    {
        list.AddLast(new User { Name = "Joe Blow" });
        Assert.AreEqual(new User { Name = "Joe Blow" }, list.GetValue(0));
    }

    [Test]
    public void InsertItemAtIndex()
    {
        list.AddLast(new User { Name = "Joe" });
        list.AddLast(new User { Name = "Joe Schmoe" });
        list.Add(new User { Name = "Colonel Sanders" }, 1);
        Assert.AreEqual(new User { Name = "Colonel Sanders" }, list.GetValue(1));
    }

    [Test]
    public void ReplaceItem()
    {
        list.AddLast(new User { Name = "Joe" });
        list.AddLast(new User { Name = "Joe Schmoe" });
        list.Replace(new User { Name = "Colonel Sanders" }, 1);
        Assert.AreEqual(new User { Name = "Colonel Sanders" }, list.GetValue(1));
    }
    [Test]
    public void DeleteItemFromBeginning()
    {
        list.AddLast(new User { Name = "Joe" });
        list.AddLast(new User { Name = "Joe Schmoe" });
        list.RemoveFirst();
        Assert.AreEqual(1, list.Count());
    }

    [Test]
    public void DeleteItemFromEnd()
    {
        list.AddLast(new User { Name = "Joe" });
        list.AddLast(new User { Name = "Joe Schmoe" });
        list.RemoveLast();
        Assert.AreEqual(1, list.Count());
    }
}