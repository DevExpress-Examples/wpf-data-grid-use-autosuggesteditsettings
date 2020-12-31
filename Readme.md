# How to use AutoSuggestEditSettings in Data Grid

This example demonstrates how to handle [AutoSuggestEdit](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.AutoSuggestEdit) events when [ColumnBase.EditSettings](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ColumnBase.EditSettings) is set to [AutoSuggestEditSettings](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.Settings.AutoSuggestEditSettings). 

`AutoSuggestEditSettings` is not a visual element and it does not offer events such as [AutoSuggestEdit.QuerySubmitted](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.AutoSuggestEdit.QuerySubmitted). You can handle [GridViewBase.ShownEditor](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridViewBase.ShownEditor) to subscribe to these events for an active editor and then unsubscribe from these events in the [GridViewBase.HiddenEditor](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridViewBase.HiddenEditor) event handler.

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