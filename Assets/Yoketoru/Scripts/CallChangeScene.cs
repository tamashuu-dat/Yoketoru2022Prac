using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallChangeScene : MonoBehaviour
{

    ToNextScene toNextScene;

    static float IgnoreKeySeconds => 0.5f;
    float ignoreTime;

    // Start is called before the first frame update
    void Start()
    {
        toNextScene = GetComponent<ToNextScene>();
        ignoreTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ignoreTime += Time.deltaTime;
        if (ignoreTime < IgnoreKeySeconds) return;

        if (Input.GetButtonDown("Next"))
        {
            toNextScene.ChangeScene();
        }
    }
}
