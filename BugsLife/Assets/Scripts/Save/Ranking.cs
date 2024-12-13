using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Ranking : MonoBehaviour
{
    /* 値 */
    const int   rankCnt = SaveData.rankCnt;                 // ランキング数

    /* コンポーネント取得用 */
    TextMeshProUGUI[] rankTexts = new TextMeshProUGUI[rankCnt];              // ランキングのテキスト
    SaveData    data;                                       // 参照するセーブデータ

    //-------------------------------------------------------------------
    public void DataLoad()
    {
        SceneManager.LoadScene("TitleScene");
        data = GetComponent<DataManager>().data;            // セーブデータをDataManagerから参照

        /*for (int i = 0; i < rankCnt; i++) {
            Transform rankChilds = GameObject.Find("RankTexts").transform.GetChild(i);      // 子オブジェクト取得
            rankTexts[i] = rankChilds.GetComponent<Text>();                                 // 子オブジェクトのコンポーネント取得
        }*/
    }

    //-------------------------------------------------------------------

    // ランキング表示
    public void DispRank()
    {
        for (int i = 0; i < rankCnt; i++) {
            Transform rankChilds = GameObject.Find("RankTexts").transform.GetChild(i);
            rankTexts[i] = rankChilds.GetComponent<TextMeshProUGUI>();   
            rankTexts[i].text = data.rank[i].ToString("D8");
        }
    }

    // ランキング保存
    public void SetRank(int score)
    {
        // スコアがランキング内の値よりも大きいときは入れ替え
        for (int i = 0; i < rankCnt; i++) {
            if (score > data.rank[i]) {
                var rep = data.rank[i];
                data.rank[i] = score;
                score = rep;
            }
        }
    }
}
