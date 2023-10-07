using UnityEngine;

public interface PowerupInterface
{
    void DestroyPowerup();
    void SpawnPowerup();
    void ApplyPowerup(MonoBehaviour i);

    PowerupType powerupType
    {
        get;
    }

    bool hasSpawned
    {
        get;
    }
}


public interface IPowerupApplicable
{
    // public void RequestPowerupEffect(Powerup i);
}

