using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayFabManager : MonoBehaviour
{
    public static PlayFabManager pFM;
    //public NetworkManager nM;

    public bool isAuthenticated = false;

    private string userEmail;
    public string username;
    private string userPassword;
    public string id;

    public GameObject listingPrefab;



    public void OnEnable()
    {
        if (PlayFabManager.pFM == null)
        {
            pFM = this;
        }
        else
        {
            if (PlayFabManager.pFM != null)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void Start()
    {

        //Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "8BDC7"; // Please change this value to your own titleId from PlayFab Game Manager
        }

    }

    #region GetInputField
    public void GetUserEmail(string emailIn)
    {
        userEmail = emailIn;
    }

    public void GetUserName(string usernameIn)
    {
        username = usernameIn;
    }

    public void GetUserPassWord(string passwordIn)
    {
        userPassword = passwordIn;
    }

    #endregion GetInputField

    #region LoginSystem

    public void OnClickLogin()
    {
        if (userEmail != null && userPassword != null)
        {
            OnLogin();
        }
    }
    public void OnLogin()
    {
        var request = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);


    }

    public void OnLoginSuccess(LoginResult result)
    {
        //gameObject.GetComponent<NetworkManager>().ConnectToMaster();
        //GameObject.Find("Menu").GetComponent<Menu>().SetScreen(GameObject.Find("Menu").GetComponent<Menu>().mainMenuPanel);
        isAuthenticated = true;
        GetUserInventory();
        GetAccountInfo();
        id = result.PlayFabId;
        SceneManager.LoadScene(1);
    }

    private void OnLoginFailure(PlayFabError error)
    {
        isAuthenticated = false;
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    #endregion LoginSystem

    #region RegisterSystem
    public void OnClickRegister()
    {
        if (userEmail != null && username != null && userPassword != null)
        {
            OnRegister();
        }
    }
    public void OnRegister()
    {
        var request = new RegisterPlayFabUserRequest { Email = userEmail, Username = username, DisplayName = username, Password = userPassword };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFail);
    }

    public void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log(result);
        if (isAuthenticated == true)
        {
            //GameObject.Find("Menu").GetComponent<Menu>().SetScreen(GameObject.Find("Menu").GetComponent<Menu>().mainMenuPanel);
        }
    }

    public void OnRegisterFail(PlayFabError error)
    {
        Debug.Log(error.ToString());
    }

    #endregion RegisterSystem

    void GetAccountInfo()
    {
        GetAccountInfoRequest request = new GetAccountInfoRequest();
        PlayFabClientAPI.GetAccountInfo(request, Successs, Fail);
    }
    void Successs(GetAccountInfoResult result)
    {
        username = result.AccountInfo.Username;
    }

    void Fail(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }

    #region PlayerInventory

    public void GetUserInventory()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, error => Debug.LogError(error.GenerateErrorReport()));
    }

    private void OnGetUserInventorySuccess(GetUserInventoryResult result)
    {

    }



    #endregion PlayerInventory

    #region Friends

    [SerializeField]
    Transform friendScrollView;
    List<FriendInfo> myFriends;
    void DisplayFriends(List<FriendInfo> friendsCache)
    {
        foreach (FriendInfo f in friendsCache)
        {
            bool isFound = false;

            if (myFriends != null)
            {
                foreach (FriendInfo g in myFriends)
                {
                    if (f.FriendPlayFabId == g.FriendPlayFabId)
                        isFound = true;
                }

            }

            if (isFound == false)
            {
                GameObject listing = Instantiate(listingPrefab, friendScrollView);
                //ListingPrefab tempList = listing.GetComponent<ListingPrefab>();
                //tempList.playerNameText.text = f.TitleDisplayName;
            }

        }

        myFriends = friendsCache;
    }

    IEnumerator WaitForFriends()
    {
        yield return new WaitForSeconds(2);
        GetFriends();
    }

    public void RunWaitFunction()
    {
        StartCoroutine(WaitForFriends());
    }
    List<FriendInfo> _friends = null;

    public void GetFriends()
    {
        PlayFabClientAPI.GetFriendsList(new GetFriendsListRequest
        {
            IncludeSteamFriends = false,
            IncludeFacebookFriends = false,
            XboxToken = null
        }, result => {
            _friends = result.Friends;
            DisplayFriends(_friends); // triggers your UI
        }, Fail);
    }

    enum FriendIdType { PlayFabId, Username, Email, DisplayName };

    void AddFriend(FriendIdType idType, string friendId)
    {
        var request = new AddFriendRequest();
        switch (idType)
        {
            case FriendIdType.PlayFabId:
                request.FriendPlayFabId = friendId;
                break;
            case FriendIdType.Username:
                request.FriendUsername = friendId;
                break;
            case FriendIdType.Email:
                request.FriendEmail = friendId;
                break;
            case FriendIdType.DisplayName:
                request.FriendTitleDisplayName = friendId;
                break;
        }
        // Execute request and update friends when we are done
        PlayFabClientAPI.AddFriend(request, result => {
            Debug.Log("Friend added successfully!");
        }, Fail);
    }

    string friendSearch;
    [SerializeField]
    GameObject friendPannel;

    public void InputFriendId(string idIn)
    {
        friendSearch = idIn;
    }


    public void SubmitFriendRequest()
    {
        AddFriend(FriendIdType.PlayFabId, friendSearch);
    }

    public TextMeshProUGUI myId;
    public void OpenCloseFriends()
    {
        friendPannel.SetActive(!friendPannel.activeInHierarchy);
        myId.text = "My id : " + id;
    }
    #endregion Friends
}