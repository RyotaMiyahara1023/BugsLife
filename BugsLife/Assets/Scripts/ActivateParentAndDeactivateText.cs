using UnityEngine;
using UnityEngine.EventSystems; // �K�v: UI�C�x���g�V�X�e���̑���Ɏg�p

public class ActivateParentAndDeactivateText : MonoBehaviour
{
    public GameObject parentObject; // �e�I�u�W�F�N�g�i��A�N�e�B�u�ɂ����I�u�W�F�N�g�j
    public GameObject textObject;   // ��A�N�e�B�u�ɂ���Text�I�u�W�F�N�g
    public GameObject[] buttonObjects; // �����̃{�^���I�u�W�F�N�g
    public bool score;
    public bool sound;

    void Update()
    {
        // ���N���b�N�����o
        if (Input.GetMouseButtonDown(0) && !score && !sound)
        {
            // �N���b�N���{�^����ł���Ώ������X�L�b�v
            if (IsButtonClicked())
            {
                Debug.Log("A button was clicked. Skipping reaction.");
                return;
            }

            // �{�^���ȊO���N���b�N�����ꍇ�͏��������s
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

        // �e�I�u�W�F�N�g���A�N�e�B�u�ɂ���
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

        // Text�I�u�W�F�N�g���A�N�e�B�u�ɂ���
        textObject.SetActive(false);
        Debug.Log("Text object has been deactivated.");
    }

    private bool IsButtonClicked()
    {
        // �N���b�N��UI�v�f�̏ォ���m�F
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            return false; // ��������UI�̊O�Ȃ甽�����Ȃ�
        }

        // �N���b�N���ꂽ�I�u�W�F�N�g���擾
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        // �N���b�N���ꂽ�I�u�W�F�N�g�����C�L���X�g�Ŏ擾
        var raycastResults = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, raycastResults);

        // ���C�L���X�g���ʂ��m�F
        foreach (var result in raycastResults)
        {
            foreach (GameObject button in buttonObjects)
            {
                if (result.gameObject == button)
                {
                    // �N���b�N���ꂽ�I�u�W�F�N�g���{�^�����X�g�̒��Ɋ܂܂�Ă����true
                    return true;
                }
            }
        }

        return false; // �{�^���ł͂Ȃ��ꍇ
    }
}
