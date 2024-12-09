using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject[] panels; // 複数のパネルを管理

    public void ShowPanel(int panelIndex)
    {
        // 全てのパネルを非表示にする
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        // 指定されたパネルを表示
        if (panelIndex >= 0 && panelIndex < panels.Length)
        {
            panels[panelIndex].SetActive(true);
            Debug.Log($"Panel {panelIndex} activated");
        }
    }
}
