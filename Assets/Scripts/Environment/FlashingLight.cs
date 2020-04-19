using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class FlashingLight : MonoBehaviour
{
    public float intensity = 1;
    public float t = 0;
    [SerializeField] private Light light;

    private float lightIntensity;
    private int lSwitch = 0;

    void Start()
    {
        if (light == null)
            light = GetComponent<Light>();

        lightIntensity = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if(t <= 0)
        {
            t = intensity;
            light.intensity = 0;
        } else
        {
            if (lSwitch == 0)
                light.intensity = lightIntensity;
            else
                light.intensity = 0;
            t -= Time.fixedDeltaTime;
        }
    }

    
}
