using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApplication18 {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            grid.ItemsSource = Employees.GetEmployees();
            grid.Loaded += (d, e) => { (d as GridControl)?.ExpandMasterRow(0); };
        }

        public class Employee {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Title { get; set; }
            public string Notes { get; set; }
            public List<Order> Orders { get; set; }
        }
        public class Order {
            public string Supplier { get; set; }
            public DateTime Date { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
        }
        public class Employees {
            public static ObservableCollection<Employee> GetEmployees() {
                ObservableCollection<Employee> employees = new ObservableCollection<Employee>() {
                new Employee() {
                    FirstName="Bruce",
                    LastName="Cambell",
                    Title="Sales Manager",
                    Notes="Education includes a BA in psychology from Colorado State University in 1970.  He also completed 'The Art of the Cold Call.'  Bruce is a member of Toastmasters International.",
                    Orders = new List<Order>()
                },
                new Employee() {
                    FirstName="Cindy",
                    LastName="Haneline",
                    Title="Vice President of Sales",
                    Notes="Cindy received her BTS commercial in 1974 and a Ph.D. in international marketing from the University of Dallas in 1981.  She is fluent in French and Italian and reads German.  She joined the company as a sales representative, was promoted to sales manager in January 1992 and to vice president of sales in March 1993.  Cindy is a member of the Sales Management Roundtable, the Seattle Chamber of Commerce, and the Pacific Rim Importers Association.",
                    Orders = new List<Order>()
                },
            };
                employees[0].Orders.Add(new Order() { Supplier = "Supplier 1", Date = DateTime.Now, ProductName = "TV", Quantity = 20 });
                employees[0].Orders.Add(new Order() { Supplier = "Supplier 2", Date = DateTime.Now.AddDays(3), ProductName = "Projector", Quantity = 15 });
                employees[0].Orders.Add(new Order() { Supplier = "Supplier 3", Date = DateTime.Now.AddDays(3), ProductName = "HDMI Cable", Quantity = 50 });
                employees[1].Orders.Add(new Order() { Supplier = "Supplier 1", Date = DateTime.Now.AddDays(1), ProductName = "Blu-Ray Player", Quantity = 10 });
                employees[1].Orders.Add(new Order() { Supplier = "Supplier 2", Date = DateTime.Now.AddDays(1), ProductName = "HDMI Cable", Quantity = 10 });
                employees[1].Orders.Add(new Order() { Supplier = "Supplier 3", Date = DateTime.Now.AddDays(1), ProductName = "Projector", Quantity = 10 });
                employees[1].Orders.Add(new Order() { Supplier = "Supplier 4", Date = DateTime.Now.AddDays(1), ProductName = "Amplifier", Quantity = 10 });
                return employees;
            }
        }
    }
}
