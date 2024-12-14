using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject ScorePanel;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI ScoreAddText;
    [SerializeField] TextMeshProUGUI TimerText;
    [SerializeField] TextMeshProUGUI FinishText;
    [SerializeField] TextMeshProUGUI GameOverText;
    [SerializeField] TextMeshProUGUI ResultScoreText;
    [SerializeField] GameObject[] Otaku = new GameObject[3];
    [SerializeField] GameObject[] ScoreScreen = new GameObject[2];
    [SerializeField] Sprite[] Back = new Sprite[2];
    [SerializeField] Image BackImage;
    [SerializeField] GameObject Finish;
    [SerializeField] Sprite[] ResultScore = new Sprite[3];
    [SerializeField] GameObject ResultScoreImage;
    [SerializeField] GameObject StreetNameImage;
    public GameObject OtakuGenerater;
    float time = 0f;
    float timer = 1f;
    public bool pause;
    public bool clear;
    public bool gameover;
    public int score;
    AudioSource audiosource_BGM;
    AudioSource audiosource_SE;
    SoundManager soundmanager;
    [SerializeField] AudioClip PauseSE;
    [SerializeField] AudioClip CancelSE;
    [SerializeField] Slider Master;
    [SerializeField] Slider SE;
    [SerializeField] Slider BGM;
    // Start is called before the first frame update
    void Start()
    {
        soundmanager = GameObject.Find("Manager").GetComponent<SoundManager>();
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
            StartCoroutine("GameClear");
            //GameClear();
        }

        /*if(pause){
            Master.value = soundmanager.master;
            SE.value = soundmanager.se;
            BGM.value = soundmanager.bgm;
        }
        else {
            audiosource_BGM.volume = soundmanager.master * soundmanager.bgm;
            audiosource_SE.volume = soundmanager.master * soundmanager.se;
        }*/

        if((Input.GetMouseButtonDown(0) && ScoreScreen[0].activeSelf) && (clear || gameover)){
            ScoreScreen[0].SetActive(false);
            ScoreScreen[1].SetActive(true);
        }
    }

    void Otaku_Generate()
    {
        /*int otaku_kazu = Random.Range(1, 4);

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

        time = 0f;*/

        int otaku_color = Random.Range(0, 3);
        Instantiate(Otaku[otaku_color], OtakuGenerater.transform.GetChild(6).transform.position, Quaternion.identity);

        time = 0f;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pause = true;
        audiosource_SE.PlayOneShot(PauseSE);
        PausePanel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        pause = false;
        PausePanel.SetActive(false);
        audiosource_SE.PlayOneShot(CancelSE);
    }

    /*public void GameClear()
    {
        Time.timeScale = 0;
        clear = true;
        GameOverText.text = "Success!!";
        ResultScoreText.text = "Score " + score.ToString("D8");
        BackImage.sprite = Back[0];
        ResultScoreImage.SetActive(true);
        StreetNameImage.SetActive(true);
        ScorePanel.SetActive(true);
        GameObject.Find("Manager").GetComponent<Ranking>().SetRank(score);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameover = true;
        GameOverText.text = "Failed…";
        ResultScoreText.text = "Score " + score.ToString("D8");
        BackImage.sprite = Back[1];
        ResultScoreImage.SetActive(false);
        StreetNameImage.SetActive(false);
        ScorePanel.SetActive(true);
    }*/

    IEnumerator GameClear()
    {
        clear = true;
        FinishText.text = "LIVE SUCCESS";
        Finish.SetActive(true);
        yield return new WaitForSeconds(2f);
        ResultScoreText.text = "Score " + score.ToString("D8");
        BackImage.sprite = Back[0];
        ResultScoreImage.SetActive(true);
        StreetNameImage.SetActive(true);
        ScorePanel.SetActive(true);
        GameObject.Find("Manager").GetComponent<Ranking>().SetRank(score);
        yield return null;
    }
    public IEnumerator GameOver()
    {
        gameover = true;
        FinishText.text = "LIVE FAILED";
        Finish.SetActive(true);
        yield return new WaitForSeconds(2f);
        GameOverText.text = "Failed…";
        ResultScoreText.text = "Score " + score.ToString("D8");
        BackImage.sprite = Back[1];
        ResultScoreImage.SetActive(false);
        StreetNameImage.SetActive(false);
        ScorePanel.SetActive(true);
        yield return null;
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
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }

    public void BackTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScene");
    }
}
