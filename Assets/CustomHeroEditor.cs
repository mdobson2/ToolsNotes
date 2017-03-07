using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MyHeroClass))]
public class CustomHeroEditor : Editor {

    MyHeroClass myHero;
    public string[] myChoices = new string[] {"Damage", "Healing"};

    int mySpellType = 0;

    void OnEnable()
    {
        myHero = (MyHeroClass)target;
        mySpellType = myHero.mySpell.isDamaging ? 0 : 1;
    }

    public override void OnInspectorGUI()
    {
        DrawBasicInfo();
        DrawSpellInfo();
        //base.OnInspectorGUI();
    }

    public void DrawBasicInfo()
    {
        EditorGUILayout.LabelField("Basic Info", EditorStyles.boldLabel);
        EditorGUILayout.BeginVertical("box");
        {
            myHero.healthAmt = EditorGUILayout.IntSlider("Health: ", myHero.healthAmt, 1, 100);
            ProgressBar(myHero.healthAmt / 100f, "Health");
            myHero.manaPool = EditorGUILayout.IntSlider("Mana: ", myHero.manaPool, 1, 50);
            ProgressBar(myHero.manaPool / 50f, "Mana");
        }
        EditorGUILayout.EndVertical();
    }

    void DrawSpellInfo()
    {
        EditorGUILayout.LabelField("Spell Info", EditorStyles.boldLabel);
        EditorGUILayout.BeginVertical("box");
        {
            mySpellType = GUILayout.SelectionGrid(mySpellType, myChoices, 2);
            myHero.mySpell.spellName = EditorGUILayout.TextField("Spell Name: ", myHero.mySpell.spellName);
            myHero.mySpell.manaCost = EditorGUILayout.IntField("Mana Cost: ", myHero.mySpell.manaCost);
            string s;
            if(mySpellType == 0)
            {
                s = "Damage Amount: ";
            }
            else
            {
                s = "Healing Amount: ";
            }
            myHero.mySpell.totalAmount = EditorGUILayout.IntSlider(s, myHero.mySpell.totalAmount, 1, 25);
        }
        EditorGUILayout.EndVertical();
    }

    public void ProgressBar(float value, string label)
    {
        Rect getRect = GUILayoutUtility.GetRect(0, 18, "TextField");
        EditorGUI.ProgressBar(getRect, value, label);
    }
}
