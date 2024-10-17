using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightCycle2D : MonoBehaviour
{
    [Header("Settings")]
    public Camera mainCamera; 
    public Light2D sun; 
    public Color dayColor = Color.cyan; 
    public Color nightColor = Color.black; 
    public float dayDuration = 10f; 
    public float nightDuration = 10f; 

    private float time;
    private Color currentBackgroundColor; 

    private void Start()
    {
        currentBackgroundColor = dayColor;
        mainCamera.backgroundColor = currentBackgroundColor;
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= dayDuration + nightDuration)
        {
            time = 0; 
        }

        bool isDay = time < dayDuration;

        Color targetColor = isDay ? dayColor : nightColor;
        currentBackgroundColor = Color.Lerp(currentBackgroundColor, targetColor, Time.deltaTime * 0.1f);
        mainCamera.backgroundColor = currentBackgroundColor;

        if (sun != null)
        {
            sun.color = isDay ? Color.white : new Color(1f, 1f, 1f, 0.5f); 
            sun.intensity = isDay ? 1 : 0.5f;
        }
    }
}
