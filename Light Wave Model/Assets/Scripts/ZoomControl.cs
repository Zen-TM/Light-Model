using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControl : MonoBehaviour
{
    private float scroll;
    private float sensitivity = 0.1f;
    public GameObject playIcon;
    public GameObject pauseIcon;
    private float zoomDistance;

    void Start()
    {
        playIcon.SetActive(false);
        zoomDistance = Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) * 2);
    }

    void Update()
    {
        scroll = Input.mouseScrollDelta.y;
        zoomDistance = Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) * 2);

        if (scroll != 0)
        {
            transform.Translate((Vector3.forward * scroll * sensitivity) * zoomDistance);
            if (transform.position.x > -3)
            {
                transform.position = new Vector3 (-3, 0, 0);
            } else if (transform.position.x < -100)
            {
                transform.position = new Vector3 (-100, 0, 0);
            }
        }
    }

    public void PausePlayButton()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseIcon.SetActive(false);
            playIcon.SetActive(true);
        } else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseIcon.SetActive(true);
            playIcon.SetActive(false);
        }
    }

    public void ResetCameraPosition()
    {
        transform.position = new Vector3 (-20, 0, 0);
    }
}
