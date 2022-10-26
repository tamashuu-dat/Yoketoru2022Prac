#define DEBUG_KEY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    TextMeshProUGUI scoreText = default;

    static int ScoreMax => 99999;

    static int score;
    static float time;
    static float StartTime => 10;//static をつけると、他スクリプトでも使用可能
    static bool clear;
    static bool gameover;

    private void Awake()
    {
        //this = 自分自身の(このスクリプトの)。score = 0;、time = StartTimeの前にも隠れている
        Instance = this;
        ClearScore();
        Item.ClearCount();
        time = StartTime;
        clear = false;
        gameover = false;
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
            ToGameover();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            ToClear();
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            AddPoint(12345);
        }
#endif
    }

    void UpdateScoreText()
    {
        if(scoreText != null)
        {
            scoreText.text = $"{score:00000}";
        }
    }

    public static void AddPoint(int add)
    {
        //score += add;

        //上限チェックその１ 手続き型の典型
        /*
        if(score>ScoreMax)
        {
            score = ScoreMax;
        }
        */

        //上限チェックその２ 手続き型の省略形（その１を１行にしたもの）
        //score = score > ScoreMax ? ScoreMax : score;

        //上限チェックその３ 関数型で近代的（scoreとScoreMaxのうち、小さい方を返す）
        //score + add にしたおかげで、score += add; を省略できる
        score = Mathf.Min(score + add, ScoreMax);

        if(score > ScoreMax)
        {
            score = ScoreMax;
        }
        if(Instance != null)
        {
            Instance.UpdateScoreText();
        }
    }

    public static void ClearScore()
    {
        score = 0;
        if(Instance != null)
        {
            Instance.UpdateScoreText();
        }
    }

    public static void ToClear()
    {
        if (clear || gameover) return;

        clear = true;
        SceneManager.LoadScene("Clear", LoadSceneMode.Additive);
        Time.timeScale = 0;
    }

    public static void ToGameover()
    {
        if (clear || gameover) return;

        gameover = true;
        SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
        Time.timeScale = 0f;
    }
}
