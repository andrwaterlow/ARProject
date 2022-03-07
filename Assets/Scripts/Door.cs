using UnityEngine;
using UnityEngine.EventSystems;

public class Door : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var animator = GetComponent<Animator>();
        animator.SetTrigger("Open");
    }
}
