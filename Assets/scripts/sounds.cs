using UnityEngine;

public class sounds : MonoBehaviour
{
  public AudioClip[] soundes;
  private AudioSource source => GetComponent<AudioSource>();

  public void PlaySound(AudioClip clip, float volume = 1f)
  {
    source.pitch = 1;
    source.PlayOneShot(clip, volume);
  }
}
