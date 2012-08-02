using System.ComponentModel;
using System;
namespace Test1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            // Create and populate the list of DemoCustomer objects
            // which will supply data to the DataGridView.
            BindingList<DemoCustomer> customerList = new BindingList<DemoCustomer>();
            customerList.Add(DemoCustomer.CreateNewCustomer());
            customerList.Add(DemoCustomer.CreateNewCustomer());
            customerList.Add(DemoCustomer.CreateNewCustomer());

            // Bind the list to the BindingSource.
            this.customersBindingSource.DataSource = customerList;

            // Attach the BindingSource to the DataGridView.
            this.customersDataGridView.DataSource =
                this.customersBindingSource;
        }
       

       
        // Change the value of the CompanyName property for the first 
        // item in the list when the "Change Item" button is clicked.
        void changeItemBtn_Click(object sender, EventArgs e)
        {
            // Get a reference to the list from the BindingSource.
            BindingList<DemoCustomer> customerList =
                this.customersBindingSource.DataSource as BindingList<DemoCustomer>;

            // Change the value of the CompanyName property for the 
            // first item in the list.
            customerList[0].CustomerName = "Tailspin Toys";
        }



        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Form1";
        }

        #endregion
    }

    // This is a simple customer class that 
// implements the IPropertyChange interface.
public class DemoCustomer  : INotifyPropertyChanged
{
    // These fields hold the values for the public properties.
    private Guid idValue = Guid.NewGuid();
    private string customerNameValue = String.Empty;
    private string phoneNumberValue = String.Empty;

    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged(String info)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }

    // The constructor is private to enforce the factory pattern.
    private DemoCustomer()
    {
        customerNameValue = "Customer";
        phoneNumberValue = "(555)555-5555";
    }

    // This is the public factory method.
    public static DemoCustomer CreateNewCustomer()
    {
        return new DemoCustomer();
    }

    // This property represents an ID, suitable
    // for use as a primary key in a database.
    public Guid ID
    {
        get
        {
            return this.idValue;
        }
    }

    public string CustomerName
    {
        get
        {
            return this.customerNameValue;
        }

        set
        {
            if (value != this.customerNameValue)
            {
                this.customerNameValue = value;
                NotifyPropertyChanged("CustomerName");
            }
        }
    }

    public string PhoneNumber
    {
        get
        {
            return this.phoneNumberValue;
        }

        set
        {
            if (value != this.phoneNumberValue)
            {
                this.phoneNumberValue = value;
                NotifyPropertyChanged("PhoneNumber");
            }
        }
    }
}
}

