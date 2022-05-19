using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class ToggleCameraFacingDirection : MonoBehaviour
    {
        [SerializeField]
        ARCameraManager m_CameraManager;

        public ARCameraManager cameraManager
        {
            get => m_CameraManager;
            set => m_CameraManager = value;
        }

        [SerializeField]
        ARSession m_Session;

        private ARFaceManager _aRFaceManager;
        public GameObject Button;

        public ARSession session
        {
            get => m_Session;
            set => m_Session = value;
        }

        private void Start()
        {
            _aRFaceManager = GetComponent<ARFaceManager>();
        }

        public void ChangeCamera()
        {
            if (m_CameraManager.requestedFacingDirection == CameraFacingDirection.User)
            {
                m_CameraManager.requestedFacingDirection = CameraFacingDirection.World;

            }
            else
            {
                m_CameraManager.requestedFacingDirection = CameraFacingDirection.User;

            }  
        }

        public void HideButton() 
        {
            if (_aRFaceManager.trackables.count >= 1)
            {
                Button.SetActive(false);
            }
        }
    }
}