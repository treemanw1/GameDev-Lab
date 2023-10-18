
using UnityEngine;
using System;
[CreateAssetMenu(menuName = "PluggableSM/Decisions/Transform")]
public class TransformDecision : Decision
{
    public StateTransformMap[] map;

    public override bool Decide(StateController controller)
    {

        MarioStateController m = (MarioStateController)controller;
        // we assume that the state is named (string matched) after one of possible values in MarioState
        // convert between current state name into MarioState enum value using custom class EnumExtension
        // you are free to modify this to your own use
        MarioState toCompareState = EnumExtension.ParseEnum<MarioState>(m.currentState.name);
        Debug.Log("toCompareState: " + toCompareState);
        Debug.Log("m.currentPowerupType: " + m.currentPowerupType);

        // loop through state transform and see if it matches the current transformation we are looking for
        for (int i = 0; i < map.Length; i++)
        {
            if (toCompareState == map[i].fromState && m.currentPowerupType == map[i].powerupCollected)
            {
                Debug.Log("Transform to: " + toCompareState.ToString() + " SUCCESS");
                return true;
            }
        }
        Debug.Log("Transform to: " + toCompareState.ToString() + " FAIL");
        return false;
    }
}

[System.Serializable]
public struct StateTransformMap
{
    public MarioState fromState;
    public PowerupType powerupCollected;
}
