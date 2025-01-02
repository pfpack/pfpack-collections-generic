#pragma warning disable IDE0300 // Simplify collection initialization
#pragma warning disable CA1825 // Avoid zero-length array allocations

namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal static class EmptyArray<T>
{
    internal static T[] Create() => new T[0];

    internal static T[] Value => InnerEmpty.Value;

    private static class InnerEmpty
    {
        internal static readonly T[] Value = Create();
    }
}
