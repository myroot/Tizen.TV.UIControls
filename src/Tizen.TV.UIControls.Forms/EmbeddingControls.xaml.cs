﻿/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

 using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tizen.TV.UIControls.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmbeddingControls : ContentView
    {
        public EmbeddingControls()
        {
            InitializeComponent();
            PlayImage.Source = ImageSource.FromResource("Tizen.TV.UIControls.Forms.Resources.img_button_play.png", GetType().Assembly);
            PauseImage.Source = ImageSource.FromResource("Tizen.TV.UIControls.Forms.Resources.img_button_pause.png", GetType().Assembly);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext is MediaPlayer player)
            {
                player.PlaybackPaused += OnPlaybackStateChanged;
                player.PlaybackStarted += OnPlaybackStateChanged;
                player.PlaybackStopped += OnPlaybackStateChanged;
            }
        }

        async void OnPlaybackStateChanged(object sender, EventArgs e)
        {
            if (BindingContext is MediaPlayer player)
            {
                if (player.State == PlaybackState.Playing)
                {
                    var unused = PlayImage.FadeTo(0, 100);
                    await PlayImage.ScaleTo(3.0, 300);
                    PlayImage.IsVisible = false;
                    PlayImage.Scale = 1.0;

                    PauseImage.IsVisible = true;
                    unused = PauseImage.FadeTo(1, 50);
                }
                else
                {
                    var unused = PauseImage.FadeTo(0, 100);
                    await PauseImage.ScaleTo(3.0, 300);
                    PauseImage.IsVisible = false;
                    PauseImage.Scale = 1.0;

                    PlayImage.IsVisible = true;
                    unused = PlayImage.FadeTo(1, 50);
                }
            }
        }
    }
}