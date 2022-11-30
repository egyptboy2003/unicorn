using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour
{
    public Dictionary<string, string> levels = new Dictionary<string, string>();
    public List<GameObject> selected;
    private GameObject errorText;
    // Start is called before the first frame update

    private void Start()
    {
        errorText = GameObject.Find("error msg");
        errorText.SetActive(false);

        // Level Codes
        levels.Add("eadf", "Level1"); // eggs, star, tree, pumpkin
        levels.Add("ihbg", "Level2"); // snowflake, pinata, rainbow, panda
        levels.Add("cgbf", "Level3"); // clover, panda, rainbow, pumpkin
        levels.Add("ahde", "Level4"); // star, pinata, tree, eggs
    }        

    public void ButtonPush(GameObject button)
    {
        button.GetComponent<Button>().interactable = false;
        selected.Add(button);
        if (selected.Count >= 4)
        {
            List<string> names = new List<string>();
            foreach(GameObject element in selected)
            {
                names.Add(element.name);
            }
            LoadLevel(string.Concat(names));
        }
    }

    public void ClearSelection()
    {
        foreach(GameObject element in selected)
        {
            element.GetComponent<Button>().interactable = true;
        }
        selected.Clear();
    }
    // Validates and loads a level code.
    void LoadLevel(string levelCode)
    {
        if (levels.ContainsKey(levelCode))
        {
            SceneManager.LoadSceneAsync(levels[levelCode]);
        } else
        {
            ClearSelection();
            StartCoroutine(FlashError());
        }
    }

    IEnumerator FlashError()
    {
        errorText.SetActive(true);
        yield return new WaitForSeconds(2);
        errorText.SetActive(false);
    }
}
