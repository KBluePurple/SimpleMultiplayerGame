public abstract class RequestUI : PopupUI
{
    public virtual void OnError(string error)
    {
        // Show error
    }

    public virtual void OnSuccess()
    {
        // Show success
    }
}