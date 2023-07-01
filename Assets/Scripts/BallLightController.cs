using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLightController : MonoBehaviour
{
    [HideInInspector]
    float lightIntensity = 2;
    public Light pointLight;

    private void Start()
    {
        if (pointLight == null)
        {
            pointLight = GetComponent<Light>();
        }
    }

    void Update()
    {
        if (GetComponent<PlayerScaler>().isBig)
        {
            lightIntensity = 5;
        }
        if (GetComponent<PlayerScaler>().isSmall)
        {
            lightIntensity = 0.5f;
        }
        if (!GetComponent<PlayerScaler>().isBig && !GetComponent<PlayerScaler>().isSmall)
        {
            lightIntensity = 2;
        }
        pointLight.intensity = lightIntensity;
    }
}
