using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

public class DiceShould
{
    private int[] thrownDiceValues;
    
    [Test]
    public void RollDice()
    {
        Given100DicesRolled();
        ThenAssertThrownDices();
    }

    private void Given100DicesRolled()//Tendria que estar simplificado
    {
        thrownDiceValues = new int[100];
        for (int i = 0; i < 100; i++)
        {
            thrownDiceValues[i] = Dice.RollDice();
        }
    }
    
    private void ThenAssertThrownDices()
    {
        for (int i = 0; i < thrownDiceValues.Length; i++)
        {
            Assert.Less(thrownDiceValues[i], 13);
            Assert.Greater(thrownDiceValues[i], 1);
        }
    }
}
