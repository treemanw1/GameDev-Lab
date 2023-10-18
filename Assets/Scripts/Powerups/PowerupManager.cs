using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public PowerupGameEvent powerupAffectsPlayer;
    public PowerupGameEvent powerupAffectsManager;
    public void FilterAndCastPowerup(PowerupInterface i)
    {
        powerupAffectsPlayer.Raise(i);
        powerupAffectsManager.Raise(i);
    }
}
