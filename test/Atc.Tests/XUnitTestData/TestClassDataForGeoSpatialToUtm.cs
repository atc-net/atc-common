// ReSharper disable StringLiteralTypo
namespace Atc.Tests.XUnitTestData;

internal sealed class TestClassDataForGeoSpatialToUtm : IEnumerable<object[]>
{
    [SuppressMessage("Style", "IDE0090:Use 'new(...)'", Justification = "OK.")]
    private readonly TheoryData<string, CartesianCoordinate, UniversalTransverseMercatorResult> data = new()
    {
        {
            "Ågeruphøj 33 4000 Roskilde",
            new CartesianCoordinate(55.69430922, 12.15276437),
            new UniversalTransverseMercatorResult(32, "U", 698143.79986065126, 6176562.9507410871)
        },
        {
            "Åvej 18 4000 Roskilde",
            new CartesianCoordinate(55.6558181, 11.0942214),
            new UniversalTransverseMercatorResult(32, "U", 631759.74277469353, 6169762.696127858)
        },
        {
            "Rytterhusene 76 2620 Albertslund",
            new CartesianCoordinate(55.67305066, 12.35990213),
            new UniversalTransverseMercatorResult(32, "U", 711271.29002319183, 6174810.1109701814)
        },
    };

    public IEnumerator<object[]> GetEnumerator() => data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}