using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class AudioButton : MonoBehaviour, IPointerEnterHandler // required interface when using the OnPointerEnter method.
{
    public AudioClip AudioClip;
    private AudioSource audioSource;
    public AudioSource mainAudio;

    private void Update()
    {
        if (audioSource != null)
        {
            audioSource.volume= mainAudio.volume;
        }
    }
    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.PlayOneShot(AudioClip);
    }
}