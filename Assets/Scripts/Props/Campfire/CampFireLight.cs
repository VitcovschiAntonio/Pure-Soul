using UnityEngine;

public class CampFireLight : MonoBehaviour
{
    public float flickerSpeed = 1f;   
    public float flickerIntensity = 1f;  
    public float baseIntensity = 2f;  

    private Light campfireLight;

    void Start()
    {
        Application.targetFrameRate = 60;
        campfireLight = GetComponent<Light>();
        campfireLight.intensity = baseIntensity;
    }

    void Update()
    {
        float flicker = Mathf.PerlinNoise(Time.time * flickerSpeed, 0f) * flickerIntensity;
        campfireLight.intensity = baseIntensity + flicker;
    }
}