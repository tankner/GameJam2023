using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Cutscene : MonoBehaviour
{
    // Start is called before the first frame update
    private float lengthy;
    void Start()
    {
        lengthy = (float) GetComponent<VideoPlayer>().clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
