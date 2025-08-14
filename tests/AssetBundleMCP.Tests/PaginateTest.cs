using AssetBundleMcpServer.Internal;

namespace AssetBundleMCP.Tests;

public class PaginateTest
{
    [Test]
    public void ReturnsAll_WhenOffsetAndPageSizeAreZero()
    {
        var items = Enumerable.Range(1, 5);
        var result = Paginate.Execute(items, 0, 0).ToArray();
        Assert.That(result, Is.EqualTo(new[] { 1, 2, 3, 4, 5 }));
    }

    [Test]
    public void SkipOffset_WhenPageSizeIsZero()
    {
        var items = Enumerable.Range(1, 5);
        var result = Paginate.Execute(items, 2, 0).ToArray();
        Assert.That(result, Is.EqualTo(new[] { 3, 4, 5 }));
    }

    [Test]
    public void SkipOffsetAndTakePageSize()
    {
        var items = Enumerable.Range(1, 5);
        var result = Paginate.Execute(items, 1, 2).ToArray();
        Assert.That(result, Is.EqualTo(new[] { 2, 3 }));
    }

    [Test]
    public void ReturnsEmpty_WhenOffsetExceedsCount()
    {
        var items = Enumerable.Range(1, 3);
        var result = Paginate.Execute(items, 5, 0).ToArray();
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void ReturnsAll_WhenPageSizeExceedsCount()
    {
        var items = Enumerable.Range(1, 3);
        var result = Paginate.Execute(items, 0, 10).ToArray();
        Assert.That(result, Is.EqualTo(new[] { 1, 2, 3 }));
    }

    [Test]
    public void ReturnsEmpty_WhenItemsIsEmpty()
    {
        var items = Enumerable.Empty<int>();
        var result = Paginate.Execute(items, 0, 0).ToArray();
        Assert.That(result, Is.Empty);
    }
}