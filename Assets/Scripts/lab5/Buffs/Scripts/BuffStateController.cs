using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffStateController : StateController
{
    public PowerupType currentPowerupType = PowerupType.Default;
    public BuffState buffState = BuffState.Default;
    private SpriteRenderer spriteRenderer;
    public GameConstants gameConstants;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        GameRestart();
    }
    public void GameRestart()
    {
        buffState = BuffState.Default;
        // set the start state
        TransitionToState(startState);
    }
    public void SetPowerup(PowerupType i)
    {
        currentPowerupType = i;
    }
    public void SetRendererToFlicker()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log(currentState.name);
        StartCoroutine(BlinkSpriteRenderer());
    }
    private IEnumerator BlinkSpriteRenderer()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        while (string.Equals(currentState.name, "Invincible", StringComparison.OrdinalIgnoreCase))
        {
            // Toggle the visibility of the sprite renderer
            spriteRenderer.enabled = !spriteRenderer.enabled;

            // Wait for the specified blink interval
            yield return new WaitForSeconds(gameConstants.flickerInterval);
        }
        spriteRenderer.enabled = true;
    }
}
