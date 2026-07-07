using System;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PSCAT1EYDNEOY
{
    internal class Patches
    {
        [HarmonyPatch(typeof(Talker), "Update")]
        internal static class TalkerUpdatePatch
        {
            [HarmonyPrefix]
            private static bool Prefix(Talker __instance)
            {
                if (__instance.body)
                {
                    float num = Mathf.Clamp01(1f + __instance.body.happiness * 0.009f);
                    if (__instance.newTalkTime > 120f)
                    {
                        __instance.lastLineType = "";
                    }
                    Limb limb = null;
                    Limb limb2 = null;
                    Limb limb3 = null;
                    foreach (Limb limb4 in __instance.body.limbs)
                    {
                        if (!limb4.dismembered)
                        {
                            if (limb4.muscleHealth < 50f)
                            {
                                limb = limb4;
                            }
                            if (limb4.skinHealth < 50f)
                            {
                                limb2 = limb4;
                            }
                            if (limb4.infectionAmount > 5f)
                            {
                                limb3 = limb4;
                            }
                        }
                    }
                    if (__instance.body.conscious)
                    {
                        __instance.newTalkTime += Time.deltaTime;
                    }
                    if (__instance.body.averagePain > 80f && __instance.newTalkTime > 5f && !Body.censorPain)
                    {
                        __instance.lastLineType = "";
                        __instance.Talk(Locale.GetCharacter("bigpain"), null, false, true);
                    }
                    else if (!__instance.body.breathing && __instance.newTalkTime > 8f)
                    {
                        __instance.lastLineType = "";
                        __instance.Talk(Locale.GetCharacter("cantBreathe"), null, false, true);
                        __instance.PromptTraderResponse("dying");
                    }
                    else if (__instance.body.totalHappiness < -62f && __instance.newTalkTime > 30f && __instance.lastLineType != "miserable" && !Body.censorMood)
                    {
                        __instance.lastLineType = "miserable";
                        __instance.Talk(Locale.GetCharacter("miserable"), null, false, true);
                        __instance.PromptTraderResponse("depressed");
                    }
                    else if (__instance.body.isCriticallyDying && __instance.newTalkTime > 12f && !Body.censorPain)
                    {
                        __instance.lastLineType = "lastmoments";
                        __instance.Talk(Locale.GetCharacter("lastmoments"), null, false, true);
                        __instance.PromptTraderResponse("dying");
                    }
                    else if (__instance.body.GetComponent<Painkillers>() && __instance.body.GetComponent<Painkillers>().actualOpiateReception < -15f && __instance.newTalkTime > 20f && __instance.lastLineType != "opiatewithdrawal")
                    {
                        __instance.lastLineType = "opiatewithdrawal";
                        __instance.Talk(Locale.GetCharacter("opiatewithdrawal"), null, false, true);
                    }
                    else if (__instance.body.hunger < 30f * num && __instance.newTalkTime > 25f && __instance.lastLineType != "starving")
                    {
                        __instance.lastLineType = "starving";
                        __instance.Talk(Locale.GetCharacter("starving"), null, false, true);
                        __instance.PromptTraderResponse("hungry");
                    }
                    else if (__instance.body.thirst < 30f && __instance.newTalkTime > 25f && __instance.lastLineType != "dehydrated")
                    {
                        __instance.lastLineType = "dehydrated";
                        __instance.Talk(Locale.GetCharacter("dehydrated"), null, false, true);
                        __instance.PromptTraderResponse("thirsty");
                    }
                    else if (__instance.body.stamina < 25f && __instance.newTalkTime > 10f && __instance.lastLineType != "exhausted")
                    {
                        __instance.lastLineType = "exhausted";
                        __instance.Talk(Locale.GetCharacter("exhausted"), null, false, true);
                    }
                    else if (__instance.body.temperature < 31f && __instance.newTalkTime > 22f && __instance.lastLineType != "freezing")
                    {
                        __instance.lastLineType = "freezing";
                        __instance.Talk(Locale.GetCharacter("freezing"), null, false, true);
                        __instance.PromptTraderResponse("cold");
                    }
                    else if (__instance.body.temperature > 40f && __instance.newTalkTime > 22f && __instance.lastLineType != "hot")
                    {
                        __instance.lastLineType = "hot";
                        __instance.Talk(Locale.GetCharacter("hot"), null, false, true);
                        __instance.PromptTraderResponse("hot");
                    }
                    else if (__instance.body.brainHealth < 95f && __instance.newTalkTime > 16f && __instance.lastLineType != "braindamage")
                    {
                        __instance.lastLineType = "braindamage";
                        __instance.Talk(Locale.GetCharacter("braindamaged"), null, false, true);
                        __instance.PromptTraderResponse("braindamaged");
                    }
                    else if (__instance.body.totalBleedSpeed > 0.03f && __instance.newTalkTime > 35f && __instance.lastLineType != "bleeding")
                    {
                        __instance.lastLineType = "bleeding";
                        __instance.Talk(Locale.GetCharacter((__instance.body.totalBleedSpeed > 0.142f) ? "bleedingheavy" : "bleeding"), null, false, true);
                        __instance.PromptTraderResponse("bleeding");
                    }
                    else if (__instance.body.sicknessAmount > 70f && __instance.newTalkTime > 35f && __instance.lastLineType != "verysick")
                    {
                        __instance.lastLineType = "verysick";
                        __instance.Talk(Locale.GetCharacter("verysick"), null, false, true);
                    }
                    else if (__instance.body.totalHappiness < -46f && __instance.newTalkTime > 36f && __instance.lastLineType != "depressed" && !Body.censorMood)
                    {
                        __instance.lastLineType = "depressed";
                        __instance.Talk(Locale.GetCharacter("depressed"), null, false, true);
                        __instance.PromptTraderResponse("depressed");
                    }
                    else if (__instance.body.stamina < 55f && __instance.newTalkTime > 15f && __instance.lastLineType != "exerted")
                    {
                        __instance.lastLineType = "exerted";
                        __instance.Talk(Locale.GetCharacter("exerted"), null, false, true);
                    }
                    else if (__instance.body.averagePain > 35f && __instance.newTalkTime > 11f && __instance.lastLineType != "pain")
                    {
                        foreach (Limb limb5 in __instance.body.limbs)
                        {
                            if (limb5.pain > 35f)
                            {
                                __instance.lastLineType = "pain";
                                __instance.Talk(Locale.GetCharacter("pain"), limb5, false, true);
                                __instance.PromptTraderResponse("pain");
                                break;
                            }
                        }
                    }
                    else if (__instance.body.energy < 15f && __instance.newTalkTime > 20f && __instance.lastLineType != "verytired")
                    {
                        __instance.lastLineType = "verytired";
                        __instance.Talk(Locale.GetCharacter("verytired"), null, false, true);
                    }
                    else if (limb3 && __instance.newTalkTime > 60f && __instance.lastLineType != "limbinfected")
                    {
                        __instance.lastLineType = "limbinfected";
                        __instance.Talk(Locale.GetCharacter("limbinfected"), limb3, false, true);
                    }
                    else if (limb2 && __instance.newTalkTime > 60f && __instance.lastLineType != "limbskin")
                    {
                        __instance.lastLineType = "limbskin";
                        __instance.Talk(Locale.GetCharacter("limbskin"), limb2, false, true);
                    }
                    else if (limb && __instance.newTalkTime > 70f && __instance.lastLineType != "limbmuscle")
                    {
                        __instance.lastLineType = "limbmuscle";
                        __instance.Talk(Locale.GetCharacter("limbmuscle"), limb, false, true);
                    }
                    else if (__instance.body.totalHappiness < -30f && __instance.newTalkTime > 45f && __instance.lastLineType != "gloomy")
                    {
                        __instance.lastLineType = "gloomy";
                        __instance.Talk(Locale.GetCharacter("gloomy"), null, false, true);
                        __instance.PromptTraderResponse("sad");
                    }
                    else if (__instance.body.consciousness < 70f && __instance.newTalkTime > 30f && __instance.lastLineType != "confused")
                    {
                        __instance.lastLineType = "confused";
                        __instance.Talk(Locale.GetCharacter("confused"), null, false, true);
                    }
                    else if (__instance.body.energy < 35f && __instance.newTalkTime > 50f && __instance.lastLineType != "tired")
                    {
                        __instance.lastLineType = "tired";
                        __instance.Talk(Locale.GetCharacter("tired"), null, false, true);
                    }
                    else if (__instance.body.hunger < 70f * num && __instance.newTalkTime > 100f && __instance.lastLineType != "hungry")
                    {
                        __instance.lastLineType = "hungry";
                        __instance.Talk(Locale.GetCharacter("hungry"), null, false, true);
                        __instance.PromptTraderResponse("hungry");
                    }
                    else if (__instance.body.thirst < 70f && __instance.newTalkTime > 100f && __instance.lastLineType != "thirsty")
                    {
                        __instance.lastLineType = "thirsty";
                        __instance.Talk(Locale.GetCharacter("thirsty"), null, false, true);
                        __instance.PromptTraderResponse("thirsty");
                    }
                    else if (__instance.body.dirtyness > 70f && __instance.newTalkTime > 85f && __instance.lastLineType != "dirty")
                    {
                        __instance.lastLineType = "dirty";
                        __instance.Talk(Locale.GetCharacter("dirty"), null, false, true);
                        __instance.PromptTraderResponse("dirty");
                    }
                    else if (__instance.body.overEncumberance > 0.3f && __instance.newTalkTime > 85f && __instance.lastLineType != "encumbered")
                    {
                        __instance.lastLineType = "encumbered";
                        __instance.Talk(Locale.GetCharacter("encumbered"), null, false, true);
                        __instance.PromptTraderResponse("encumbered");
                    }
                    else if (__instance.body.wetness > 70f && __instance.newTalkTime > 60f && __instance.lastLineType != "wet")
                    {
                        __instance.lastLineType = "wet";
                        __instance.Talk(Locale.GetCharacter("wet"), null, false, true);
                    }
                    else if (__instance.body.temperature < 35f && __instance.newTalkTime > 50f && __instance.lastLineType != "cold")
                    {
                        __instance.lastLineType = "cold";
                        __instance.Talk(Locale.GetCharacter("cold"), null, false, true);
                        __instance.PromptTraderResponse("cold");
                    }
                    else if (__instance.body.temperature > 38f && __instance.newTalkTime > 50f && __instance.lastLineType != "warm")
                    {
                        __instance.lastLineType = "warm";
                        __instance.Talk(Locale.GetCharacter("warm"), null, false, true);
                        __instance.PromptTraderResponse("hot");
                    }
                    else if (__instance.body.totalHappiness < -13f && __instance.newTalkTime > 55f && __instance.lastLineType != "sad")
                    {
                        __instance.lastLineType = "sad";
                        __instance.Talk(Locale.GetCharacter("sad"), null, false, true);
                        __instance.PromptTraderResponse("sad");
                    }
                    else if (__instance.body.happiness > -30f && __instance.body.GetComponent<Painkillers>() && __instance.body.GetComponent<Painkillers>().actualOpiateReception > 20f && __instance.newTalkTime > 30f && __instance.lastLineType != "opiated")
                    {
                        __instance.lastLineType = "opiated";
                        __instance.Talk(Locale.GetCharacter("opiated"), null, false, true);
                    }
                    else if (__instance.body.happiness <= -30f && __instance.body.GetComponent<Painkillers>() && __instance.body.GetComponent<Painkillers>().actualOpiateReception > 20f && __instance.newTalkTime > 30f && __instance.lastLineType != "opiatedsad")
                    {
                        __instance.lastLineType = "opiatedsad";
                        __instance.Talk(Locale.GetCharacter("opiatedsad"), null, false, true);
                    }
                    else if (__instance.body.sicknessAmount > 20f && __instance.newTalkTime > 60f && __instance.lastLineType != "sick")
                    {
                        __instance.lastLineType = "sick";
                        __instance.Talk(Locale.GetCharacter("sick"), null, false, true);
                    }
                    __instance.timeSinceTalked += __instance.clampedUnscaledDeltaTime * __instance.body.consciousness * 0.01f;
                    if (!__instance.body.conscious && __instance.text.text != "")
                    {
                        __instance.currentString = "";
                        __instance.text.text = "";
                    }
                }
                else
                {
                    __instance.timeSinceTalked += __instance.clampedUnscaledDeltaTime * (1f + __instance.talkTimeMult);
                }
                if (__instance.currentString != "")
                {
                    int num2 = Mathf.Clamp((int)(__instance.timeSinceTalked * 18f), 0, __instance.currentString.Length);
                    __instance.text.text = __instance.currentString.Substring(0, num2);
                    if (num2 != __instance.lastStringProgress && char.IsLetterOrDigit(__instance.currentString[Mathf.Clamp(num2, 0, __instance.currentString.Length - 1)]))
                    {
                        if (__instance.body)
                        {
                            if (!__instance.impairedSpeech)
                            {
                                Sound.Play("speech", __instance.transform.position, false, true, null, 1f, 1f, false, false);
                            }
                            else
                            {
                                Sound.Play("speechbad", __instance.transform.position, false, true, null, 1f, 1f, false, false);
                            }
                            __instance.body.eatTime = Random.Range(0.05f, 0.1f) * (char.IsUpper(__instance.currentString[Mathf.Clamp(num2, 0, __instance.currentString.Length - 1)]) ? 2.5f : 1f);
                        }
                        else
                        {
                            if (__instance.trader)
                            {
                                __instance.trader.talkTime = Random.Range(0.05f, 0.1f);
                            }
                            Sound.Play(__instance.talkSoundCustom, __instance.transform.position, false, true, null, 1f, 1f, false, false);
                        }
                    }
                    __instance.lastStringProgress = num2;
                    if (__instance.timeSinceTalked > (float)__instance.currentString.Length / 18f + 3f)
                    {
                        __instance.currentString = "";
                        __instance.text.text = "";
                        __instance.lastStringProgress = -1;
                    }
                }
                if (__instance.body)
                {
                    if (__instance.body.conscious && !__instance.wasConscious && __instance.body.averagePain < 21f)
                    {
                        __instance.StartCoroutine(__instance.SayWakeUp());
                    }
                    __instance.wasConscious = __instance.body.conscious;
                }
                return false;
            }
        }
    }
}
