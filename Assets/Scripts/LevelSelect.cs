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
        levels.Add("bahi", "Level5"); // rainbow, star, pinata, snowflake

        levels.Add("dabc", "Level6"); // tree, star, rainbow, clover
        levels.Add("hdea", "Level7"); // pinata, tree, eggs, star
        levels.Add("ahdf", "Level8"); // star, pinata, tree, pumpkin
        levels.Add("fdha", "Level9"); // pumpkin, tree, pinata, star
        levels.Add("dhbf", "Level10"); // tree, pinata, rainbow, pumpkin

        levels.Add("caei", "Level11"); // clover, star, eggs, snowflake
        levels.Add("deba", "Level12"); // tree, eggs, rainbow, star
        levels.Add("ageh", "Level13"); // star, panda, eggs, pinata
        levels.Add("begc", "Level14"); // rainbow, eggs, panda, clover
        levels.Add("acgi", "Level15"); // star, clover, panda, snowflake
        
        levels.Add("abcd", "Level16"); // star, rainbow, clover, tree
        levels.Add("dcbf", "Level17"); // tree, clover, rainbow, pumpkin
        levels.Add("heab", "Level18"); // pinata, eggs, star, rainbow
        levels.Add("faid", "Level19"); // pumpkin, star, snowflake, tree
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
