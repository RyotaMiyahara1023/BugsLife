using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] ActivateParentAndDeactivateText AD;
    public GameObject[] panels; // �����̃p�l�����Ǘ�

    public void ShowPanel(int panelIndex)
    {
        // �S�Ẵp�l�����\���ɂ���
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        // �w�肳�ꂽ�p�l����\��
        if (panelIndex >= 0 && panelIndex < panels.Length)
        {
            panels[panelIndex].SetActive(true);
            if(panelIndex == 0) AD.sound = true;
            if(panelIndex == 1) {
                AD.score = true;
                GameObject.Find("Manager").GetComponent<Ranking>().DispRank();
            }
            Debug.Log($"Panel {panelIndex} activated");
        }
    }
}