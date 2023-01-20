using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
   [SerializeField] private bool activarAudio;
   [SerializeField] private AudioClip musicaFondo;
   public AudioClip colisionClip;
    public AudioClip itemClip;
    public AudioClip uiClip;
    private AudioSource audioSource;
    private Pooler pooler;

     protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        pooler = GetComponent<Pooler>();
    }
    void Start()
    {
        ReproducirMusicaDeFondo();
    }
 private void ReproducirMusicaDeFondo()
    {
        if (activarAudio == false)
        {
            return;
        }

        audioSource.clip = musicaFondo;
        audioSource.loop = true;
        audioSource.Play();
    }
      public void ReproducirSonidoFX(AudioClip clip, float volume = 0.5f)
    {
        if (activarAudio == false)
        {
            return;
        }

        GameObject nuevoClip = pooler.ObtenerInstanciadelPooler();
        AudioSource audioSource = nuevoClip.GetComponent<AudioSource>();
        nuevoClip.SetActive(true);
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.loop = false;
        audioSource.Play();
        StartCoroutine(CODesactivar(nuevoClip, clip.length));
    }
      private IEnumerator CODesactivar(GameObject obj, float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        obj.SetActive(false);
    }
}
