/* Copyright (C) 2017 Santiago Alvarez - All Rights Reserved
 * You may use, distribute and modify this code under the
 * terms of the MIT license.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RainController))]
public class RainControllerEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();
        RainController targetScript = (RainController)target;
        targetScript.ToggleRipples = GUILayout.Toggle(targetScript.ToggleRipples, "Toggle Ripples");
        targetScript.ToggleFog = GUILayout.Toggle(targetScript.ToggleFog, "Toggle Fog");
        targetScript.RainIntensity = GUILayout.HorizontalSlider(targetScript.RainIntensity, 0, RainController.MAX_INTENSITY);
        GUILayout.Label("Intensity Factor: " + targetScript.RainIntensity.ToString("f2"));
    }
}
