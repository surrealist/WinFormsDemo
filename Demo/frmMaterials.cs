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
  public partial class frmMaterials : Form, IDoc
  {
    public frmMaterials()
    {
      InitializeComponent();
    }


    public int Count => bsMaterials.Count;

    public int Current => bsMaterials.Position;

    public event EventHandler PositionChanged;

    public void AddNew()
    {
      //MessageBox.Show("Add MATERIAL!!");
      bsMaterials.AddNew();
    }

    public void Delete()
    {
      throw new NotImplementedException();
    }

    public void Edit()
    {
      throw new NotImplementedException();
    }

    private async void frmMaterials_Load(object sender, EventArgs e)
    {

      var c = new Client("https://localhost:44391");
      dataGridView1.AutoGenerateColumns = true;
      bsMaterials.DataSource = await c.GetAllAllAsync();
    }

    private void bsMaterials_PositionChanged(object sender, EventArgs e)
    {
      PositionChanged?.Invoke(this, EventArgs.Empty);

    }

    private void frmMaterials_MdiChildActivate(object sender, EventArgs e)
    {
    
    }
  }
}
