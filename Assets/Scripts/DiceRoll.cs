using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DiceRoll : MonoBehaviour
{
    public int diceValue;
    public int maxValue;

    [ContextMenu("D2")]
    public void D2()
    {
        maxValue = 2;
        RollDice();
    }

    [ContextMenu("D4")]
    public void D4()
    {
        maxValue = 4;
        RollDice();
    }

    [ContextMenu("D6")]
    public void D6()
    {
        maxValue = 6;
        RollDice();
    }

    [ContextMenu("D8")]
    public void D8()
    {
        maxValue = 8;
        RollDice();
    }

    [ContextMenu("D10")]
    public void D10()
    {
        maxValue = 10;
        RollDice();
    }

    [ContextMenu("D12")]
    public void D12()
    {
        maxValue = 12;
        RollDice();
    }

    [ContextMenu("D20")]
    public void D20()
    {
        maxValue = 20;
        RollDice();
    }

    [ContextMenu("D100")]
    public void D100()
    {
        maxValue = 100;
        RollDice();
    }

    void RollDice()
    {
        diceValue = Random.Range(1, maxValue + 1);
    }
}
