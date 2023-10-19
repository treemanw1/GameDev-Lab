using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Actions/ClearPowerup")]
public class ClearPowerupAction : Action
{
    public override void Act(StateController controller)
    {
        MarioStateController m = (MarioStateController)controller;
        m.currentPowerupType = PowerupType.Default;
        if (controller.currentState.name != "DeadMario" || controller.currentState.name != "Default")
        {
            controller.gameObject.GetComponent<Animator>().SetBool("onGround", true);
        }
    }
}