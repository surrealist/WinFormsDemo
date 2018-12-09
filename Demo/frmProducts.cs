using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
  public partial class frmProducts : Form, IDoc
  {
    public frmProducts()
    {
      InitializeComponent();
    }

    public int Count => bindingSource1.Count;

    public int Current => bindingSource1.Position;

    public event EventHandler PositionChanged;

    public void AddNew()
    {
      //MessageBox.Show("Add!!");
      bindingSource1.AddNew();
    }

    public void Delete()
    {
      throw new NotImplementedException();
    }

    public void Edit()
    {
      throw new NotImplementedException();
    }

    private async void frmProducts_Load(object sender, EventArgs e)
    {
      var c = new Client("https://localhost:44391");
      dataGridView1.AutoGenerateColumns = true;
      bindingSource1.DataSource = await c.GetAllAsync();
    }

    private void bindingSource1_PositionChanged(object sender, EventArgs e)
    { 
      PositionChanged?.Invoke(this, EventArgs.Empty);
    }
  }
}
