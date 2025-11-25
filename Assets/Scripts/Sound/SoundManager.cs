using System.Collections.Generic;
using UnityEngine;
//para los sonidos siempre se tiene que tener un SoundManager 
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioClip jumpClip;
    public AudioClip attackClip;
    //estructuras de datos asocia una clave con un valor , estructura de datos simple y complejas 
    public Dictionary<string, AudioClip> musicData = new();
    
    
    public GameObject AudioReproducerPrefab;
    public List<GameObject> AudioPool = new();

    public int PoolSize = 10;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        for (int i = 0; i< PoolSize; i++)
        {
            GameObject obj = Instantiate(AudioReproducerPrefab); //asi se capturas estructuras
            AudioPool.Add(obj);
        }   

    }
    void Start()
    {
        //un sonido no se puede repetir con el mismo nombre
        musicData.Add("JumpSFX", jumpClip);
        musicData.Add("AttackSFX", attackClip);
        PlaySound("JumpSFX", 10);
        PlaySound("AttackSFX", 10);
    }

    
    void Update()
    {
        
    }
    //asi se maneja el volumen y el nombre de la musica 
    public void PlaySound(string musicName,float volume)
    {
        if (musicData.TryGetValue(musicName, out AudioClip clip))
        {
            AudioSource audioSource = GetAvaliableSoundReproducer().GetComponent<AudioSource>(); // busca y reproduce un item si esta disponible
            audioSource.clip = clip;
            audioSource.volume = volume;
            AudioReproducerPrefab.SetActive(true); //asi se activa un objeto asi mismo
            audioSource.GetComponent<AudioReproducer>().SetAudio();
        }
        else
        {
            Debug.Log("No existe");
        }
    }
    //asi se verifica si un audio esta activado o no y lo retorna si no esta activado
    public GameObject GetAvaliableSoundReproducer()
    {
        foreach(var item in AudioPool)
        {
            if (item.activeSelf == true)
                return item;
            
        }
        return null;
    }
}
