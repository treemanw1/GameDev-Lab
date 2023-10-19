using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Actions/ClearBuff")]
public class ClearBuffAction : Action
{
    public override void Act(StateController controller)
    {
        BuffStateController b = (BuffStateController)controller;
        b.buffState = BuffState.Default;
        b.currentPowerupType = PowerupType.Default;
    }
}