using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class Door : MonoBehaviour
{
    private ARFaceManager _ARFaceManager;

    private void Start()
    {
        _ARFaceManager = FindObjectOfType<ARFaceManager>();
        _ARFaceManager.facesChanged += ARFaceManager_facesChanged;
    }

    private void ARFaceManager_facesChanged(ARFacesChangedEventArgs obj)
    {
        var animator = GetComponent<Animator>();
        animator.SetTrigger("Open");
    }
}
