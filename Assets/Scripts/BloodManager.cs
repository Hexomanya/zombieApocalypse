using UnityEngine;

public class BloodManager : MonoBehaviour
{

    public ParticleSystem bloodSplatter;
    public ParticleSystem bloodDrop;

    public bool IsBloodEffectPlaying()
    {
        return bloodSplatter.isPlaying || bloodDrop.isPlaying;
    }

    public void PlaySplatter(Quaternion rotation)
    {
        bloodSplatter.transform.rotation = rotation;
        bloodSplatter.Play();
    }

    public void PlayDrop()
    {
        bloodDrop.Play();
    }

    public void StopDrop()
    {
        bloodDrop.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }
}
