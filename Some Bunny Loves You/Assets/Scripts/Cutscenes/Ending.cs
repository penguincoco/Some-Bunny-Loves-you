using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : Cutscene
{
    public override IEnumerator CutsceneSequence()
    {
        textWriter.enabled = false;

        yield return new WaitForSeconds(0.5f);

        textWriter.enabled = true;
    }
}
