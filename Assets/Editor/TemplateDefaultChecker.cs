#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using PlayFab;

[InitializeOnLoad]
public class TemplateDefaultChecker
{
    static TemplateDefaultChecker()
    {
        EditorApplication.delayCall += CheckSettings;
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        BuildPlayerWindow.RegisterBuildPlayerHandler(OnBuildPlayer);
    }

    private static void CheckSettings()
    {
        bool playerSettingsValid = PlayerSettings.companyName != "Company Name" && PlayerSettings.productName != "Game Name";
        bool playFabSettingsValid = !string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId);

        if (!playerSettingsValid)
        {
            if (EditorUtility.DisplayDialog(
                "Player Settings Warning",
                "Your player settings are still set to the default values.\n\n" +
                "Company Name: \"Company Name\"\n" +
                "Product Name: \"Game Name\"\n\n" +
                "Would you like to open Player Settings to update them?",
                "Yes",
                "No"))
            {
                SettingsService.OpenProjectSettings("Project/Player");
            }
        }

        if (!playFabSettingsValid)
        {
            if (EditorUtility.DisplayDialog(
                "PlayFab Settings Warning",
                "You are currently not logged into PlayFab.\n\n" +
                "Please open the PlayFab EdEx window and log in to update your settings.",
                "Open PlayFab EdEx",
                "Cancel"))
            {
                OpenPlayFabEdExWindow();
            }
        }
    }

    private static void OpenPlayFabEdExWindow()
    {
        EditorApplication.ExecuteMenuItem("Window/PlayFab/Editor Extensions");
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            CheckSettings();
        }
    }

    private static void OnBuildPlayer(BuildPlayerOptions options)
    {
        if (PlayerSettings.companyName == "Company Name" || PlayerSettings.productName == "Game Name")
        {
            EditorUtility.DisplayDialog(
                "Build Error",
                "Cannot build the project. Your player settings are still set to the default values.\n\n" +
                "Company Name: \"Company Name\"\n" +
                "Product Name: \"Game Name\"\n\n" +
                "Please update these values in the Player Settings.",
                "OK");
            throw new BuildPlayerWindow.BuildMethodException();
        }

        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            EditorUtility.DisplayDialog(
                "Build Error",
                "Cannot build the project. You are currently not logged into PlayFab.\n\n" +
                "Please open the PlayFab EdEx window and log in to update your settings.",
                "OK");
            throw new BuildPlayerWindow.BuildMethodException();
        }

        BuildPlayerWindow.DefaultBuildMethods.BuildPlayer(options);
    }
}
#endif