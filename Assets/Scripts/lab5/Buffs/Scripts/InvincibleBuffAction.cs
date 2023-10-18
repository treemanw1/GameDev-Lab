using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Actions/SetupInvincibility")]
public class InvincibleBuffAction : Action
{
    public AudioClip invincibilityStart;
    public override void Act(StateController controller)
    {
        BuffStateController m = (BuffStateController)controller;
        m.gameObject.GetComponent<AudioSource>().PlayOneShot(invincibilityStart);
        Debug.Log("Flicker");
        m.SetRendererToFlicker();
    }
}
