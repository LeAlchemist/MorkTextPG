using UnityEngine;

[ExecuteAlways]
public class DiceRoll : MonoBehaviour
{
    public int diceValue;
    int value;

    public void Dice(int value)
    {
        diceValue = Random.Range(1, value + 1);
    }
}