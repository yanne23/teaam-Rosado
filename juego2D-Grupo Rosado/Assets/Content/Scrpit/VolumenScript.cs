using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class VolumenScript : MonoBehaviour
{

    [Header("-------- Audio Settings --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;


    [Header("-------- Audio Clip --------")]

    public AudioClip background;
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;
    // Start is called before the first frame update
    
    private AudioSource audioSource;
    public static VolumenScript Instance;//{ get; private set; };


    private void Awake(){

        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);

        } else {
            Destroy(gameObject);
        }
       
    }
    
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        musicSource.clip = background;
        musicSource.Play();

        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMutado();
    }

    public void PlaySFX(AudioClip clip){
        sfxSource.PlayOneShot(clip);
    }

    public void ChangeSlider(float valor){
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMutado();
    }

    public void RevisarSiEstoyMutado(){
        if(slider.value == 0){
            imagenMute.enabled = true;
        }else{
            imagenMute.enabled = false;
        }
    }
    
    public void ReproducirSonido(AudioClip audio){
         audioSource.PlayOneShot(audio);
    }
}
