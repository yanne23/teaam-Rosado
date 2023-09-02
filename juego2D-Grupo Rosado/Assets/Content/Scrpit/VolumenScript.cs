using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumenScript : MonoBehaviour
{

    [Header("-------- Audio Settings --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;


    [Header("-------- Audio Clip --------")]

    public AudioClip background;
    public AudioClip death;

    public Slider slider;
    public float sliderValue;
    public Image imagenMute;
    // Start is called before the first frame update
    public static VolumenScript instance;

    private void Awake(){

        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);

        } else {
            Destroy(gameObject);
        }
       
    }
    
    
    private void Start()
    {
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
    
}
