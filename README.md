# Tizen TV UIControls
The Tizen TV UIControls is a set of helpful extensions to the Xamarin Forms framework for the Samsung TV device. The binaries are available via NuGet (package name is Tizen.TV.UIControls.Forms) with the source available here.

## Build Status
 [![Build Status](http://13.124.0.26:8080/job/Tizen.TV.UIControls/job/Release/badge/icon)](http://13.124.0.26:8080/job/Tizen.TV.UIControls/job/Release/)
## Getting Started
## Guides
 https://myroot.github.io/Tizen.TV.UIControls/guides/Overview.html
## API document
 https://myroot.github.io/Tizen.TV.UIControls/api/index.html


``` xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:uicontrols="clr-namespace:Tizen.TV.UIControls.Forms;assembly=Tizen.TV.UIControls.Forms"
             x:Class="Sample.TestRemoteControl_xaml"
             x:Name="rootPage">
    <ContentPage.Content>
        <StackLayout>
            <Button Text="Button (accesskey 1)" uicontrols:InputEvents.AccessKey="NUM1" Clicked="OnClicked" />
            <Label x:Name="Label1"/>
            <Label x:Name="Label2"/>
        </StackLayout>
    </ContentPage.Content>
    <uicontrols:InputEvents.EventHandlers>
        <uicontrols:RemoteKeyHandler Command="{Binding PageHandler, Source={x:Reference rootPage}}" />
    </uicontrols:InputEvents.EventHandlers>
</ContentPage>
```
