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
    static float StartTime => 10;//static ������ƁA���X�N���v�g�ł��g�p�\
    static bool clear;
    static bool gameover;

    private void Awake()
    {
        //this = �������g��(���̃X�N���v�g��)�Bscore = 0;�Atime = StartTime�̑O�ɂ��B��Ă���
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

        //����`�F�b�N���̂P �葱���^�̓T�^
        /*
        if(score>ScoreMax)
        {
            score = ScoreMax;
        }
        */

        //����`�F�b�N���̂Q �葱���^�̏ȗ��`�i���̂P���P�s�ɂ������́j
        //score = score > ScoreMax ? ScoreMax : score;

        //����`�F�b�N���̂R �֐��^�ŋߑ�I�iscore��ScoreMax�̂����A����������Ԃ��j
        //score + add �ɂ����������ŁAscore += add; ���ȗ��ł���
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
