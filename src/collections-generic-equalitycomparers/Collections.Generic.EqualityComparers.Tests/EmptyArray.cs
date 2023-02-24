namespace PrimeFuncPack.Collections.Generic.EqualityComparers.Tests;

internal static class EmptyArray<T>
{
#pragma warning disable CA1825 // Avoid zero-length array allocations
    internal static T[] Create() => new T[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations

    internal static T[] Value => InnerEmpty.Value;

    private static class InnerEmpty
    {
        internal static readonly T[] Value = Create();
    }
}
