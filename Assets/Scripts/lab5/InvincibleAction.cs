using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Actions/Invincible")]
public class InvincibleAction : Action
{
    public AudioClip invincibilityStart;
    public override void Act(StateController controller)
    {
        MarioStateController m = (MarioStateController)controller;
        m.gameObject.GetComponent<AudioSource>().PlayOneShot(invincibilityStart);
        m.gameObject.GetComponent<Animator>().SetBool("onGround", true);
        m.SetRendererToFlicker();
    }
}
