using UnityEngine;

public static class Dice
{
    public static int RollDice()
    {
        return RollD6() + RollD6();
    }

    private static int RollD6()
    {
        return Random.Range(1, 7);
    }
}
