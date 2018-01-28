using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class GetText : MonoBehaviour
{
    void Update()
    {
        Cursor.visible = true;
        Screen.lockCursor = false;

        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("GameScene");
        }

        //or simply use the line below, 
        //input.onEndEdit.AddListener(SubmitName);  // This also works
    }

}


