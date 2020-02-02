using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiagnosisUI : MonoBehaviour
{
    public Text patientTitle;
    public Text patientDescription;

    // Start is called before the first frame update
    void Start()
    {
        if (GameplayData.LevelsCompleted == 0) {
            patientTitle.text = "Patient #1: Mixed Emotions";
            patientDescription.text = "Patient #1 is prone to sadness and needs help sorting out a whirlwind of mixed emotions. Bring balance to this psyche without letting the blues take over!";
        } else if (GameplayData.LevelsCompleted == 1) {
            patientTitle.text = "Patient #2: Headache";
            patientDescription.text = "Patient #2 is suffereng from a headache and needs to find joy amid a barrage of disgust. Help this psyche transform sadness into joy.";
        } else if (GameplayData.LevelsCompleted == 2) {
            patientTitle.text = "Patient #3: Denial";
            patientDescription.text = "Patient #3 is suffering from denial and needs to find calm amid conflicting emotions. Help this psyche transform agitation into a more mellow mood.";
        } else if (GameplayData.LevelsCompleted == 3) {
            patientTitle.text = "Patient #4: Bored";
            patientDescription.text = "Patient #4 is suffering from boredom and emotional congestion. Help bring clarity to this psyche by sorting all those emotions into balance.";
        } else if (GameplayData.LevelsCompleted == 4) {
            patientTitle.text = "Patient #5: Sadness";
            patientDescription.text = "Patient #5 is biased towards sadness and has difficulty finding joy. Help to bring balance to this psyche despite the scattered emotional terrain.";
        } else if (GameplayData.LevelsCompleted == 5) {
            patientTitle.text = "Patient #6: Resilience";
            patientDescription.text = "Patient #6 has resilience at heart, and alternates between anger and sadness. This psyche only needs to feel more joy, and you can help to make it so.";
        } else if (GameplayData.LevelsCompleted == 6) {
            patientTitle.text = "Patient #7: Resistance";
            patientDescription.text = "Patient #6 has resistance at heart, and is quick to rage. Help this psyche to feel the flow and put anger in its place.";
        } else if (GameplayData.LevelsCompleted == 7) {
            patientTitle.text = "Patient #8: Lost";
            patientDescription.text = "Patient #8 feels lost, with a tendency towards joy. Too many emotions are bottled up with nowhere to go. Help this psyche find balance again and sort out those emotions.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
