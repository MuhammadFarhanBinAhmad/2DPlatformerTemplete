using UnityEngine.UI;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(ScriptableObject_PlayerPassiveEquipment))]
public class CustomEditor_PlayerPassiveEqupiment : Editor
{
    override public void OnInspectorGUI()
    {
        var PPE = target as ScriptableObject_PlayerPassiveEquipment;

        PPE.effect_PlayerHealth = EditorGUILayout.Toggle("AffectPlayerHealth", PPE.effect_PlayerHealth);
        PPE.effect_PlayerSpeed = EditorGUILayout.Toggle("AffectPlayerSpeed", PPE.effect_PlayerSpeed);
        PPE.effect_SwordDamage = EditorGUILayout.Toggle("AffectSwordDamage", PPE.effect_SwordDamage);
        PPE.effect_AxeDamage = EditorGUILayout.Toggle("AffectAxeDamage", PPE.effect_AxeDamage);
        PPE.effect_ArrowStats = EditorGUILayout.Toggle("AffectArrowStats", PPE.effect_ArrowStats);
        PPE.effect_ArrowSpecialAbility = EditorGUILayout.Toggle("AffectArrowSpecialAbility", PPE.effect_ArrowSpecialAbility);

        EditorGUILayout.LabelField("-------------------------------------------");
        EditorGUILayout.LabelField("EqipmentName");
        PPE.ui_EquipmentName = EditorGUILayout.TextField(PPE.ui_EquipmentName);
        EditorGUILayout.LabelField("-------------------------------------------");
        EditorGUILayout.LabelField("SpriteImage");
        PPE.ui_EquipmentIcon = (Sprite)EditorGUILayout.ObjectField(PPE.ui_EquipmentIcon, typeof(Sprite), true);

        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(PPE.effect_PlayerHealth)))
        {
            if (group.visible)
            {
                EditorGUI.indentLevel++;

                EditorGUILayout.LabelField("-------------------------------------------");
                EditorGUILayout.LabelField("PlayerHealth");

                EditorGUILayout.PrefixLabel("ToMultiplyHealth");
                PPE.playerstats_ToMultiplyHealth = EditorGUILayout.Toggle(PPE.playerstats_ToMultiplyHealth);
                EditorGUILayout.PrefixLabel("ToDivideHealth");
                PPE.playerstats_ToDivideHealth = EditorGUILayout.Toggle(PPE.playerstats_ToDivideHealth);
                EditorGUILayout.PrefixLabel("Amount To Multiply/Divide");
                PPE.playerstats_HealthMultiplier_Divider = EditorGUILayout.FloatField(PPE.playerstats_HealthMultiplier_Divider);

                EditorGUI.indentLevel--;
            }
            
        }
        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(PPE.effect_PlayerSpeed)))
        {
            if (group.visible)
            {
                EditorGUI.indentLevel++;

                EditorGUILayout.LabelField("-------------------------------------------");
                EditorGUILayout.LabelField("PlayerSpeed");

                EditorGUILayout.PrefixLabel("ToMultiplySpeed");
                PPE.playerstats_ToMultiplySpeed = EditorGUILayout.Toggle(PPE.playerstats_ToMultiplySpeed);
                EditorGUILayout.PrefixLabel("ToDivideHealth");
                PPE.playerstats_ToDivideSpeed = EditorGUILayout.Toggle(PPE.playerstats_ToDivideSpeed);
                EditorGUILayout.PrefixLabel("Amount To Multiply/Divide");
                PPE.playerstats_SpeedMultiplier_Divider = EditorGUILayout.FloatField(PPE.playerstats_SpeedMultiplier_Divider);
                EditorGUI.indentLevel--;
            }

        }
        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(PPE.effect_SwordDamage)))
        {
            if (group.visible)
            {
                EditorGUI.indentLevel++;

                EditorGUILayout.LabelField("-------------------------------------------");
                EditorGUILayout.LabelField("SwordDamage");

                EditorGUILayout.PrefixLabel("ToMultiplySwordDamage");
                PPE.sword_ToMultiplySwordDamage = EditorGUILayout.Toggle(PPE.sword_ToMultiplySwordDamage);
                EditorGUILayout.PrefixLabel("ToDivideSwordDamage");
                PPE.sword_ToDivideSwordDamage = EditorGUILayout.Toggle(PPE.sword_ToDivideSwordDamage);
                EditorGUILayout.PrefixLabel("Amount To Multiply/Divide");
                PPE.sword_DamageMultiplier_Divider = EditorGUILayout.FloatField(PPE.sword_DamageMultiplier_Divider);
                EditorGUILayout.PrefixLabel("AfterBurn");
                PPE.effect_SwordAfterBurn = EditorGUILayout.Toggle(PPE.effect_SwordAfterBurn);
                EditorGUI.indentLevel--;
            }
        }
        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(PPE.effect_AxeDamage)))
        {
            if (group.visible)
            {
                EditorGUI.indentLevel++;

                EditorGUILayout.LabelField("-------------------------------------------");
                EditorGUILayout.LabelField("AxeDamage");

                EditorGUILayout.PrefixLabel("ToMultiplyAxeDamage");
                PPE.axe_ToMultiplyAxeDamage = EditorGUILayout.Toggle(PPE.axe_ToMultiplyAxeDamage);
                EditorGUILayout.PrefixLabel("ToDivideAxeDamage");
                PPE.axe_ToDivideAxeDamage = EditorGUILayout.Toggle(PPE.axe_ToDivideAxeDamage);
                EditorGUILayout.PrefixLabel("Amount To Multiply/Divide");
                PPE.axe_DamageMultiplier_Divider = EditorGUILayout.FloatField(PPE.axe_DamageMultiplier_Divider);
                EditorGUILayout.PrefixLabel("AfterBurn");
                PPE.effect_AxeAfterBurn = EditorGUILayout.Toggle(PPE.effect_AxeAfterBurn);
                EditorGUI.indentLevel--;
            }
        }
        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(PPE.effect_ArrowStats)))
        {
            if (group.visible)
            {
                EditorGUI.indentLevel++;

                EditorGUILayout.LabelField("-------------------------------------------");
                EditorGUILayout.LabelField("Bow&ArrowDamage");

                EditorGUILayout.PrefixLabel("ToEffectDamage");
                PPE.effect_ArrowDamage = EditorGUILayout.Toggle(PPE.effect_ArrowDamage);
                using (var ArrowDamagegroup = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(PPE.effect_ArrowDamage)))
                {
                    if (ArrowDamagegroup.visible)
                    {
                        EditorGUILayout.PrefixLabel("ToMultiplyBow&ArrowDamage");
                        PPE.bow_ToMultiplyBowDamage = EditorGUILayout.Toggle(PPE.bow_ToMultiplyBowDamage);
                        EditorGUILayout.PrefixLabel("ToDivideBow&ArrowDamage");
                        PPE.bow_ToDivideBowDamage = EditorGUILayout.Toggle(PPE.bow_ToDivideBowDamage);
                        EditorGUILayout.PrefixLabel("Amount To Multiply/Divide");
                        PPE.bow_DamageMultiplier_Divider = EditorGUILayout.FloatField(PPE.bow_DamageMultiplier_Divider);
                    }
                }

                EditorGUILayout.LabelField("-------------------------------------------");

                EditorGUILayout.PrefixLabel("ToEffectFireRate");
                PPE.effect_ArrowFireRate = EditorGUILayout.Toggle(PPE.effect_ArrowFireRate);
                using (var ArrowFireRategroup = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(PPE.effect_ArrowFireRate)))
                {
                    if (ArrowFireRategroup.visible)
                    {

                        EditorGUILayout.PrefixLabel("ToMultiplyBow&ArrowFireRate");
                        PPE.bow_ToMultiplyFirerate = EditorGUILayout.Toggle(PPE.bow_ToMultiplyFirerate);
                        EditorGUILayout.PrefixLabel("ToDivideBow&ArrowDamage");
                        PPE.bow_ToDivideFirerate = EditorGUILayout.Toggle(PPE.bow_ToDivideFirerate);
                        EditorGUILayout.PrefixLabel("Amount To Multiply/Divide");
                        PPE.bow_FirerateMultiplier_Divider = EditorGUILayout.FloatField(PPE.bow_FirerateMultiplier_Divider);
                    }
                }

                EditorGUILayout.LabelField("-------------------------------------------");

                EditorGUILayout.PrefixLabel("ToEffectArrowSpeed");
                PPE.effect_ArrowSpeed = EditorGUILayout.Toggle(PPE.effect_ArrowSpeed);
                using (var ArrowSpeedgroup = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(PPE.effect_ArrowSpeed)))
                {
                    if (ArrowSpeedgroup.visible)
                    {

                        EditorGUILayout.PrefixLabel("ToMultiplyBow&ArrowArrowSpeed");
                        PPE.bow_ToMultiplyArrowSpeed = EditorGUILayout.Toggle(PPE.bow_ToMultiplyArrowSpeed);
                        EditorGUILayout.PrefixLabel("ToDivideBow&ArrowDamage");
                        PPE.bow_ToDivideArrowSpeed = EditorGUILayout.Toggle(PPE.bow_ToDivideArrowSpeed);
                        EditorGUILayout.PrefixLabel("Amount To Multiply/Divide");
                        PPE.bow_ArrowSpeedMultiplier_Divider = EditorGUILayout.FloatField(PPE.bow_ArrowSpeedMultiplier_Divider);
                    }
                }

                EditorGUILayout.LabelField("-------------------------------------------");

                EditorGUILayout.PrefixLabel("AfterBurn");
                PPE.effect_ArrowAfterBurn = EditorGUILayout.Toggle(PPE.effect_ArrowAfterBurn);
                EditorGUI.indentLevel--;
            }
        }
        using (var group = new EditorGUILayout.FadeGroupScope(Convert.ToSingle(PPE.effect_ArrowFireRate)))
        {
            if (group.visible)
            {
                EditorGUI.indentLevel++;

                EditorGUILayout.LabelField("-------------------------------------------");
                EditorGUILayout.LabelField("Bow&ArrowFireRate");

                EditorGUILayout.PrefixLabel("ToMultiplyBow&ArrowFireRate");
                PPE.bow_ToMultiplyFirerate = EditorGUILayout.Toggle(PPE.bow_ToMultiplyFirerate);
                EditorGUILayout.PrefixLabel("ToDivideBow&ArrowFireRate");
                PPE.bow_ToDivideFirerate = EditorGUILayout.Toggle(PPE.bow_ToDivideFirerate);
                EditorGUILayout.PrefixLabel("Amount To Multiply/Divide");
                PPE.bow_FirerateMultiplier_Divider = EditorGUILayout.FloatField(PPE.bow_FirerateMultiplier_Divider);
                EditorGUI.indentLevel--;
            }
        }
    }
}
