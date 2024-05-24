using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonContentPositionChanger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Vector2 _positionOffset;

    public void OnPointerDown(PointerEventData eventData)
    {
        ChangeAllChildsPosition(_positionOffset);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ChangeAllChildsPosition(-_positionOffset);
    }

    private void ChangeAllChildsPosition(Vector2 offset)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            ChangeContentPosition(child, offset);
        }
    }

    private void ChangeContentPosition(Transform transform, Vector2 offset)
    {
        transform.Translate(offset);
    }
}
