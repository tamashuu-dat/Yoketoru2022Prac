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
    static float StartTime => 10;//複数シーンで使いたいものは static を使う

    private void Awake()
    {
        //this = 自分自身の(このスクリプトの)。score = 0;、time = StartTimeの前にも隠れている
        Instance = this;
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
}
