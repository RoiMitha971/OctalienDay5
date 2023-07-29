using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float customTimeScale;
    public static TimeManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        customTimeScale = 1f;
    }
}
