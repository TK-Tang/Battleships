namespace Battleships.Models
{
    public enum ShipStatus
    {
        Sunk,
        Operational,
        UnderAttack
    }

    public enum GameMode
    {
        PvP,
        PvE
    }

    public enum Color
    {
        Blue,
        Red,
        Green
    }

    public enum DamageReport
    {
        Miss,
        Damage,
        CriticalDamage,
        Sunk
    }
}
