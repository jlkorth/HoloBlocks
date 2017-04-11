﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class VoiceController : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {
        // Creation Commands
        keywords.Add("Make block", () =>
        {
            this.BroadcastMessage("OnCreateCube");
        });

        keywords.Add("Make box", () =>
        {
            this.BroadcastMessage("OnCreateCube");
        });

        keywords.Add("Make square", () =>
        {
            this.BroadcastMessage("OnCreateCube");
        });

        keywords.Add("Make ball", () =>
        {
            this.BroadcastMessage("OnCreateSphere");
        });

        keywords.Add("Make circle", () =>
        {
            this.BroadcastMessage("OnCreateSphere");
        });

        keywords.Add("Make tube", () =>
        {
            this.BroadcastMessage("OnCreateCylinder");
        });

        keywords.Add("Make triangle", () =>
        {
            this.BroadcastMessage("OnCreatePyramid");
        });

        keywords.Add("Make ramp", () =>
        {
            this.BroadcastMessage("OnCreateSlope");
        });

        // Color Commands
        keywords.Add("Color red", () =>
        {
            this.BroadcastMessage("OnChangeColorToRed", CanvasGazeGestureController.FocusedObject);
        });

        keywords.Add("Color blue", () =>
        {
            this.BroadcastMessage("OnChangeColorToBlue", CanvasGazeGestureController.FocusedObject);
        });

        keywords.Add("Color green", () =>
        {
            this.BroadcastMessage("OnChangeColorToGreen", CanvasGazeGestureController.FocusedObject);
        });

        keywords.Add("Color yellow", () =>
        {
            this.BroadcastMessage("OnChangeColorToYellow", CanvasGazeGestureController.FocusedObject);
        });

        keywords.Add("Color white", () =>
        {
            this.BroadcastMessage("OnChangeColorToWhite", CanvasGazeGestureController.FocusedObject);
        });

        keywords.Add("Make red", () =>
        {
            this.BroadcastMessage("OnChangeColorToRed", CanvasGazeGestureController.FocusedObject);
        });

        keywords.Add("Make blue", () =>
        {
            this.BroadcastMessage("OnChangeColorToBlue", CanvasGazeGestureController.FocusedObject);
        });

        keywords.Add("Make green", () =>
        {
            this.BroadcastMessage("OnChangeColorToGreen", CanvasGazeGestureController.FocusedObject);
        });

        keywords.Add("Make yellow", () =>
        {
            this.BroadcastMessage("OnChangeColorToYellow", CanvasGazeGestureController.FocusedObject);
        });

        keywords.Add("Make white", () =>
        {
            this.BroadcastMessage("OnChangeColorToWhite", CanvasGazeGestureController.FocusedObject);
        });

        // Resize Commands
        keywords.Add("Bigger", () =>
        {
            this.BroadcastMessage("OnIncreaseGameObjectSize", CanvasGazeGestureController.FocusedObject);
        });

        keywords.Add("Smaller", () =>
        {
            this.BroadcastMessage("OnDecreaseGameObjectSize", CanvasGazeGestureController.FocusedObject);
        });

        keywords.Add("Make bigger", () =>
        {
            this.BroadcastMessage("OnIncreaseGameObjectSize", CanvasGazeGestureController.FocusedObject);
        });

        keywords.Add("Make smaller", () =>
        {
            this.BroadcastMessage("OnDecreaseGameObjectSize", CanvasGazeGestureController.FocusedObject);
        });

        // Deletion Commands
        keywords.Add("Erase", () =>
        {
            this.BroadcastMessage("OnDelete", CanvasGazeGestureController.FocusedObject);
        });

        keywords.Add("Erase blocks", () =>
        {
            this.BroadcastMessage("OnDeleteAllCubes");
        });

        keywords.Add("Erase balls", () =>
        {
            this.BroadcastMessage("OnDeleteAllSpheres");
        });

        keywords.Add("Erase ramps", () =>
        {
            this.BroadcastMessage("OnDeleteAllSlopes");
        });

        keywords.Add("Erase triangles", () =>
        {
            this.BroadcastMessage("OnDeleteAllPyramids");
        });

        keywords.Add("Erase tubes", () =>
        {
            this.BroadcastMessage("OnDeleteAllCylinders");
        });

        keywords.Add("Erase all", () =>
        {
            this.BroadcastMessage("OnClearCanvas");
        });

        // Spin commands
        keywords.Add("Turn", () =>
        {
            this.BroadcastMessage("OnTurnObject", CanvasGazeGestureController.FocusedObject);
        });

        keywords.Add("Flip", () =>
        {
            this.BroadcastMessage("OnFlipObject", CanvasGazeGestureController.FocusedObject);
        });

        // Copy Command
        keywords.Add("Copy", () =>
        {
            this.BroadcastMessage("OnCopy", CanvasGazeGestureController.FocusedObject);
        });

        // Paste Command
        keywords.Add("Paste", () =>
        {
            this.BroadcastMessage("OnPaste");
        });

        // Gravity Commands
        keywords.Add("Gravity on", () =>
        {
            this.BroadcastMessage("TurnOnPhysics");
        });

        keywords.Add("Gravity off", () =>
        {
            this.BroadcastMessage("TurnOffPhysics");
        });

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}
