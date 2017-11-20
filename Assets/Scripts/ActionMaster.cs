using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ActionMaster
{
    
    public enum Action { Tidy, Reset, EndTurn, EndGame};

    private int[] bowls = new int[21];
    private int bowl = 1;
    
    public static Action NextAction(List<int> pinFalls)
    {
        ActionMaster am = new ActionMaster();
        Action currentAction = new Action();
        
        
        foreach(int pinFall in pinFalls)
        {
            currentAction = am.Bowl(pinFall);
        }

        return currentAction;
    }

    public Action Bowl(int pins) //TODO: make private
    {
        // Make sure pin count is in proper range.
        if (pins < 0 || pins > 10)
        {
            throw new ArgumentOutOfRangeException("Pin count is not in the range of 0 to 10 but was [" + pins + "]!");
        }

        bowls[bowl - 1] = pins;

        if (bowl == 21)
        {
            return Action.EndGame;
        }

        // Check for a STRIKE
        if (bowl >= 19 && pins == 10)
        {
            bowl += 1;
            return Action.Reset;
        }
        else if (bowl == 20)
        {
            bowl += 1;
            if (bowls[19 - 1] == 10 && bowls[20 - 1] == 0) return Action.Tidy;
            else if ((bowls[19 - 1] + bowls[20 - 1]) % 10 == 0) return Action.Reset;
            else if (Bowl21Awarded()) return Action.Tidy;
            else return Action.EndGame;
        }



        if (bowl % 2 != 0) { // First bowl of frame
            if (pins == 10)
            {
                bowl += 2;
                return Action.EndTurn;
            }
            else
            {
                bowl += 1;
                return Action.Tidy;
            }
        }
        else if (bowl % 2 == 0) // Second bowl of frame
        { 
            bowl += 1;
            return Action.EndTurn;
        }


        throw new UnityException("Not sure what 'Action' to return!");
    }

    private bool Bowl21Awarded()
    {
        // Remeber that arrays start at index 0
        return (bowls[19 - 1] + bowls[20 - 1] >= 10);
    }
}
