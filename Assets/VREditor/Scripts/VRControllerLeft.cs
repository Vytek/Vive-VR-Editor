﻿namespace VRTK.Examples
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class VRControllerLeft: MonoBehaviour
    {
        private PopulatePrefabsContent content;
        private PopulateExistingContent content2;

        private void Start()
        {
            if (GetComponent<VRTK_ControllerEvents>() == null)
            {
                //VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
                return;
            }

            content = GameObject.Find("PrefabsContent").GetComponent<PopulatePrefabsContent>();
            content2 = GameObject.Find("ExistingContent").GetComponent<PopulateExistingContent>();
            StateManager.Instance.menu = GameObject.Find("PrefabCanvas");

            //Setup controller event listeners
            GetComponent<VRTK_ControllerEvents>().TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
            GetComponent<VRTK_ControllerEvents>().TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);

            GetComponent<VRTK_ControllerEvents>().TriggerTouchStart += new ControllerInteractionEventHandler(DoTriggerTouchStart);
            GetComponent<VRTK_ControllerEvents>().TriggerTouchEnd += new ControllerInteractionEventHandler(DoTriggerTouchEnd);

            GetComponent<VRTK_ControllerEvents>().TriggerHairlineStart += new ControllerInteractionEventHandler(DoTriggerHairlineStart);
            GetComponent<VRTK_ControllerEvents>().TriggerHairlineEnd += new ControllerInteractionEventHandler(DoTriggerHairlineEnd);

            GetComponent<VRTK_ControllerEvents>().TriggerClicked += new ControllerInteractionEventHandler(DoTriggerClicked);
            GetComponent<VRTK_ControllerEvents>().TriggerUnclicked += new ControllerInteractionEventHandler(DoTriggerUnclicked);

            GetComponent<VRTK_ControllerEvents>().TriggerAxisChanged += new ControllerInteractionEventHandler(DoTriggerAxisChanged);

            GetComponent<VRTK_ControllerEvents>().GripPressed += new ControllerInteractionEventHandler(DoGripPressed);
            GetComponent<VRTK_ControllerEvents>().GripReleased += new ControllerInteractionEventHandler(DoGripReleased);

            GetComponent<VRTK_ControllerEvents>().GripTouchStart += new ControllerInteractionEventHandler(DoGripTouchStart);
            GetComponent<VRTK_ControllerEvents>().GripTouchEnd += new ControllerInteractionEventHandler(DoGripTouchEnd);

            GetComponent<VRTK_ControllerEvents>().GripHairlineStart += new ControllerInteractionEventHandler(DoGripHairlineStart);
            GetComponent<VRTK_ControllerEvents>().GripHairlineEnd += new ControllerInteractionEventHandler(DoGripHairlineEnd);

            GetComponent<VRTK_ControllerEvents>().GripClicked += new ControllerInteractionEventHandler(DoGripClicked);
            GetComponent<VRTK_ControllerEvents>().GripUnclicked += new ControllerInteractionEventHandler(DoGripUnclicked);

            GetComponent<VRTK_ControllerEvents>().GripAxisChanged += new ControllerInteractionEventHandler(DoGripAxisChanged);

            GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadPressed);
            GetComponent<VRTK_ControllerEvents>().TouchpadReleased += new ControllerInteractionEventHandler(DoTouchpadReleased);

            GetComponent<VRTK_ControllerEvents>().TouchpadTouchStart += new ControllerInteractionEventHandler(DoTouchpadTouchStart);
            GetComponent<VRTK_ControllerEvents>().TouchpadTouchEnd += new ControllerInteractionEventHandler(DoTouchpadTouchEnd);

            GetComponent<VRTK_ControllerEvents>().TouchpadAxisChanged += new ControllerInteractionEventHandler(DoTouchpadAxisChanged);

            GetComponent<VRTK_ControllerEvents>().ButtonOnePressed += new ControllerInteractionEventHandler(DoButtonOnePressed);
            GetComponent<VRTK_ControllerEvents>().ButtonOneReleased += new ControllerInteractionEventHandler(DoButtonOneReleased);

            GetComponent<VRTK_ControllerEvents>().ButtonOneTouchStart += new ControllerInteractionEventHandler(DoButtonOneTouchStart);
            GetComponent<VRTK_ControllerEvents>().ButtonOneTouchEnd += new ControllerInteractionEventHandler(DoButtonOneTouchEnd);

            GetComponent<VRTK_ControllerEvents>().ButtonTwoPressed += new ControllerInteractionEventHandler(DoButtonTwoPressed);
            GetComponent<VRTK_ControllerEvents>().ButtonTwoReleased += new ControllerInteractionEventHandler(DoButtonTwoReleased);

            GetComponent<VRTK_ControllerEvents>().ButtonTwoTouchStart += new ControllerInteractionEventHandler(DoButtonTwoTouchStart);
            GetComponent<VRTK_ControllerEvents>().ButtonTwoTouchEnd += new ControllerInteractionEventHandler(DoButtonTwoTouchEnd);

            GetComponent<VRTK_ControllerEvents>().StartMenuPressed += new ControllerInteractionEventHandler(DoStartMenuPressed);
            GetComponent<VRTK_ControllerEvents>().StartMenuReleased += new ControllerInteractionEventHandler(DoStartMenuReleased);

            GetComponent<VRTK_ControllerEvents>().ControllerEnabled += new ControllerInteractionEventHandler(DoControllerEnabled);
            GetComponent<VRTK_ControllerEvents>().ControllerDisabled += new ControllerInteractionEventHandler(DoControllerDisabled);

            GetComponent<VRTK_ControllerEvents>().ControllerIndexChanged += new ControllerInteractionEventHandler(DoControllerIndexChanged);
        }

        private void Update()
        {
            if (StateManager.Instance.rig != null)
            {

                if (StateManager.Instance.rigMode == 0)
                {
                    StateManager.Instance.rig.transform.position += StateManager.Instance.rigDirection;
                }
                if (StateManager.Instance.rigMode == 1)
                {

                    if (StateManager.Instance.orbitEnabledRight)
                    {
                        StateManager.Instance.rig.transform.RotateAround(StateManager.Instance.controlledObject.transform.position, Vector3.up, StateManager.Instance.speed * -1);
                    }

                    if (StateManager.Instance.orbitEnabledLeft)
                    {
                        StateManager.Instance.rig.transform.RotateAround(StateManager.Instance.controlledObject.transform.position, Vector3.up, StateManager.Instance.speed);
                    }
                }
            }

            GameObject go = GameObject.Find("sliderRigSpeed");
            if (go != null) { StateManager.Instance.speed = go.GetComponent<Slider>().value; }
        }

        private void DebugLogger(uint index, string button, string action, ControllerInteractionEventArgs e)
        {
            /*
            VRTK_Logger.Info("Controller on index '" + index + "' " + button + " has been " + action
                    + " with a pressure of " + e.buttonPressure + " / trackpad axis at: " + e.touchpadAxis + " (" + e.touchpadAngle + " degrees)");
            */
        }

        private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
        {

        }

        private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
        {
         //   DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "released", e);

        }

        private void DoTriggerTouchStart(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "touched", e);
        }

        private void DoTriggerTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "untouched", e);
        }

        private void DoTriggerHairlineStart(object sender, ControllerInteractionEventArgs e)
        {
         //   DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "hairline start", e);
        }

        private void DoTriggerHairlineEnd(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "hairline end", e);
        }

        private void DoTriggerClicked(object sender, ControllerInteractionEventArgs e)
        {
        //    DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "clicked", e);
        }

        private void DoTriggerUnclicked(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "unclicked", e);
        }

        private void DoTriggerAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TRIGGER", "axis changed", e);
        }

        private void DoGripPressed(object sender, ControllerInteractionEventArgs e)
        {
            //   DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "pressed", e);
            StateManager.Instance.rigDirection.y = StateManager.Instance.speed * -1;
        }

        private void DoGripReleased(object sender, ControllerInteractionEventArgs e)
        {
            //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "released", e);
            StateManager.Instance.rigDirection.y = 0f;
        }

        private void DoGripTouchStart(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "touched", e);
        }

        private void DoGripTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "untouched", e);

        }

        private void DoGripHairlineStart(object sender, ControllerInteractionEventArgs e)
        {
           // DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "hairline start", e);
        }

        private void DoGripHairlineEnd(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "hairline end", e);
        }

        private void DoGripClicked(object sender, ControllerInteractionEventArgs e)
        {
           // DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "clicked", e);
        }

        private void DoGripUnclicked(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "unclicked", e);
        }

        private void DoGripAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "GRIP", "axis changed", e);
        }

        private void DoTouchpadPressed(object sender, ControllerInteractionEventArgs e)
        {
            float dir = e.touchpadAxis.y;
            float dir2 = e.touchpadAxis.x;
            StateManager.Instance.rigDirection.y = StateManager.Instance.speed; // pressed so go up
            if (StateManager.Instance.rigMode == 0) // move
            {               
                if (dir > 0.5) dir = StateManager.Instance.speed;
                if (dir < -0.5) dir = StateManager.Instance.speed * -1;

                if (dir2 > 0.5) dir2 = StateManager.Instance.speed;
                if (dir2 < -0.5) dir2 = StateManager.Instance.speed * -1;

                if (System.Math.Abs(dir) == StateManager.Instance.speed) { StateManager.Instance.rigDirection = transform.forward * dir; }
                if (System.Math.Abs(dir2) == StateManager.Instance.speed) { StateManager.Instance.rigDirection = transform.right * dir2; }
            }

            if (StateManager.Instance.rigMode == 1) // orbit
            {
                if (dir2 > 0.5) StateManager.Instance.orbitEnabledRight = true;
                if (dir2 < -0.5) StateManager.Instance.orbitEnabledLeft = true;
            }
        }

        private void DoTouchpadReleased(object sender, ControllerInteractionEventArgs e)
        {
            // DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TOUCHPAD", "released", e);
            StateManager.Instance.rigDirection.x = 0f;
            StateManager.Instance.rigDirection.y = 0f;
            StateManager.Instance.rigDirection.z = 0f;
            StateManager.Instance.scaleDirection = 1f;
            StateManager.Instance.rotationEnabled = false;
            StateManager.Instance.orbitEnabledRight = false;
            StateManager.Instance.orbitEnabledLeft = false;
        }

        private void DoTouchpadTouchStart(object sender, ControllerInteractionEventArgs e)
        {
           // DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TOUCHPAD", "touched", e);
        }

        private void DoTouchpadTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
           // DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TOUCHPAD", "untouched", e);
 
        }

        private void DoTouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "TOUCHPAD", "axis changed", e);
        }

        private void DoButtonOnePressed(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON ONE", "pressed down", e);
        }

        private void DoButtonOneReleased(object sender, ControllerInteractionEventArgs e)
        {
           // DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON ONE", "released", e);
        }

        private void DoButtonOneTouchStart(object sender, ControllerInteractionEventArgs e)
        {
           // DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON ONE", "touched", e);
        }

        private void DoButtonOneTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON ONE", "untouched", e);
        }

        private void DoButtonTwoPressed(object sender, ControllerInteractionEventArgs e)
        {

            //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON TWO", "pressed down", e);
            StateManager.Instance.editMode = 0;
            StateManager.Instance.editMode = 0;
            StateManager.Instance.controlledObject = null;
            StateManager.Instance.instatiateObject = null;

            if (StateManager.Instance.previousControlledObject != null)
            {
                StateManager.Instance.previousControlledObject.GetComponent<Renderer>().material.shader = StateManager.Instance.originalShader;
            }

            StateManager.Instance.previousControlledObject = null;

            StateManager.Instance.menu.SetActive(!StateManager.Instance.menu.activeSelf);


            GameObject go = GameObject.Find("/Stage");
            Transform[] allChildren = go.GetComponentsInChildren<Transform>();
            StateManager.Instance.unityGameObjects = new List<GameObject>();
            foreach (Transform child in allChildren)
            {
                if (child.parent != null)
                {
                    if (child.parent.name == "Stage")
                    {
                        StateManager.Instance.unityGameObjects.Add(child.gameObject); // only add top level gameobjects
                    }
                }
            }

            StateManager.Instance.prefabsFromFolder = Resources.LoadAll<GameObject>("VREditorPrefabs");
            content.Populate();
            content2.Populate();
            StateManager.Instance.updateView = true;
        }

        private void DoButtonTwoReleased(object sender, ControllerInteractionEventArgs e)
        {
         //   DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON TWO", "released", e);
        }

        private void DoButtonTwoTouchStart(object sender, ControllerInteractionEventArgs e)
        {
         //   DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON TWO", "touched", e);
        }

        private void DoButtonTwoTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "BUTTON TWO", "untouched", e);
        }

        private void DoStartMenuPressed(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "START MENU", "pressed down", e);
        }

        private void DoStartMenuReleased(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "START MENU", "released", e);
        }

        private void DoControllerEnabled(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "CONTROLLER STATE", "ENABLED", e);
        }

        private void DoControllerDisabled(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "CONTROLLER STATE", "DISABLED", e);
        }

        private void DoControllerIndexChanged(object sender, ControllerInteractionEventArgs e)
        {
          //  DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "CONTROLLER STATE", "INDEX CHANGED", e);
        }
    }
}