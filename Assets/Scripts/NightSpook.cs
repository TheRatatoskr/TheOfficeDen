using UnityEngine;

public class NightSpook : MonoBehaviour
{

    [SerializeField] private GameObject _spookyGhost;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _doorClip;

    private bool _isSpookyMode = false;

public void NightSpookTime()
    { 
    
        if (_isSpookyMode)
        {
            return;
        }

        _audioSource. clip = _doorClip;
        if(_audioSource.clip != null)
        {
            _audioSource.Play();
        }


        if (_spookyGhost.activeSelf == false)
        {
            _spookyGhost.SetActive(true);
        }
        _isSpookyMode = true;

        //change enviroment to be spookier
    }
}
