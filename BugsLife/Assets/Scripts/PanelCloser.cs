using UnityEngine;
using UnityEngine.UI;

public class PanelCloser : MonoBehaviour
{
    public Button closeButton; // ����{�^�����A�^�b�`

    void Start()
    {
        // �{�^�����ݒ肳��Ă���΁A�N���b�N�C�x���g��o�^
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(ClosePanel);
        }
        else
        {
            Debug.LogWarning("Close button is not assigned.");
        }
    }

    // �p�l������鏈��
    void ClosePanel()
    {
        gameObject.SetActive(false); // ���g��GameObject���\���ɂ���
        Debug.Log($"{gameObject.name} is now closed.");
    }
}