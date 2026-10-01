using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public static MusicManager instance;
    public AudioSource musicaDeFundo;
   
   void Awake()
   {
    DontDestroyOnLoad(this.gameObject);

    if(instance != null)
    {
        Destroy(this.gameObject);
    }
    else 
    {
        instance = this;
    }

   }
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicaDeFundo.Play();
    }

    
}
