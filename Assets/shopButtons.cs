using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopButtons : MonoBehaviour
{

    public GameObject CharacterSkins;
    public GameObject SpellSkins;
    public GameObject CharacterSkinButton;
    public GameObject SpellSkinButton;
    public GameObject BackButton;
    public GameObject BackButton2;

    private void Start() {
        CharacterSkins.SetActive(false);
        SpellSkins.SetActive(false);
        CharacterSkinButton.SetActive(true);
        SpellSkinButton.SetActive(true);
        BackButton.SetActive(true);
        BackButton2.SetActive(false);
    }

    public void CharacterSkin() {
        CharacterSkinButton.SetActive(false);
        SpellSkinButton.SetActive(false);
        CharacterSkins.SetActive(true);
        SpellSkins.SetActive(false);
        BackButton.SetActive(false);
        BackButton2.SetActive(true);

    }

    public void SpellSkin() {
        CharacterSkinButton.SetActive(false);
        SpellSkinButton.SetActive(false);
        CharacterSkins.SetActive(false);
        SpellSkins.SetActive(true);
        BackButton.SetActive(false);
        BackButton2.SetActive(true);
    }

    public void reset() {
        CharacterSkins.SetActive(false);
        SpellSkins.SetActive(false);
        CharacterSkinButton.SetActive(true);
        SpellSkinButton.SetActive(true);
        BackButton.SetActive(true);
        BackButton2.SetActive(false);
    }
}
