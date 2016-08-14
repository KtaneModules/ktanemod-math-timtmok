using UnityEngine;

public class ExampleModule : MonoBehaviour
{
    public KMSelectable[] buttons;

    int correctIndex;
<<<<<<< HEAD
=======
    bool isActivated = false;
>>>>>>> 269498d64dd5143303ee2574f4f1ec320083d6f7

    void Start()
    {
        Init();
<<<<<<< HEAD
=======

        GetComponent<KMBombModule>().OnActivate += ActivateModule;
>>>>>>> 269498d64dd5143303ee2574f4f1ec320083d6f7
    }

    void Init()
    {
        correctIndex = Random.Range(0, 4);

        for(int i = 0; i < buttons.Length; i++)
        {
            string label = i == correctIndex ? "O" : "X";

            TextMesh buttonText = buttons[i].GetComponentInChildren<TextMesh>();
            buttonText.text = label;
            int j = i;
            buttons[i].OnInteract += delegate () { OnPress(j == correctIndex); return false; };
        }
    }

<<<<<<< HEAD
    void OnPress(bool correctButton)
    {
        Debug.Log("Pressed " + correctButton + " button");
        if(correctButton)
        {
            GetComponent<KMBombModule>().HandlePass();
        }
        else
        {
            GetComponent<KMBombModule>().HandleStrike();
=======
    void ActivateModule()
    {
        isActivated = true;
    }

    void OnPress(bool correctButton)
    {
        GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);

        if (!isActivated)
        {
            Debug.Log("Pressed button before module has been activated!");
            GetComponent<KMBombModule>().HandleStrike();
        }
        else
        {
            Debug.Log("Pressed " + correctButton + " button");
            if (correctButton)
            {
                GetComponent<KMBombModule>().HandlePass();
            }
            else
            {
                GetComponent<KMBombModule>().HandleStrike();
            }
>>>>>>> 269498d64dd5143303ee2574f4f1ec320083d6f7
        }
    }
}
