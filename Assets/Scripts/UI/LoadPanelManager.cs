using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
public class LoadPanelManager : MonoBehaviour
{
    public string loadedPath;
    public Button loadButton;
    public GameObject invalid;
    public GameObject malformed;
    public TMP_InputField pathselect;
    public void editPath(string s) {
        malformed.SetActive(false);
        s = s.Replace("\\","/");
        pathselect.text = s;
        bool valid = File.Exists(s);
        invalid.SetActive(!valid);
        loadButton.enabled = valid;
        loadedPath = s;        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Loadwasfile() {
        string s = File.ReadAllText(loadedPath);
        try
        {
            DialogueTreeSave dts = JsonConvert.DeserializeObject<DialogueTreeSave>(s);
            TheOnlySingletonNeeded.save = dts;
            TheOnlySingletonNeeded.loaded = true;
            malformed.SetActive(false);
            SceneManager.LoadScene("WorkScene",LoadSceneMode.Single);
        }
        catch {
            malformed.SetActive(true);
            return;
        }
    }
    public void newTree() {
        TheOnlySingletonNeeded.save = null;
        TheOnlySingletonNeeded.loaded = false;
        SceneManager.LoadScene("WorkScene", LoadSceneMode.Single);
    }

    
}
