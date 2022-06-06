using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWaveScript : MonoBehaviour
{
    public float currentTime = 0f; 
    public GameObject firstEFV; 
    public GameObject firstMFV;
    private int n = 500;
    public float seperatingDistance = 0.2f;
    public float timeSpeed = 2;
    public float amplitude = 2;
    public float frequency = 0.5f;

    void Start()
    {
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
}
