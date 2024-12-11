using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider; // BGMスライダー
    [SerializeField] private Slider mainSlider; // Mainスライダー
    [SerializeField] private Slider seSlider; // SEスライダー
    [SerializeField] private Image bgmSoundIcon; // BGMサウンドアイコン
    [SerializeField] private Image mainSoundIcon; // Mainサウンドアイコン
    [SerializeField] private Image seSoundIcon; // SEサウンドアイコン
    [SerializeField] private Sprite muteIcon; // ミュートアイコン
    [SerializeField] private Sprite undoIcon; // ミュート解除アイコン

    void Start()
    {
        // スライダーの初期値設定とリスナー登録
        bgmSlider.onValueChanged.AddListener(value => OnVolumeChanged(value, bgmSoundIcon));
        mainSlider.onValueChanged.AddListener(value => OnVolumeChanged(value, mainSoundIcon));
        seSlider.onValueChanged.AddListener(value => OnVolumeChanged(value, seSoundIcon));

        // 初期アイコンの更新
        OnVolumeChanged(bgmSlider.value, bgmSoundIcon);
        OnVolumeChanged(mainSlider.value, mainSoundIcon);
        OnVolumeChanged(seSlider.value, seSoundIcon);
    }

    private void OnVolumeChanged(float value, Image soundIcon)
    {
        if (value == 0)
        {
            // ミュート状態にする
            soundIcon.sprite = muteIcon;
        }
        else
        {
            // ミュート解除状態にする
            soundIcon.sprite = undoIcon;
        }
    }
}
