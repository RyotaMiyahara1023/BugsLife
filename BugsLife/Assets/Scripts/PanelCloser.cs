using UnityEngine;
using UnityEngine.UI;

public class PanelCloser : MonoBehaviour
{
    public Button closeButton; // 閉じるボタンをアタッチ

    void Start()
    {
        // ボタンが設定されていれば、クリックイベントを登録
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(ClosePanel);
        }
        else
        {
            Debug.LogWarning("Close button is not assigned.");
        }
    }

    // パネルを閉じる処理
    void ClosePanel()
    {
        gameObject.SetActive(false); // 自身のGameObjectを非表示にする
        Debug.Log($"{gameObject.name} is now closed.");
    }
}
