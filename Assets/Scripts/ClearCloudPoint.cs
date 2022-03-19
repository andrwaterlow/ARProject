using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class ClearCloudPoint : MonoBehaviour, IPointerClickHandler
{
    private ARPointCloudManager _aRPointCloudManager;
    private ARPlaneManager _aRPlaneManager;

    private void Start()
    {
        _aRPointCloudManager = FindObjectOfType<ARPointCloudManager>();
        _aRPlaneManager = FindObjectOfType<ARPlaneManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        foreach (var point in _aRPointCloudManager.trackables)
        {
            Destroy(point.gameObject);
        }

        foreach (var plane in _aRPlaneManager.trackables)
        {
            Destroy(plane.gameObject);
        }

        _aRPointCloudManager.enabled = false;
        _aRPlaneManager.enabled = false;
    }
}
