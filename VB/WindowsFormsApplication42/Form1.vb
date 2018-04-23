Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace WindowsFormsApplication42
	Partial Public Class Form1
		Inherits Form
		Private ShortCaptions As Dictionary(Of String, String)

		Public Sub New()
			InitializeComponent()
			ShortCaptions = New Dictionary(Of String, String)()
			ShortCaptions.Add("CustomerID", "ID")
			ShortCaptions.Add("ContactName", "Name")
			ShortCaptions.Add("ContactTitle", "Title")
			ShortCaptions.Add("CompanyName", "Company")
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' TODO: This line of code loads data into the 'nwindDataSet.Customers' table. You can move, or remove it, as needed.
			Me.customersTableAdapter.Fill(Me.nwindDataSet.Customers)
		End Sub

		Private Sub gridView1_CustomDrawColumnHeader(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles gridView1.CustomDrawColumnHeader
			If e.Column Is Nothing Then
				Return
			End If
			Dim s As SizeF = e.Appearance.CalcTextSize(e.Cache, e.Info.Caption, e.Info.CaptionRect.Width)
			If s.Width >= e.Info.CaptionRect.Width Then
				If ShortCaptions.ContainsKey(e.Column.FieldName) Then
					e.Info.Caption = ShortCaptions(e.Column.FieldName)
				End If
			End If
		End Sub
	End Class
End Namespace
