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

using Tizen.TV.UIControls.Forms;
using Tizen.TV.UIControls.Forms.Renderer;
using Xamarin.Forms.Platform.Tizen;
using MMView = Tizen.Multimedia.MediaView;

[assembly: ExportRenderer(typeof(MediaView), typeof(MediaViewRenderer))]
namespace Tizen.TV.UIControls.Forms.Renderer
{
    public class MediaViewRenderer : ViewRenderer<MediaView, LayoutCanvas>, IMediaViewProvider
    {
        MMView _mediaView;
        protected override void OnElementChanged(ElementChangedEventArgs<MediaView> e)
        {
            if (Control == null)
            {
                _mediaView = new MMView(Xamarin.Forms.Platform.Tizen.Forms.NativeParent);
                SetNativeControl(new LayoutCanvas(Xamarin.Forms.Platform.Tizen.Forms.NativeParent));
                Control.LayoutUpdated += (s, evt) => OnLayout();
                Control.Children.Add(_mediaView);
                Control.AllowFocus(true);
            }
            base.OnElementChanged(e);
        }

        MMView IMediaViewProvider.GetMediaView()
        {
            return _mediaView;
        }

        void OnLayout()
        {
            _mediaView.Geometry = Control.Geometry;
        }
    }
}
