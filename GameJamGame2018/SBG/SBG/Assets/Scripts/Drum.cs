using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drum : MonoBehaviour
{    
    //private int stringFormerLength;

    // On touch: drum buttons send two digits followed by a space to this string. The DrumCommands() funtion read these and do something(?) (currently only the bird let you enter and leave trance)
    public string noaidiSpeak;
    Spells spell;

    // Use this for initialization
    void Start()
    {
        spell = GetComponent<Spells>();
        //Basic servants: Loddi=bird Boazu=reindeer Guolli=fish 
        //Advanced: Gouvza=bear Gearpmas=snake Voukhu=Bird, but for evil purposes Juovssaheaddji=helper to fight evil and thieves
        //Other: Noaidegazzi=deaceased familly or another noaide Snollagazzi=spirit with responsible for the sami peoples fertility
    }

    // Update is called once per frame
    void Update()
    {
        DrumComands();
    }
    void DrumComands()
    {
            if (noaidiSpeak.EndsWith("bear-bear-bear-"))
            {
            spell.Blast();
            FinishCombo();
            }
    }
void FinishCombo()
    {
        //stringFormerLength = noaidiSpeak.Length;
        noaidiSpeak = "";
        //print("right now");
    }
    #region Buttons
    public void BearButton()
    {
        noaidiSpeak +="bear-";
    }
    public void BirdButton()
    {
        noaidiSpeak += "bird-";
    }
    public void FishButton()
    {
        noaidiSpeak += "fish-";
    }
    public void ReindeerButton()
    {
        noaidiSpeak += "reindeer-";
    }
    public void UpButton()
    {
        noaidiSpeak += "up-";
    }
    public void LeftButton()
    {
        noaidiSpeak += "left-";
    }
    public void RightButton()
    {
        noaidiSpeak += "right-";
    }
    public void DownButton()
    {
        noaidiSpeak += "down-";
    }
    #endregion
}