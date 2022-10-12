using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TinyAudio.StopBGM();
        TinyAudio.PlaySE(TinyAudio.SE.Clear);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
