using System.ComponentModel;

namespace Battleships
{
    public enum TypeEnumeration
    {
        [Description("o")]
        Empty,

        [Description("B")]
        Battleship,

        [Description("C")]
        Carrier,

        [Description("R")]
        Crusier,

        [Description("D")]
        Destroyer,

        [Description("S")]
        Submarine,

        [Description("X")]
        Hit,

        [Description("M")]
        Miss
    }

    public enum FiringResult
    {
        Strike,
        Miss
    }
}
