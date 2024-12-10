using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _pause;
    [SerializeField] GameObject[] Otaku = new GameObject[3];
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= 1.5f){
            Otaku_Generate();
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

            Instantiate(Otaku[otaku_color], new Vector3( rnd - 5, 1.0f, 10.0f), Quaternion.identity);

            num.RemoveAt(index);
        }

        num.Clear();

        time = 0f;
    }

    public void Pause()
    {
        _pause.SetActive(true);
    }

    public void Restart()
    {
        _pause.SetActive(false);
    }
}
