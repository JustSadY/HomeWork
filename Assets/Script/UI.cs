using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [HideInInspector] public static UI instance;
    public Slider slider;
    public PlayerController Player;
    public AudioSource audio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this.gameObject.GetComponent<UI>();
        }
    }

    public void PlayAudio(AudioClip clip)
    {
        if (clip == null) return;
        audio.resource = clip;
        audio.Play();
    }

    private void Update()
    {
        slider.value = Player.GetHealth();
    }
}