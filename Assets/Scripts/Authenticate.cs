using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Authenticate : MonoBehaviour
{
    string username = "Dogukan";
    string password = "12345678";
    string email = "dogukangozum@gmail.com";


    public void Login()
    {

        var request = new LoginWithPlayFabRequest
        {
            Username = username,
            Password = password,
            TitleId = "EBF35" 
        };

        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Login successful!");
        SceneManager.LoadScene("Menu");
        
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError("Login failed: " + error.ErrorMessage);
        // Handle login failure, e.g., show an error message to the player
        CreateUser();
    }

    public void CreateUser()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Username = username,
            Password = password,
            Email = email,
            TitleId = "EBF35" 
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnUserCreationSuccess, OnUserCreationFailure);
    }

    private void OnUserCreationSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("User creation successful!");
        Login();
        // Handle successful user creation, e.g., display a success message to the player
    }

    private void OnUserCreationFailure(PlayFabError error)
    {
        Debug.LogError("User creation failed: " + error.ErrorMessage);
        // Handle user creation failure, e.g., show an error message to the player
    }



}
