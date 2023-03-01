using UnityEngine;

public abstract class PopupUI : MonoBehaviour
{
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    public virtual void Close()
    {
        Hide();
        Destroy(gameObject);
    }
}