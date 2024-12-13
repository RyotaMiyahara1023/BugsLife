using UnityEngine;
using UnityEngine.EventSystems;

public class ActivatePanels : MonoBehaviour
{
    public GameObject panelGroup; // �e�I�u�W�F�N�g�i�p�l�����܂Ƃ߂��I�u�W�F�N�g�j

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
