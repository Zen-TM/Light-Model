using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightWaveScript : MonoBehaviour
{
    public float currentTime; 
    public GameObject firstEFV; 
    public GameObject firstMFV;
    private int n;
    public float seperatingDistance;
    public float timeSpeed;
    public float amplitude;
    public float frequency;
    public Slider timeSpeedSlider;
    public Slider amplitudeSlider;
    public Slider frequencySlider;

    void Start()
    {
        currentTime = 0f; 
        n = 500;
        seperatingDistance = 0.1f;
        timeSpeed = 2;
        amplitude = 2;
        frequency = 0.5f;

        firstEFV.transform.position = new Vector3 (0, 0, - n * seperatingDistance / 2);
        firstMFV.transform.position = new Vector3 (0, 0, - n * seperatingDistance / 2);

        for (int i = 1; i < n; i++) 
        {
            GameObject newEFV = Instantiate(firstEFV);
            newEFV.name = (i + 1).ToString();
            newEFV.transform.position = new Vector3 (
                firstEFV.transform.position.x,
                firstEFV.transform.position.y, 
                firstEFV.transform.position.z + seperatingDistance * i
                );
            newEFV.transform.parent = firstEFV.transform.parent;

            GameObject newMFV = Instantiate(firstMFV);
            newMFV.name = (i + 1).ToString();
            newMFV.transform.position = new Vector3 (
                firstEFV.transform.position.x,
                firstEFV.transform.position.y, 
                firstEFV.transform.position.z + seperatingDistance * i
                );
            newMFV.transform.parent = firstMFV.transform.parent;
        }

        transform.Rotate(new Vector3 (0, 0, 20));
    }

    void Update()
    {
        currentTime += Time.deltaTime * timeSpeed; 
    }

    public void ChangeAmplitude(float newAmplitude)
    {
        amplitude = Mathf.Pow(2, newAmplitude);
    }

    public void ChangeFrequency(float newFrequency)
    {
        frequency = Mathf.Pow(2, newFrequency);
    }

    public void ChangeTimeSpeed(float newTimeSpeed)
    {
        timeSpeed = Mathf.Pow(2, newTimeSpeed);
    }

    public void ResetWave()
    {
        currentTime = 0f; 
        timeSpeed = 2;
        amplitude = 2;
        frequency = 0.5f;

        timeSpeedSlider.value = 1;
        amplitudeSlider.value = 1;
        frequencySlider.value = -1;
    }
}
