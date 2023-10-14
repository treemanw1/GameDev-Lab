using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinPowerup : BasePowerup
{
    public Animator powerupAnimator;
    public UnityEvent incrementscore;
    protected override void Start()
    {
        base.Start(); // call base class Start()
        this.type = PowerupType.Coin;
        // GameManager.instance.gameRestart.AddListener(GameRestart);
    }
    public void IncreaseScore()
    {
        incrementscore.Invoke();
    }
    // interface implementation
    public override void SpawnPowerup()
    {
        spawned = true;
    }
    // interface implementation
    public override void ApplyPowerup(MonoBehaviour i)
    {
        // TODO: do something with the object
    }
    public void GameRestart()
    {
        powerupAnimator.ResetTrigger("spawned");
        powerupAnimator.SetTrigger("reset");
        spawned = false;
        // powerupAnimator.Play("idle");
    }
}
