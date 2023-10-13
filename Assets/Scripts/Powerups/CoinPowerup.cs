using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPowerup : BasePowerup
{
    public Animator powerupAnimator;
    protected override void Start()
    {
        base.Start(); // call base class Start()
        this.type = PowerupType.Coin;
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }
    public void IncreaseScore()
    {
        GameManager.instance.IncreaseScore(1);
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
