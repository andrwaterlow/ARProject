using UnityEngine;

public class PhonePanelControl : MonoBehaviour
{
    public void Active()
    {
        gameObject.SetActive(true);
    }

    public void Deactive()
    {
        gameObject.SetActive(false); 
    }
}
