using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{

    public AudioSource[] audioSource = new AudioSource[2];
    public AudioClip[] audioClip = new AudioClip[2];
    public GameObject audio1;
   

    //spublic static Audio_Manager instance; 


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //scene_Start_Sounds();

        
    }

    
    // Update is called once per frame
    void Update()
    {
       
    }

    

    

    public void Shield_Sound()
    {

        audioClip[0] = Resources.Load<AudioClip>("ShieldSound");

        audioSource[0] = audio1.GetComponent<AudioSource>();

        audioSource[0].clip = audioClip[0];
        
        audioSource[0].PlayOneShot(audioSource[0].clip);
        Debug.Log("Sound");
    }
   
}
