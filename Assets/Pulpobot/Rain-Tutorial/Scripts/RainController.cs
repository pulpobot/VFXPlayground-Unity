/* Copyright (C) 2017 Santiago Alvarez - All Rights Reserved
 * You may use, distribute and modify this code under the
 * terms of the MIT license.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(ParticleSystem))]
public class RainController : MonoBehaviour
{
    [SerializeField]
    GameObject ripplesObj;

    [HideInInspector, SerializeField]
    bool isRipplesOn = false;

    public bool ToggleRipples
    {
        get { return isRipplesOn; }
        set
        {
            ripplesObj.SetActive(value);
            isRipplesOn = value;
            ResetRain();
        }
    }

    [SerializeField]
    GameObject fogObj;
    [HideInInspector, SerializeField]
    bool isFogOn = false;
    public bool ToggleFog
    {
        get { return isFogOn; }
        set
        {
            fogObj.SetActive(value);
            isFogOn = value;
            ResetRain();
        }
    }

    void ResetRain()
    {
        GetComponent<ParticleSystem>().Stop();
        GetComponent<ParticleSystem>().Play();
    }

    [HideInInspector, SerializeField]
    float rainIntensity = 1.0f;
    public const float MAX_INTENSITY = 2f;
    const float INITIAL_INTENSITY = 1f;
    [SerializeField]
    PSEmissionController[] psAffectedByIntensity;
    public float RainIntensity
    {
        get { return rainIntensity; }
        set
        {
            rainIntensity = value;
            float factor = rainIntensity / INITIAL_INTENSITY;
            for (int psIndex = 0; psIndex < psAffectedByIntensity.Length; psIndex++)
            {
                psAffectedByIntensity[psIndex].ChangeEmissionRate(factor);
            }
            //ResetRain();
        }
    }

    private void Awake()
    {
        rainIntensity = INITIAL_INTENSITY;
    }
}
