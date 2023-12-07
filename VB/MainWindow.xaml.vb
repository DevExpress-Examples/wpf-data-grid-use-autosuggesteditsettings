Imports DevExpress.Mvvm
Imports DevExpress.Xpf.Editors
Imports DevExpress.Xpf.Grid
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Windows

Namespace DXSample

    Public Partial Class MainWindow
        Inherits Window

        Public Property Items As ObservableCollection(Of Item)

        Public Sub New()
            Items = New ObservableCollection(Of Item) From {New Item With {.Value = "A"}, New Item With {.Value = "B"}, New Item With {.Value = "C"}}
            DataContext = Me
            Me.InitializeComponent()
        End Sub

        Private ActiveEditor As AutoSuggestEdit

        Private Sub ShownEditor(ByVal sender As Object, ByVal e As EditorEventArgs)
            ActiveEditor = TryCast(e.Editor, AutoSuggestEdit)
            If ActiveEditor IsNot Nothing Then AddHandler ActiveEditor.QuerySubmitted, AddressOf QuerySubmitted
        End Sub

        Private Sub HiddenEditor(ByVal sender As Object, ByVal e As EditorEventArgs)
            If ActiveEditor IsNot Nothing Then
                RemoveHandler ActiveEditor.QuerySubmitted, AddressOf QuerySubmitted
                ActiveEditor.ItemsSource = Nothing
                ActiveEditor = Nothing
            End If
        End Sub

        Private Sub QuerySubmitted(ByVal sender As Object, ByVal e As AutoSuggestEditQuerySubmittedEventArgs)
            ActiveEditor.ItemsSource = New List(Of String)(Enumerable.Range(0, 10).[Select](Function(c) e.Text & " item #" & c))
        End Sub
    End Class

    Public Class Item
        Inherits BindableBase

        Private _Value As String

        Public Property Value As String
            Get
                Return _Value
            End Get

            Set(ByVal value As String)
                SetProperty(_Value, value, "Value")
            End Set
        End Property
    End Class
End Namespace
