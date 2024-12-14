using UnityEngine;
using UnityEngine.EventSystems; // 必要: UIイベントシステムの操作に使用

public class ActivateParentAndDeactivateText : MonoBehaviour
{
    public GameObject parentObject; // 親オブジェクト（非アクティブにされるオブジェクト）
    public GameObject textObject;   // 非アクティブにするTextオブジェクト
    public GameObject[] buttonObjects; // 複数のボタンオブジェクト

    void Update()
    {
        // 左クリックを検出
        if (Input.GetMouseButtonDown(0))
        {
            // クリックがボタン上であれば処理をスキップ
            if (IsButtonClicked())
            {
                Debug.Log("A button was clicked. Skipping reaction.");
                return;
            }

            // ボタン以外をクリックした場合は処理を実行
            ActivateParent();
            DeactivateText();
        }
    }

    private void ActivateParent()
    {
        if (parentObject == null)
        {
            Debug.LogError("Parent object is not assigned.");
            return;
        }

        // 親オブジェクトをアクティブにする
        parentObject.SetActive(true);
        Debug.Log("Parent object has been activated.");
    }

    private void DeactivateText()
    {
        if (textObject == null)
        {
            Debug.LogWarning("Text object is not assigned.");
            return;
        }

        // Textオブジェクトを非アクティブにする
        textObject.SetActive(false);
        Debug.Log("Text object has been deactivated.");
    }

    private bool IsButtonClicked()
    {
        // クリックがUI要素の上かを確認
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            return false; // そもそもUIの外なら反応しない
        }

        // クリックされたオブジェクトを取得
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        // クリックされたオブジェクトをレイキャストで取得
        var raycastResults = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);

        // レイキャスト結果を確認
        foreach (var result in raycastResults)
        {
            foreach (GameObject button in buttonObjects)
            {
                if (result.gameObject == button)
                {
                    // クリックされたオブジェクトがボタンリストの中に含まれていればtrue
                    return true;
                }
            }
        }

        return false; // ボタンではない場合
    }
}
