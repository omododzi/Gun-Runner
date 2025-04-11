using System;
using UnityEngine;
using UnityEngine.UI;

public class startButton : MonoBehaviour
{
    public GameObject start;
    public GameObject baff1;
    public GameObject baff2;
    public GameObject baff3;
    public AudioClip[] soundes;
    private AudioSource source => GetComponent<AudioSource>();

    

    void Start()
    {

        Button button = GetComponent<Button>();
        if (button != null)
            button.onClick.AddListener(OnButtonClick);
       
    }

   

    void OnButtonClick()
    {
        if (SwitshMusic.musicstate)
        {
            PlaySound(soundes[0]);
        }
        MAgazine.inmagazine = false;
        start.SetActive(false);
        baff1.SetActive(false);
        baff2.SetActive(false);
        baff3.SetActive(false);
        move.canMove = true;
        shoot.canshot = true;
    }
    public void PlaySound(AudioClip clip, float volume = 1f)
    {
        source.pitch = 1;
        source.PlayOneShot(clip, volume);
    }
}
