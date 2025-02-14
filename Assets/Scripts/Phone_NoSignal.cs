using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedUI : MonoBehaviour
{
    public Image[] signalSequenceImages; 
    public Image[] noSignalLines;
    public float signalSequenceInterval = 1f; 
    public float noSignalInterval = 0.5f; 

    public void Awake()
    {
        StartCoroutine(SignalSequence());
        StartCoroutine(NoSignalSequence());
        Debug.Log("Signalroutines Started");
    }

    private IEnumerator SignalSequence()
    {
        int index = 0;
        Debug.Log("Signalroutine going into while");
        while (true)
        {
            for (int i = 0; i < signalSequenceImages.Length; i++)
            {
                signalSequenceImages[i].enabled = i == index;
                Debug.Log("Signalroutine while i= "+ i);
            }
            index = (index + 1) % signalSequenceImages.Length;
            yield return new WaitForSeconds(signalSequenceInterval);
        }
    }

    private IEnumerator NoSignalSequence()
    {
        bool toggle = true;
        while (true)
        {
            foreach (Image tempoImage in noSignalLines)
            {
                tempoImage.enabled = toggle;
            }
            toggle = !toggle;
            yield return new WaitForSeconds(noSignalInterval);
        }
    }
}

