using DAL;
using DTO;
using BusinessLogic;
using System.Windows.Forms;
using System.Linq;
using System;
using DAL.Repository;

namespace WinFormAction
{
    public partial class MainForm : Form
    {
        public IRepository<ActionDTO> actionRep = new ActionRep();
        public ActionLogic actionLogic = new ActionLogic();
        public IRepository<TypeDTO> typeRep = new TypeRep();

        public MainForm()
        {
            InitializeComponent();
            FormClosing += MainForm_FormClosing;
            tabPage1.Text = "Actions";
            label1.Visible = false;
            NewValueTextBox.Visible = false;
            confirmbtn.Visible = false;
            pictureBox2.Visible = false;
            dataGridView1.DataSource = actionRep.GetEnteties();
            dataGridView1.ReadOnly = true;
            listBox1.DataSource = actionLogic.TypeNames();

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void pastbutton_Click(object sender, System.EventArgs e)
        {
            actionRep.RefreshList();
            dataGridView1.DataSource = actionLogic.GetPastAction();
            dataGridView1.Refresh();
            
        }

        private void button1_Click(object sender, System.EventArgs e)//all actions
        {
            actionRep.RefreshList();
            dataGridView1.DataSource = actionRep.GetEnteties();
            dataGridView1.Refresh();
        }

        private void activebutton_Click(object sender, System.EventArgs e)
        {
            actionRep.RefreshList();
            dataGridView1.DataSource = actionLogic.GetActiveAction();
            dataGridView1.Refresh();
        }

        private void Futurebutton_Click(object sender, System.EventArgs e)
        {
            actionRep.RefreshList();
            dataGridView1.DataSource = actionLogic.GetFutureAction();
            dataGridView1.Refresh();

        }

        private void EditBtn_Click(object sender, System.EventArgs e)
        {
            if( actionLogic.GetFutureAction().Any(a=>a.Id == Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("Now edit some value, then press confirm ", "Error", MessageBoxButtons.OK);
                label1.Visible = true;
                NewValueTextBox.Visible = true;
                confirmbtn.Visible = true;
                pictureBox2.Visible = true;


            }
            else
            {
                MessageBox.Show("You can't edit active or past action", "Message box", MessageBoxButtons.OK);
            }
        }

        private void confirmbtn_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {

                string newname = NewValueTextBox.Text;
                if (actionRep.GetEnteties().Any(a => a.Name == newname))
                {
                    MessageBox.Show("Please type another name", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    actionLogic.UpdateActionName(newname, id);
                    // dataGridView1.ReadOnly = true;
                }
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 4)
            {

                DateTime newdate = Convert.ToDateTime(NewValueTextBox.Text);
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                actionLogic.UpdateActionStartTime(newdate, id);
                // dataGridView1.ReadOnly=true;
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 5)
            {

                DateTime newdate = Convert.ToDateTime(NewValueTextBox.Text);
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                actionLogic.UpdateActionEndTime(newdate, id);
                // dataGridView1.ReadOnly = true;
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {

                float newdate = float.Parse(NewValueTextBox.Text);
                if (newdate <= 0)
                {
                    MessageBox.Show("Discount <=0", "Error", MessageBoxButtons.OK);
                }
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                actionLogic.UpdateActionDiscount(newdate, id);
                //  dataGridView1.ReadOnly = true;
            }
            actionRep.RefreshList();
            dataGridView1.Refresh();
            label1.Visible = false;
            NewValueTextBox.Visible = false;
            confirmbtn.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)//confirm add action
        {
            string name= Namebox.Text;
            float discount= float.Parse(discountbox.Text);
            DateTime StartTime= StartTimePicker1.Value.ToUniversalTime();
            DateTime EndTime= EndTimePicker2.Value.ToUniversalTime();
            string typeName=listBox1.SelectedItem.ToString();
            int type_id = 1;
            foreach (TypeDTO t in typeRep.GetEnteties())
            {
                if (t.Name == typeName)
                {
                     type_id = t.Id;
                }
            }
            ActionDTO actionDTO = new ActionDTO(name, discount, type_id, StartTime, EndTime, DateTime.UtcNow, DateTime.UtcNow);
            actionRep.AddObj(actionDTO);
            actionRep.RefreshList();
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GoodsForm goodsForm = new GoodsForm();
            goodsForm.textBox1.Text =Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
            goodsForm.Show();
        }
    }
}
