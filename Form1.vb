Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Namespace ListViewTriee

    Public Class Form1
        Inherits System.Windows.Forms.Form
        Private listView1 As System.Windows.Forms.ListView
        Private columnHeader1 As System.Windows.Forms.ColumnHeader
        Private columnHeader2 As System.Windows.Forms.ColumnHeader
        Private columnHeader3 As System.Windows.Forms.ColumnHeader
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Dim listViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Test", "Toto", "Salut"}, -1)
            Dim listViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Developpez", ".com", "Morpheus"}, -1)
            Dim listViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"Vive", "le", "C#"}, -1)
            Me.listView1 = New System.Windows.Forms.ListView
            Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
            Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
            Me.columnHeader3 = New System.Windows.Forms.ColumnHeader
            Me.SuspendLayout()
            Me.listView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3})
            Me.listView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {listViewItem1, listViewItem2, listViewItem3})
            Me.listView1.Location = New System.Drawing.Point(16, 16)
            Me.listView1.Name = "listView1"
            Me.listView1.Size = New System.Drawing.Size(256, 224)
            Me.listView1.TabIndex = 0
            Me.listView1.View = System.Windows.Forms.View.Details
            AddHandler Me.listView1.ColumnClick, AddressOf Me.Trier_Colonne
            Me.columnHeader1.Text = "Colonne 1"
            Me.columnHeader1.Width = 79
            Me.columnHeader2.Text = "Colonne 2"
            Me.columnHeader2.Width = 72
            Me.columnHeader3.Text = "Colonne 3"
            Me.columnHeader3.Width = 100
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(292, 266)
            Me.Controls.Add(Me.listView1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            Me.ResumeLayout(False)
        End Sub

        <STAThread()> _
        Shared Sub Main()
            Application.Run(New Form1)
        End Sub

        Private Sub Trier_Colonne(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs)
            Dim ColumnSorter As ListViewItemComparer = New ListViewItemComparer(e.Column)
            If (ColumnSorter.bOrder = (Me.listView1.Sorting = SortOrder.Ascending)) Then
                Me.listView1.Sorting = SortOrder.Descending
            Else
                Me.listView1.Sorting = SortOrder.Ascending
            End If
            Me.listView1.ListViewItemSorter = ColumnSorter
            Me.listView1.Sort()
        End Sub
    End Class

    Class ListViewItemComparer
        Implements IComparer
        Private col As Integer
        Public bOrder As Boolean = True

        Public Sub New()
            col = 0
        End Sub

        Public Sub New(ByVal column As Integer)
            col = column
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            If bOrder Then
                Return String.Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
            Else
                Return -String.Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
            End If
        End Function
    End Class
End Namespace
