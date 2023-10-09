using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPowerup : BasePowerup
{
    // setup this object's type
    // instantiate variables
    protected override void Start()
    {
        base.Start(); // call base class Start()
        this.type = PowerupType.Coin;
    }
    public void IncreaseScore()
    {
        GameManager.instance.IncreaseScore(1);
    }
    // interface implementation
    public override void SpawnPowerup()
    {

    }
    // interface implementation
    public override void ApplyPowerup(MonoBehaviour i)
    {
        // TODO: do something with the object

    }
}
