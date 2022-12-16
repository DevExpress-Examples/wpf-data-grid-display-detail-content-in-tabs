Imports DevExpress.Xpf.Grid
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows

Namespace WpfApplication18

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Me.grid.ItemsSource = Employees.GetEmployees()
            AddHandler Me.grid.Loaded, Sub(d, e) TryCast(d, GridControl)?.ExpandMasterRow(0)
        End Sub

        Public Class Employee

            Public Property FirstName As String

            Public Property LastName As String

            Public Property Title As String

            Public Property Notes As String

            Public Property Orders As List(Of Order)
        End Class

        Public Class Order

            Public Property Supplier As String

            Public Property [Date] As Date

            Public Property ProductName As String

            Public Property Quantity As Integer
        End Class

        Public Class Employees

            Public Shared Function GetEmployees() As ObservableCollection(Of Employee)
                Dim employees As ObservableCollection(Of Employee) = New ObservableCollection(Of Employee)() From {New Employee() With {.FirstName = "Bruce", .LastName = "Cambell", .Title = "Sales Manager", .Notes = "Education includes a BA in psychology from Colorado State University in 1970.  He also completed 'The Art of the Cold Call.'  Bruce is a member of Toastmasters International.", .Orders = New List(Of Order)()}, New Employee() With {.FirstName = "Cindy", .LastName = "Haneline", .Title = "Vice President of Sales", .Notes = "Cindy received her BTS commercial in 1974 and a Ph.D. in international marketing from the University of Dallas in 1981.  She is fluent in French and Italian and reads German.  She joined the company as a sales representative, was promoted to sales manager in January 1992 and to vice president of sales in March 1993.  Cindy is a member of the Sales Management Roundtable, the Seattle Chamber of Commerce, and the Pacific Rim Importers Association.", .Orders = New List(Of Order)()}}
                employees(0).Orders.Add(New Order() With {.Supplier = "Supplier 1", .[Date] = Date.Now, .ProductName = "TV", .Quantity = 20})
                employees(0).Orders.Add(New Order() With {.Supplier = "Supplier 2", .[Date] = Date.Now.AddDays(3), .ProductName = "Projector", .Quantity = 15})
                employees(0).Orders.Add(New Order() With {.Supplier = "Supplier 3", .[Date] = Date.Now.AddDays(3), .ProductName = "HDMI Cable", .Quantity = 50})
                employees(1).Orders.Add(New Order() With {.Supplier = "Supplier 1", .[Date] = Date.Now.AddDays(1), .ProductName = "Blu-Ray Player", .Quantity = 10})
                employees(1).Orders.Add(New Order() With {.Supplier = "Supplier 2", .[Date] = Date.Now.AddDays(1), .ProductName = "HDMI Cable", .Quantity = 10})
                employees(1).Orders.Add(New Order() With {.Supplier = "Supplier 3", .[Date] = Date.Now.AddDays(1), .ProductName = "Projector", .Quantity = 10})
                employees(1).Orders.Add(New Order() With {.Supplier = "Supplier 4", .[Date] = Date.Now.AddDays(1), .ProductName = "Amplifier", .Quantity = 10})
                Return employees
            End Function
        End Class
    End Class
End Namespace
