
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    
    [SerializeField] Light spotLight;

    
    [SerializeField] float maxIntensity = 25f; //the max brightness the light is when its on

    // Tge maximum and minimum durations the light stays on  
    [SerializeField] float maxOnTime = 3f; 
    [SerializeField] float minOnTime = 1f;

    // max and minimum durations the light stays off
    [SerializeField] float maxOffTime = 1f;
    [SerializeField] float minOffTime = 0.4f;

    // storess the randomly selected on n off durations
    float randomOnTime = 2f;
    float randomOffTime = 0.1f;

    // tracks if the light is currently on.
    bool isLightOn = true;

    // it measures how long the light has been in its current state.
    float currentTime = 0f;

    void Start()
    {
        // stops the script if there isnt a spotlight
        if (spotLight == null)
        {
            Debug.LogWarning("Assign a spotlight in the Inspector!");
            enabled = false;
            return;
        }

        // starts with the light switched on at its maximum intensity
        spotLight.intensity = maxIntensity;

        // chooses random durations for the first on and off cycles
        randomOnTime = Random.Range(minOnTime, maxOnTime);
        randomOffTime = Random.Range(minOffTime, maxOffTime);
    }

    void Update()
    {
        // increases the timer using elapsed time rather than frame count.
        currentTime += Time.deltaTime;

        // checks whether the light has to change state
        SimpleFlicker();
    }

    void SimpleFlicker()
    {
        // if the light is on and its timer has expired switch it off
        if (isLightOn && currentTime >= randomOnTime)
        {
            ToggleLight();

            // choose how long the light will stay off
            randomOffTime = Random.Range(minOffTime, maxOffTime);
        }
        // if the light is off and its timer expired switch it on
        else if (!isLightOn && currentTime >= randomOffTime)
        {
            ToggleLight();

            // choose how long the light will stay on
            randomOnTime = Random.Range(minOnTime, maxOnTime);
        }
    }

    void ToggleLight()
    {
        // resets the timer for the new light state
        currentTime = 0f;

        // reverse the current state, on becomes off, and vice versa.
        isLightOn = !isLightOn;

        // Set brightness according to the new state.
        if (isLightOn)
            spotLight.intensity = maxIntensity;
        else
            spotLight.intensity = 0f;
    }
}
