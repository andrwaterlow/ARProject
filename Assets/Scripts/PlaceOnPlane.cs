using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlane : MonoBehaviour
{
    private ARRaycastManager _aRRaycastManager;
    private ARFaceManager _aRFaceManager;
    private ClearCloudPoint _clearCloudPoint;

    public  GameObject Text;
    public GameObject Button;
    static List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private GameObject ScenePrefab;
    private GameObject Scene;
    public Camera Camera;

    private void Awake()
    {
        _aRRaycastManager = GetComponent<ARRaycastManager>();
        _aRFaceManager = GetComponent<ARFaceManager>();
        _clearCloudPoint = GetComponent<ClearCloudPoint>();
        ScenePrefab = (GameObject)Resources.Load("ARFoundationScene");
        _aRFaceManager.facesChanged += _aRFaceManager_facesChanged;
    }

    private void _aRFaceManager_facesChanged(ARFacesChangedEventArgs obj)
    {
        Text.SetActive(false);
    }

    private void Update()
    {
        SetSceneOnPlace();
    }

    private bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

         touchPosition = default;
         return false;   
    }

    private void SetSceneOnPlace()
    {
        if (!TryGetTouchPosition(out var touchPosition))
        {
            return;
        }

        if (_aRRaycastManager.Raycast(touchPosition, _hits, TrackableType.PlaneWithinPolygon))
        {
            var positionOfTouch = _hits[0].pose;
            CreateOrMoveScene(positionOfTouch);
        }
    }

    private void CreateOrMoveScene(Pose position)
    {
        if (Scene != null)
        {
            Scene.transform.position = position.position;
            RotateSceneToPlayer();
        }
        else 
        {
            Scene = Instantiate(ScenePrefab, position.position, Quaternion.identity);
            Text.SetActive(true);
            Button.SetActive(true);
            _aRRaycastManager.enabled = false;
            _clearCloudPoint.OnPointerClick();
        }
    }    

    private void RotateSceneToPlayer()
    {
        Scene.transform.rotation = new Quaternion(Scene.transform.rotation.x, 
            Camera.transform.rotation.y, Scene.transform.rotation.z, Camera.transform.rotation.w);
    }
}
