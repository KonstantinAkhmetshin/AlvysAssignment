using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace Assignment.Test;

public class Functions_Test
{
    [Test]
    public void Map_AddOne()
    {
        var numbers = new List<int> { 1, 2, 3 };
        var result = Assignment.Main.Functions.Map(numbers, x => x + 1);
        var expected = new List<int> { 2, 3, 4 };
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Map_ToString()
    {
        var numbers = new List<int> { 1, 2, 3 };
        var result = Assignment.Main.Functions.Map(numbers, x => x.ToString());
        var expected = new List<string> { "1", "2", "3" };
        Assert.AreEqual(expected, result);
    }


    [Test]
    public void Map_NullValue_Ommited()
    {
        var numbers = new List<string> { "1", null, "3" };
        var result = Assignment.Main.Functions.Map(numbers, x => x.ToString());
        var expected = new List<string> { "1", "3" };
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Map_EmptyList()
    {
        var emptyList = new List<int>();
        var result = Assignment.Main.Functions.Map(emptyList, x => x + 1);
        Assert.IsEmpty(result);
    }

    [Test]
    public void Map_NullList_Returns_EmptyList()
    {
        List<int> emptyList = null;
        var result = Assignment.Main.Functions.Map(emptyList, x => x + 1);
        Assert.IsEmpty(result);
    }

    [Test]
    public void Fold_Sum()
    {
        List<int> numbers = new List<int> { 1, 2, 3 };
        int result = Assignment.Main.Functions.Fold(numbers, 0, (sum, x) => sum + x);
        Assert.AreEqual(6, result);
    }

    [Test]
    public void Fold_ToString()
    {
        var numbers = new List<int> { 1, 2, 3 };
        string result = Assignment.Main.Functions.Fold(numbers, "", (str, x) => str + x.ToString());
        Assert.AreEqual("123", result);
    }


    [Test]
    public void Fold_NullValues_Ommited()
    {
        var numbers = new List<string> { "1", null, "3" };
        string result = Assignment.Main.Functions.Fold(numbers, "", (str, x) => str + x.ToString());
        Assert.AreEqual("13", result);
    }

    [Test]
    public void Fold_EmptyList_ReturnsInitial()
    {
        var emptyList = new List<int>();
        int init = 10;
        int result = Assignment.Main.Functions.Fold(emptyList, init, (sum, x) => sum + x);
        Assert.AreEqual(init, result);
    }

    [Test]
    public void Fold_NullList_ReturnsInitial()
    {
        List<int> nullList = null;
        int init = 10;
        int result = Assignment.Main.Functions.Fold(nullList, init, (sum, x) => sum + x);
        Assert.AreEqual(init, result);    
    }

    [Test]
    public void Fold_NullInitial_ThrowsArgumentNullException()
    {
        var numbers = new List<int> { 1, 2, 3 };
        string init = null;
        Assert.Throws<ArgumentNullException>(() => Assignment.Main.Functions.Fold(numbers, init, (sum, x) => sum + x));
    }

    [Test]
    public void Map2_AddOne()
    {
        var numbers = new List<int> { 1, 2, 3 };
        var result = Assignment.Main.Functions.Map2(numbers, x => x + 1);
        var expected = new List<int> { 2, 3, 4 };
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Map2_ToString()
    {
        var numbers = new List<int> { 1, 2, 3 };
        var result = Assignment.Main.Functions.Map2(numbers, x => x.ToString());
        var expected = new List<string> { "1", "2", "3" };
        Assert.AreEqual(expected, result);
    }


    [Test]
    public void Map2_NullValue_Ommited()
    {
        var numbers = new List<string> { "1", null, "3" };
        var result = Assignment.Main.Functions.Map2(numbers, x => x.ToString());
        var expected = new List<string> { "1", "3" };
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void Map2_EmptyList()
    {
        var emptyList = new List<int>();
        var result = Assignment.Main.Functions.Map2(emptyList, x => x + 1);
        Assert.IsEmpty(result);
    }

    [Test]
    public void Map2_NullList_Returns_EmptyList()
    {
        List<int> emptyList = null;
        var result = Assignment.Main.Functions.Map2(emptyList, x => x + 1);
        Assert.IsEmpty(result);
    }


}