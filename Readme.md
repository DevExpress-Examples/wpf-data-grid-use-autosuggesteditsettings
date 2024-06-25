<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/325781482/19.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T961510)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Data Grid - Use AutoSuggestEditSettings

This example demonstrates how to handle [AutoSuggestEdit](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.AutoSuggestEdit) events when the [ColumnBase.EditSettings](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.EditSettings) property is set to [AutoSuggestEditSettings](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.Settings.AutoSuggestEditSettings). 

![image](https://github.com/DevExpress-Examples/how-to-use-autosuggesteditsettings-in-data-grid/assets/65009440/26774fdc-2470-4a0f-aac7-f860dea8fd59)

## Implementation Details

`AutoSuggestEditSettings` is not a visual element and it does not include events (for example, [AutoSuggestEdit.QuerySubmitted](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.AutoSuggestEdit.QuerySubmitted)). You can handle [GridViewBase.ShownEditor](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridViewBase.ShownEditor) to subscribe to these events for an active editor and then unsubscribe from these events in the [GridViewBase.HiddenEditor](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridViewBase.HiddenEditor) event handler.

```cs
AutoSuggestEdit ActiveEditor;
void ShownEditor(object sender, EditorEventArgs e) {
    ActiveEditor = e.Editor as AutoSuggestEdit;
    if (ActiveEditor != null)
        ActiveEditor.QuerySubmitted += QuerySubmitted;
}
void HiddenEditor(object sender, EditorEventArgs e) {
    if (ActiveEditor != null) {
        ActiveEditor.QuerySubmitted -= QuerySubmitted;
        ActiveEditor = null;
    }
}
```

## Files to Review

* [MainWindow.xaml](./CS/MainWindow.xaml)
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))

## Documentation

* [AutoSuggestEdit](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.AutoSuggestEdit)
* [AutoSuggestEditSettings](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.Settings.AutoSuggestEditSettings)
* [Assign Editors to Cells](https://docs.devexpress.com/WPF/401011/controls-and-libraries/data-grid/data-editing-and-validation/modify-cell-values/assign-an-editor-to-a-cell)

## More Examples

* [Populate WPF AutoSuggestEdit Asynchronously](https://github.com/DevExpress-Examples/How-to-populate-AutoSuggestEdit-asynchronously)
* [Use WPF AutoSuggestEdit with InfiniteAsyncSource](https://github.com/DevExpress-Examples/How-to-use-AutoSuggestEdit-with-InfiniteAsyncSource)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-use-autosuggesteditsettings&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-use-autosuggesteditsettings&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
