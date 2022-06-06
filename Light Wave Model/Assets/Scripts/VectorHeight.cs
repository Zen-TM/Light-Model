using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorHeight : MonoBehaviour
{
    public GameObject lightWave;
    private float currentTime;
    private float amplitude;
    private float frequency;
    private float standardHeight;
    private float vectorDiameter = 0.2f;
    private float seperatingDistance;

    // Start is called before the first frame update
    void Start()
    {
        seperatingDistance = lightWave.GetComponent<LightWaveScript>().seperatingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        standardHeight = currentTime + int.Parse(this.name) * seperatingDistance;

        currentTime = lightWave.GetComponent<LightWaveScript>().currentTime;
        amplitude = lightWave.GetComponent<LightWaveScript>().amplitude;
        frequency = lightWave.GetComponent<LightWaveScript>().frequency;

        this.transform.localScale = new Vector3 (
            vectorDiameter, 
            Mathf.Sin(standardHeight * frequency) * amplitude, 
            vectorDiameter
            );
    }
}
