namespace AssetBundleMcp.Internal;

internal static class Paginate
{
    internal static IEnumerable<T> Execute<T>(IEnumerable<T> items, int offset, int pageSize)
    {
        return pageSize == 0 ? items.Skip(offset) : items.Skip(offset).Take(pageSize);
    }
}