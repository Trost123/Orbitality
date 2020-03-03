using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)] private float fillPercentage;

    public Color highFillColor;
    public Color lowFillColor;
    private Color _fillColor;

    [Range(0, 100)] public float colorChangeThreshold;
    public Transform healthBarFillTransform;
    public SpriteRenderer fillSprite;
    private float _previousValue;
    public float FillPercentage
    {
        get => fillPercentage;
        set
        {
            this.fillPercentage = value;
            healthBarFillTransform.localScale = new Vector3(fillPercentage * 0.01f, 0.1f, 0.1f);
            if (fillSprite)
            {
                if (value >= colorChangeThreshold && _previousValue < colorChangeThreshold) //to prevent setting color every tick
                {
                    fillSprite.color = highFillColor;
                }
                else if (value < colorChangeThreshold && _previousValue >= colorChangeThreshold)
                {
                    fillSprite.color = lowFillColor;
                }
            }
            _previousValue = value;
        }
    }
}
