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
  public partial class frmMain : Form
  {


    public frmMain()
    {
      InitializeComponent();
    }

    private void frmMain_Load(object sender, EventArgs e)
    {

    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    private frmMaterials fMaterials = null;

    private void materialToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (fMaterials == null || fMaterials.IsDisposed)
      {
        fMaterials = new frmMaterials();
        fMaterials.MdiParent = this;

        IDoc d = fMaterials as IDoc;
        d.PositionChanged += D_PositionChanged;
      }

      fMaterials.Show();
    }

    private frmProducts fProduct = null;
    private void productToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (fProduct == null || fProduct.IsDisposed)
      {
        fProduct = new frmProducts();
        fProduct.MdiParent = this;

        IDoc d = fProduct as IDoc;
        d.PositionChanged += D_PositionChanged;
      }

      fProduct.Show();
    }

    private void D_PositionChanged(object sender, EventArgs e)
    {
      IDoc doc = sender as IDoc;

      if (doc != null)
        lblCount.Text = $"Count: {doc.Current+1} of {doc.Count}";
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      if (ActiveMdiChild == null) return;

      if (ActiveMdiChild is IDoc doc)
      {
        doc.AddNew();
      }
    }

    private void frmMain_MdiChildActivate(object sender, EventArgs e)
    {
      IDoc doc = ActiveMdiChild as IDoc;

      if (doc != null)
        lblCount.Text = $"Count: {doc.Current + 1} of {doc.Count}";
      else
        lblCount.Text = "";
    }
  }
}
