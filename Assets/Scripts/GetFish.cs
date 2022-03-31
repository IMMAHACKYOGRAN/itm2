using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetFish : MonoBehaviour
{
    public TMPro.TextMeshProUGUI text;
    public GameObject HitOBJ;
    private int CurrnetFish;
    
    public float maxDist;
    public LayerMask lm1;
    public LayerMask lm2;
    public float r;
    private Vector3 origin;
    private Vector3 dir;

    void Start() {
        
    }

    void Update() {
        origin = transform.position;
        dir = transform.forward;
        RaycastHit hit;
        if (Physics.SphereCast(origin, r, dir, out hit, maxDist, lm1, QueryTriggerInteraction.UseGlobal)) {
            CurrnetFish = 1;
            HitOBJ = hit.transform.gameObject;
            DisplayInfo();
        } else if (Physics.SphereCast(origin, r, dir, out hit, maxDist, lm2, QueryTriggerInteraction.UseGlobal)) {
            CurrnetFish = 2;
            HitOBJ = hit.transform.gameObject;
            DisplayInfo();
        }
    }
    
    public void DisplayInfo() {
        if (CurrnetFish == 1) {
            text.text = "The largemouth bass is a carnivorous freshwater gamefish in the Centrarchidae family. It is known for being the state fish of four American states; Georgia, Mississippi, Florida and Alabama.";
        } else if (CurrnetFish == 2) {
            text.text = "The Australian snapper or silver seabream is a species of porgie found in coastal waters of Australia. It does not belong to the snapper family, Lutjanidae. It is highly prized as an edible fish, with a sweet sea taste and a firm texture.";
        }
    }
}
