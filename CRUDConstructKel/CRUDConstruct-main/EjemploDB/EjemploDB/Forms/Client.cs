using System;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Windows.Forms;

namespace EjemploDB
{
    public partial class Client : Form
    {
        INTEC_AGU_OCT22Entities db = new INTEC_AGU_OCT22Entities();
        ClientType clientType = new ClientType();
        int clientId = 0;
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            ClearData();
            SetDataInGridView();
        }

        private void SetDataInGridView()
        {
            var clients = (from a in db.ClientTypes
                           select new
                           {
                               a.Id,
                               FullName = a.Name,
                               a.Description,
                               a.CreatedDate,
                               a.Enabled
                           }).ToList();

            dataGridView1.DataSource = clients;
        }

        private void ClearData()
        {
            txtDate.Text = txtdesc.Text = txtname.Text = string.Empty;
            btndelete.Enabled = false;
            btnsave.Text = "Save";
            clientId = 0;
        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            clientType.Name = txtname.Text.Trim();
            clientType.Description = txtdesc.Text;
            clientType.CreatedDate = Convert.ToDateTime(txtDate.Text);
            if (clientId > 0)
            {
                db.Entry(clientType).State = EntityState.Modified;
            }
            else
            {
                db.ClientTypes.Add(clientType);
            }
            db.SaveChanges();
            ClearData();
            SetDataInGridView();
            MessageBox.Show("Registro Guardado");
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Borrar este Registro", "Borrar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.ClientTypes.Remove(clientType);
                db.SaveChanges();
                ClearData();
                SetDataInGridView();
                MessageBox.Show("Record borrado");
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex != -1)
            {
                clientId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
                clientType = db.ClientTypes.Where(x => x.Id == clientId).FirstOrDefault();
                txtname.Text = clientType.Name;
                txtdesc.Text = clientType.Description;
                txtDate.Text = clientType.CreatedDate.ToString();
            }
            btnsave.Text = "Update";
            btndelete.Enabled = true;
        }
    }
}
