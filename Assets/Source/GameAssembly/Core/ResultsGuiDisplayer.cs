using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

namespace SpaceInvadersTask.GameAssembly
{
    public class ResultsGuiDisplayer
    {
        private readonly GameObject resultsGui;
        private readonly TextMeshProUGUI resultsTmpu;

        public ResultsGuiDisplayer(GameObject resultsGui)
        {
            this.resultsGui = resultsGui;
            resultsTmpu = resultsGui.GetComponentInChildren<TextMeshProUGUI>();
        }

        public void ShowResultsScreen(bool win = false)
        {
            StringBuilder resultsBuilder = new();
            resultsBuilder.AppendLine(win ? "You won" : "You lost");
            resultsBuilder.AppendLine("Press R to restart");

            resultsTmpu.text = resultsBuilder.ToString();
            resultsGui.SetActive(true);
        }

        public void HideResultsScreen()
        {
            resultsGui.SetActive(false);
        }
    }
}
