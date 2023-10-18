using UnityEngine;
using System;
[CreateAssetMenu(menuName = "PluggableSM/Decisions/Buff")]
public class BuffDecision : Decision
{
    public BuffStateTransformMap[] map;
    public override bool Decide(StateController controller)
    {
        BuffStateController m = (BuffStateController)controller;
        BuffState toCompareState = EnumExtension.ParseEnum<BuffState>(m.currentState.name);
        for (int i = 0; i < map.Length; i++)
        {
            // if (toCompareState == map[i].fromState && m.currentPowerupType == map[i].powerupCollected)
            if (toCompareState == map[i].fromState && m.currentPowerupType == map[i].powerupCollected)
            {
                return true;
            }
        }
        return false;
    }
}

[System.Serializable]
public struct BuffStateTransformMap
{
    public BuffState fromState;
    public PowerupType powerupCollected;
}