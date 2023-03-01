using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : RequestUI
{
    [SerializeField] InputField emailInput;
    [SerializeField] InputField passwordInput;
    [SerializeField] Button loginButton;

    private void Awake()
    {
        loginButton.onClick.AddListener(OnLoginButtonClicked);
    }

    private void OnLoginButtonClicked()
    {
        AuthManager.Instance.Login(emailInput.text, passwordInput.text, this);
    }
}