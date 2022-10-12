using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TinyAudio.StopBGM();
        TinyAudio.PlaySE(TinyAudio.SE.Miss);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
