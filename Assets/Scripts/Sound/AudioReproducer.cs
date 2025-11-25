using UnityEngine;
using UnityEngine.Audio;

[RequireComponent (typeof(AudioSource))]
public class AudioReproducer : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    //invocar el metodo cada ves que se quiera llamar
    public void SetAudio()
    {
        //con esta obtienes el largo del audio      
        Invoke("DesactiveObj", audioSource.clip.length);
    }
    public void DesactiveObj()
    {
        gameObject.SetActive(false);
    }
}
