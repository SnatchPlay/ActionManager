using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;
using BusinessLogic;
namespace WinFormAction
{
    public partial class GoodsForm : Form
    {
        IRepository<Goods> supplyRep= new GoodsRep();
        ActionLogic actionLogic= new ActionLogic();
        public GoodsForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = actionLogic.avalaibleSupply();
        }

        private void AddGoodBtn_Click(object sender, EventArgs e)
        {
           int supId= Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
           foreach(Goods sup in supplyRep.GetEnteties())
            {
                if(sup.Id == supId)
                {
                    sup.ActionId = Convert.ToInt32(textBox1.Text);
                }
            }
        }
    }
}
