#define DEBUG_KEY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoreText = default;

    static int score;
    static float time;
    static float StartTime => 10;//複数シーンで使いたいものは static を使う

    private void Awake()
    {
        score = 0;
        time = StartTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        TinyAudio.PlaySE(TinyAudio.SE.Start);
    }

    // Update is called once per frame
    void Update()
    {
#if DEBUG_KEY
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Clear", LoadSceneMode.Additive);
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            score += 123;
            UpdateScoreText();
        }
#endif
    }

    void UpdateScoreText()
    {
        if(scoreText!=null)
        {
            scoreText.text = $"{score:00000}";
        }
    }
}
