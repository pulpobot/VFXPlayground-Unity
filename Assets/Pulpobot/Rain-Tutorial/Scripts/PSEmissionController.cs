/* Copyright (C) 2017 Santiago Alvarez - All Rights Reserved
 * You may use, distribute and modify this code under the
 * terms of the MIT license.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(ParticleSystem))]
public class PSEmissionController : MonoBehaviour
{
    [SerializeField]
    float initialEmissionMultiplierValue;

    private void Awake()
    {
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        initialEmissionMultiplierValue = em.rateOverTimeMultiplier;
    }

    public void ChangeEmissionRate(float factor)
    {
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        em.rateOverTimeMultiplier = initialEmissionMultiplierValue * factor;
    }
}
