using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceOnPlane : MonoBehaviour
{
    private ARRaycastManager _aRRaycastManager;
    static List<ARRaycastHit> _hits = new List<ARRaycastHit>();

    private GameObject ScenePrefab;
    private GameObject Scene;
    public Camera Camera;

    private void Awake()
    {
        _aRRaycastManager = GetComponent<ARRaycastManager>();
        ScenePrefab = (GameObject)Resources.Load("ARFoundationScene");
    }

    private void Update()
    {
        SetSceneOnPlace();
        Debug.Log(ScenePrefab);
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
            RotateSceneToPlayer();
        }
    }    

    private void RotateSceneToPlayer()
    {
        Scene.transform.rotation = new Quaternion(Scene.transform.rotation.x, 
            Camera.transform.rotation.y, Scene.transform.rotation.z, Camera.transform.rotation.w);
    }
}
