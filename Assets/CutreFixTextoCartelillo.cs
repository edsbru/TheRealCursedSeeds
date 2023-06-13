using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutreFixTextoCartelillo : MonoBehaviour
{

    TeacherDialogue teacherDialogue;
    // Start is called before the first frame update
    void Start()
    {
        teacherDialogue = GetComponent<TeacherDialogue>();
    }

    public bool done = false;
    // Update is called once per frame
    void Update()
    {

        if (done)
            return;

        if (teacherDialogue.didDialogueStart)
        {
            done = true;
            
            teacherDialogue.NextDialogueLine();
            teacherDialogue.NextDialogueLine();
        }
        
    }
}
