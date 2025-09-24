using System.Collections;
using UnityEngine;

public class Animal : MonoBehaviour
{
  #region Properties
  public string animalName;
  public bool playerInRange;

  [SerializeField] int currentHealth;
  [SerializeField] int maxHealth;

  [Header("Sounds")]
  [SerializeField] AudioSource soundChannel;
  [SerializeField] AudioClip rabbitHitAndScream;
  [SerializeField] AudioClip rabbitHitAndDie;

  enum AnymalType
  {
    Rabbit,
    Lion,
    Snake
  }

  [SerializeField] AnymalType thisAnimalType;

  private Animator animator;

  public bool isDead;

  [SerializeField] ParticleSystem bloodSplashParticleSystem;

  public GameObject bloodPuddle;
  #endregion

  #region Methods
  private void Start()
  {
    currentHealth = maxHealth;
    animator = GetComponent<Animator>();
  }

  private void OnTriggerEnter(Collider other) { if (other.CompareTag("Player")) playerInRange = true; }

  private void OnTriggerExit( Collider other ) { if (other.CompareTag("Player")) playerInRange = false; }

  public void TakeDamage(int damage)
  {
    if (!isDead)
    {
      currentHealth -= damage;

      bloodSplashParticleSystem.Play();

      if (currentHealth <= 0)
      {
        soundChannel.PlayOneShot(WhatAnimalSound(1));
        GetComponent<AI_Movement>().enabled = false;  
        animator.SetTrigger("DIE");

        StartCoroutine(PuddlePay());

        isDead = true;
      }
      else soundChannel.PlayOneShot(WhatAnimalSound(0));
    }
  }

  private AudioClip WhatAnimalSound(int coupOrDeath)
  {
    // Rabbit
    if (thisAnimalType.Equals(AnymalType.Rabbit) && coupOrDeath == 0) return rabbitHitAndScream;
    if (thisAnimalType.Equals(AnymalType.Rabbit) && coupOrDeath == 1) return rabbitHitAndDie;

    return null;
  }

  IEnumerator PuddlePay()
  {
    yield return new WaitForSeconds(1f);
    bloodPuddle.SetActive(true);
  }
  #endregion
}
