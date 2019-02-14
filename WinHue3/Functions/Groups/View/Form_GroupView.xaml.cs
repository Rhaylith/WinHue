﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using WinHue3.ExtensionMethods;
using WinHue3.Philips_Hue.BridgeObject;
using WinHue3.Philips_Hue.HueObjects.GroupObject;
using WinHue3.Philips_Hue.HueObjects.LightObject;
using WinHue3.Utils;

namespace WinHue3.Functions.Groups.View
{
    /// <summary>
    /// Interaction logic for Form_BulbsView.xaml
    /// </summary>
    public partial class Form_GroupView : Window
    {
        private GroupViewViewModel _gvv;
        public Form_GroupView()
        {
            InitializeComponent();
        }

        public async Task Initialize()
        {
            List<Light> comlgt = await BridgeManager.SelectedBridge.GetListObjectsAsync<Light>().ToList<Light>();

            _gvv = DataContext as GroupViewViewModel;

            if (comlgt != null)
            {
                Dictionary<string,Group> comgrp = await BridgeManager.SelectedBridge.GetListObjectsAsync<Group>();
                if (comgrp != null)
                {

                    _gvv.Initialize(comgrp.ToList(), comlgt);
                }
                else
                {
                    MessageBoxError.ShowLastErrorMessages(BridgeManager.SelectedBridge);
                }

                DataContext = _gvv;

            }
            else
            {
                MessageBoxError.ShowLastErrorMessages(BridgeManager.SelectedBridge);
            }
        }

    }
}
