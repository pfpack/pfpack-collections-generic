using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Collections.Tests;

partial class FlatArrayTest
{
    [Fact]
    public void ImplicitToArray_SourceIsDefault_ExpectEmptyArray()
    {
        StructType[] actual = default(FlatArray<StructType>);
        var expected = Array.Empty<StructType>();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ImplicitToArray_SourceIsNotDefault_ExpectInnerItems()
    {
        var sourceItems = new RefType[]
        {
            ZeroIdRefType, PlusFifteenIdRefType
        };

        RefType[] actual = sourceItems.InitializeFlatArray();
        Assert.Equal(sourceItems, actual);
    }

    [Fact]
    public void ImplicitToArray_InnerLengthIsLessThenItemsLength_ExpectLengthIsEqualToInnerLength()
    {
        var sourceItems = new[]
        {
            decimal.One, decimal.MinusOne
        };

        var source = sourceItems.InitializeFlatArray(1);
        decimal[] actual = source;

        var expected = new[]
        {
            decimal.One
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ImplicitToArray_ThenModifyResult_ExpectInnerStateHasNotChanged()
    {
        var sourceItems = new[]
        {
            MinusOne, PlusFifteen, Zero
        };

        var source = sourceItems.InitializeFlatArray();
        int[] result = source;

        result[2] += 1;
        TestHelper.VerifyInnerState(3, sourceItems, source);
    }

    [Fact]
    public void ImplicitToList_SourceIsDefault_ExpectEmptyList()
    {
        List<string?> actual = default(FlatArray<string?>);
        Assert.Empty(actual);
    }

    [Fact]
    public void ImplicitToList_SourceIsNotDefault_ExpectInnerItems()
    {
        var sourceItems = new bool?[]
        {
            false, null, true
        };

        List<bool?> actual = sourceItems.InitializeFlatArray();
        Assert.Equal(sourceItems, actual);
    }

    [Fact]
    public void ImplicitToList_InnerLengthIsLessThenItemsLength_ExpectLengthIsEqualToInnerLength()
    {
        var sourceItems = new RecordStruct?[]
        {
            default(RecordStruct), SomeTextRecordStruct, AnotherTextRecordStruct, null
        };

        var source = sourceItems.InitializeFlatArray(3);
        List<RecordStruct?> actual = source;

        var expected = new List<RecordStruct?>
        {
            default(RecordStruct), SomeTextRecordStruct, AnotherTextRecordStruct
        };

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ImplicitToList_ThenModifyResult_ExpectInnerStateHasNotChanged()
    {
        var sourceItems = new[]
        {
            SomeTextStructType, LowerSomeTextStructType
        };

        var source = sourceItems.InitializeFlatArray();
        List<StructType> result = source;

        result[0] = default;
        result.Remove(LowerSomeTextStructType);

        TestHelper.VerifyInnerState(2, sourceItems, source);
    }

    [Fact]
    public void ImplicitToImmutableArray_SourceIsDefault_ExpectEmptyImmutableArray()
    {
        ImmutableArray<RefType> actual = default(FlatArray<RefType>);
        var expected = ImmutableArray<RefType>.Empty;

        Assert.StrictEqual(expected, actual);
    }

    [Fact]
    public void ImplicitToImmutableArray_SourceIsNotDefault_ExpectInnerItems()
    {
        var sourceItems = new int?[]
        {
            MinusFifteen, One, PlusFifteen
        };

        ImmutableArray<int?> actual = sourceItems.InitializeFlatArray();
        Assert.Equal(sourceItems, actual);
    }

    [Fact]
    public void ImplicitToImmutableArray_InnerLengthIsLessThenItemsLength_ExpectLengthIsEqualToInnerLength()
    {
        var sourceItems = new[]
        {
            EmptyString, null, SomeString, UpperAnotherString, AnotherString
        };

        ImmutableArray<string?> actual = sourceItems.InitializeFlatArray(3);
        var expected = new[] { EmptyString, null, SomeString }.ToImmutableArray();

        Assert.Equal<IEnumerable<string?>>(expected, actual);
    }
}