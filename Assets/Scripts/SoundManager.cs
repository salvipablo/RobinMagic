using UnityEngine;

public class SoundManager : MonoBehaviour
{
  #region Properties
  public static SoundManager Instance { get; set; }

  public AudioSource dropItemSound;
  public AudioSource craftingSound;
  public AudioSource toolSwingSound;
  public AudioSource chopSound;
  public AudioSource pickupItemSound;
  public AudioSource grassWalkSound;

  public AudioSource startingZoneBGMusic;

  public AudioSource voiceovers;
  #endregion

  #region Methods
  private void Awake()
  {
    if (Instance != null && Instance != this) Destroy(gameObject);
    else Instance = this;
  }

  public void PlaySound(AudioSource soundToPlay) { if (!soundToPlay.isPlaying) soundToPlay.Play(); }

  public void PlayVoiceOvers(AudioClip audioClip)
  {
    voiceovers.clip = audioClip;

    if (voiceovers.isPlaying) voiceovers.Play();
    else
    {
      voiceovers.Stop();
      voiceovers.Play();
    }
  }
  #endregion
}
