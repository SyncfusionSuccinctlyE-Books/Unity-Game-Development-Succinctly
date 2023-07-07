using System;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    Health,
    Shield,
    Speed
}

public class PowerUp : MonoBehaviour
{
    public PowerUpType Type;
    public int Amount;
    public float EffectiveTime;
    public bool Active;
    public Sprite Icon;

    private float _activeTime;

    public PowerUp(PowerUpType type, int amount = 0, float effectiveTime = 0.0f, bool active = false)
    {
        Type = type;
        Amount = amount;
        EffectiveTime = effectiveTime;
        Active = active;
    }

    public void Activate()
    {
        Active = true;
    }

    void Update()
    {
        if(Active)
        {
            _activeTime += Time.deltaTime;

            if (_activeTime >= EffectiveTime)
                Active = false;
        }
    }
}
