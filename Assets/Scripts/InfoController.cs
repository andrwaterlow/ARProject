using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InfoController : MonoBehaviour
{
    private ARPlaneManager _aRPlaneManager;
    [SerializeField] private GameObject _infoAnimation;
    

    void Awake()
    {
        _aRPlaneManager = GetComponent<ARPlaneManager>();
        _aRPlaneManager.planesChanged += _aRPlaneManager_planesChanged;
    }

    private void _aRPlaneManager_planesChanged(ARPlanesChangedEventArgs obj)
    {
        foreach (var item in obj.added)
        {
            _infoAnimation.SetActive(false);
            break;
        }
    }
}
