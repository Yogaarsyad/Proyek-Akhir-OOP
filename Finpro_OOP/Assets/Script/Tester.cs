using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public PauseMenu pauseMenu;
    [SerializeField] private AudioClip testSoundClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SoundFXManager.instance.PlaySoundFXClip(testSoundClip, transform, 1f);
            pauseMenu.GameOver();
            Debug.Log("TES");
        }

    }
}
