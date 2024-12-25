using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSFX : MonoBehaviour
{
    [SerializeField] private AudioClip Reload1;
    [SerializeField] private AudioClip Reload2;
    [SerializeField] private AudioClip RackSFX;
    [SerializeField] private AudioClip ShootSFX;
    [SerializeField] private AudioClip EmptySFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void reloading()
    {
        StartCoroutine(ReloadSFX());
    }

    IEnumerator ReloadSFX()
    {
        SoundFXManager.instance.PlaySoundFXClip(Reload1, transform, 1f);
        yield return new WaitForSeconds(0.5f);
        SoundFXManager.instance.PlaySoundFXClip(Reload2, transform, 1f);
        yield return new WaitForSeconds(0.5f);
        SoundFXManager.instance.PlaySoundFXClip(RackSFX, transform, 1f);
        yield return new WaitForSeconds(0.5f);
    }
    public void ShootSound()
    {
        SoundFXManager.instance.PlaySoundFXClip(ShootSFX, transform, 1f);
    }
    public void EmptySound()
    {
        SoundFXManager.instance.PlaySoundFXClip(EmptySFX, transform, 1f);
    }
}
