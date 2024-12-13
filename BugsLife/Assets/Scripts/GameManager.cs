using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject ScorePanel;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI ScoreAddText;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] TextMeshProUGUI GameOverText;
    [SerializeField] GameObject[] Otaku = new GameObject[3];
    public GameObject OtakuGenerater;
    float time = 0f;
    float timer = 999f;
    public bool pause;
    public bool clear;
    public bool gameover;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!pause && !clear){
            time += Time.deltaTime;
            timer -= Time.deltaTime;
            if(time >= 1.5f) Otaku_Generate();
        }

        ScoreText.text = score.ToString("D8");
        TimerText.text = ((int)timer/60).ToString() + ":" + ((int)(timer%60) + 1).ToString("D2");

        if(timer < 0f && !clear) {
            TimerText.text = "0:00";
            GameClear();
        }
    }

    void Otaku_Generate()
    {
        int otaku_kazu = Random.Range(1, 4);

        List<int> num = new List<int>();
        for (int i = 0; i <= 10; i++) {
            num.Add(i);
        }
        
        for(var i = 0; i < otaku_kazu; i++){
            int otaku_color = Random.Range(0, 3);

            int index = Random.Range(0, num.Count);
            int rnd = num[index];

            Instantiate(Otaku[otaku_color], OtakuGenerater.transform.GetChild(rnd).transform.position, Quaternion.identity);

            num.RemoveAt(index);
        }

        num.Clear();

        time = 0f;

        /*int otaku_color = Random.Range(0, 3);
        Instantiate(Otaku[otaku_color], OtakuGenerater.transform.GetChild(6).transform.position, Quaternion.identity);

        time = 0f;*/
    }

    public void Pause()
    {
        //Time.timeScale = 0;
        pause = true;
        PausePanel.SetActive(true);
    }

    public void Restart()
    {
        //Time.timeScale = 1;
        pause = false;
        PausePanel.SetActive(false);
    }

    public void GameClear()
    {
        //Time.timeScale = 0;
        clear = true;
        ScorePanel.SetActive(true);
        GameOverText.text = "ライブ成功!!!!!";
        //GameObject.Find("Manager").GetComponent<Ranking>().SetRank(score);
    }

    public void GameOver()
    {
        //Time.timeScale = 0;
        gameover = true;
        ScorePanel.SetActive(true);
        GameOverText.text = "ライブ失敗…";
    }

    public IEnumerator ScorePlus(int scoreAdd)
    {
        var scorecheck = score;
        ScoreAddText.text = "+" + scoreAdd.ToString();
        yield return new WaitForSeconds(0.1f);
        if(scorecheck == score)ScoreAddText.text = null;
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void BackTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
