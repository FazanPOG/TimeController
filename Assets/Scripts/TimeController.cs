using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;

public class TimeController : MonoBehaviour
{
    [SerializeField] private string url;

    private string moscowTime;

    [DllImport("__Internal")] static extern void AlertMoscowTime(string moscowTime);

    public event Action<string> OnMoscowTimeUpdated;

    public void GetMoscowTime() 
    {
        StartCoroutine(GetRequest(url));

        AlertMoscowTime(moscowTime);
    }

    IEnumerator GetRequest(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        string content = request.downloadHandler.text;
        moscowTime = GetCuttedMoscowTimeContent(content);

        OnMoscowTimeUpdated?.Invoke(moscowTime);

        Debug.Log(request.downloadHandler.text);
        Debug.Log(moscowTime);
    }

    private string GetCuttedMoscowTimeContent(string content) 
    {
        int index = content.IndexOf("$( document ).ready(function()");
        string cropped—ontent = content.Substring(index + 69);
        string moscowTime = cropped—ontent.Remove(8);
        return moscowTime;
    }
}
