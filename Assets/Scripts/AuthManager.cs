using System.Threading.Tasks;
using UnityEngine;

public class AuthManager
{
    public static AuthManager Instance { get; } = new();

    public void Login(string email, string password, PopupUI popupUI)
    {
        Debug.Log("Start task");
        var task = new Task(() =>
        {
            MainThread.Invoke(popupUI.Close);
            MainThread.Invoke(() => Debug.Log("Login in..."));
        });
        task.Start();
    }
}