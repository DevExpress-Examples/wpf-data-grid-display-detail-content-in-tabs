Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid

Namespace WpfApplication18
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			gridControl1.ItemsSource = Employees
		End Sub

		#Region "#GridInCode"
		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim newGrid As GridControl = CreateGrid()
			AddDetailsToGrid(newGrid)
			Grid.SetRow(newGrid, 2)
			mainGrid.Children.Add(newGrid)
		End Sub
		Private Function CreateGrid() As GridControl
			Dim newGrid As New GridControl()
			newGrid.AutoPopulateColumns = True
			newGrid.View = New TableView()
			TryCast(newGrid.View, TableView).AutoWidth = True
			TryCast(newGrid.View, TableView).ShowGroupPanel = False
			newGrid.View.DetailHeaderContent = "Employees"
			newGrid.ItemsSource = Employees
			Return newGrid
		End Function

		Private Sub AddDetailsToGrid(ByVal grid As GridControl)
			Dim dataControlDetail As New DataControlDetailDescriptor()
			dataControlDetail.ItemsSourcePath = "Orders"

			Dim detailGrid As New GridControl()
			dataControlDetail.DataControl = detailGrid
			detailGrid.AutoPopulateColumns = True
			detailGrid.View.DetailHeaderContent = "Orders"
			TryCast(detailGrid.View, TableView).ShowGroupPanel = False

			Dim contentDetail As New ContentDetailDescriptor()
			contentDetail.ContentTemplate = CType(FindResource("EmployeeNotes"), DataTemplate)
			contentDetail.HeaderContent = "Notes"

			Dim tabDetail As New TabViewDetailDescriptor()
			tabDetail.DetailDescriptors.Add(dataControlDetail)
			tabDetail.DetailDescriptors.Add(contentDetail)

			grid.DetailDescriptor = tabDetail
		End Sub
		#End Region ' #GridInCode

		Private employees_Renamed As List(Of Employee)
		Private ReadOnly Property Employees() As List(Of Employee)
			Get
				If employees_Renamed Is Nothing Then
					PopulateEmployees()
				End If
				Return employees_Renamed

			End Get
		End Property
		Private Sub PopulateEmployees()
			employees_Renamed = New List(Of Employee)()
			employees_Renamed.Add(New Employee("Bruce", "Cambell", "Sales Manager", "Education includes a BA in psychology from Colorado State University in 1970.  He also completed 'The Art of the Cold Call.'  Bruce is a member of Toastmasters International."))
			employees_Renamed(0).Orders.Add(New Order("Suppliers Inc.", DateTime.Now, "TV", 20))
			employees_Renamed(0).Orders.Add(New Order("Suppliers Inc.", DateTime.Now.AddDays(3), "Projector", 15))
			employees_Renamed.Add(New Employee("Cindy", "Haneline", "Vice President of Sales", "Cindy received her BTS commercial in 1974 and a Ph.D. in international marketing from the University of Dallas in 1981.  She is fluent in French and Italian and reads German.  She joined the company as a sales representative, was promoted to sales manager in January 1992 and to vice president of sales in March 1993.  Cindy is a member of the Sales Management Roundtable, the Seattle Chamber of Commerce, and the Pacific Rim Importers Association."))
			employees_Renamed(1).Orders.Add(New Order("Suppliers Inc.", DateTime.Now.AddDays(1), "Blu-Ray Player", 10))
		End Sub

	End Class

	Public Class Employee
		Private firstName_Renamed As String
		Private lastName_Renamed As String
		Private title_Renamed As String
		Private notes_Renamed As String
		Private orders_Renamed As List(Of Order)
		Public Sub New(ByVal firstName As String, ByVal lastName As String, ByVal title As String, ByVal notes As String)
			Me.firstName_Renamed = firstName
			Me.lastName_Renamed = lastName
			Me.title_Renamed = title
			Me.notes_Renamed = notes
			Me.orders_Renamed = New List(Of Order)()
		End Sub
		Public Sub New()
		End Sub
		Public Property FirstName() As String
			Get
				Return firstName_Renamed
			End Get
			Set(ByVal value As String)
				firstName_Renamed = value
			End Set
		End Property
		Public Property LastName() As String
			Get
				Return lastName_Renamed
			End Get
			Set(ByVal value As String)
				lastName_Renamed = value
			End Set
		End Property
		Public Property Title() As String
			Get
				Return title_Renamed
			End Get
			Set(ByVal value As String)
				title_Renamed = value
			End Set
		End Property
		Public Property Notes() As String
			Get
				Return notes_Renamed
			End Get
			Set(ByVal value As String)
				notes_Renamed = value
			End Set
		End Property
		Public ReadOnly Property Orders() As List(Of Order)
			Get
				Return orders_Renamed
			End Get
		End Property
	End Class

	Public Class Order
		Private supplier_Renamed As String
		Private date_Renamed As DateTime
		Private productName_Renamed As String
		Private quantity_Renamed As Integer
		Public Sub New(ByVal supplier As String, ByVal [date] As DateTime, ByVal productName As String, ByVal quantity As Integer)
			Me.supplier_Renamed = supplier
			Me.date_Renamed = [date]
			Me.productName_Renamed = productName
			Me.quantity_Renamed = quantity
		End Sub
		Public Property Supplier() As String
			Get
				Return supplier_Renamed
			End Get
			Set(ByVal value As String)
				supplier_Renamed = value
			End Set
		End Property
		Public Property [Date]() As DateTime
			Get
				Return date_Renamed
			End Get
			Set(ByVal value As DateTime)
				date_Renamed = value
			End Set
		End Property
		Public Property ProductName() As String
			Get
				Return productName_Renamed
			End Get
			Set(ByVal value As String)
				productName_Renamed = value
			End Set
		End Property
		Public Property Quantity() As Integer
			Get
				Return quantity_Renamed
			End Get
			Set(ByVal value As Integer)
				quantity_Renamed = value
			End Set
		End Property
	End Class
End Namespace
