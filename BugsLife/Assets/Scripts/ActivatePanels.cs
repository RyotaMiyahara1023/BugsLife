using UnityEngine;
using UnityEngine.EventSystems;

public class ActivatePanels : MonoBehaviour
{
    public GameObject panelGroup; // 親オブジェクト（パネルをまとめたオブジェクト）

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUI())
        {
            ActivateAllPanels();
        }
    }

    private void ActivateAllPanels()
    {
        if (panelGroup == null)
        {
            Debug.LogError("Panel Group is not assigned.");
            return;
        }

        foreach (Transform child in panelGroup.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    private bool IsPointerOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
