using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoExamFinal
{
    public partial class Form2 : Form
    {
        List<Partner> partners = new List<Partner>();
        int selectedPartnerID = -1;
        MySqlConnection conn;
        MySqlCommand cmd;
        public Form2(List<Partner> _partners)
        {
            partners = _partners;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //изменить
            conn = new MySqlConnection("Server=localhost;User ID=pk41;Password=123456;Database=partners");
            cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = "UPDATE partners SET name=@newName , country = @newCountry WHERE id=@id";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("newName", textBox1.Text.Trim());
            cmd.Parameters.AddWithValue("newCountry", textBox2.Text.Trim());
            cmd.Parameters.AddWithValue("id", selectedPartnerID);
            if (cmd.ExecuteNonQuery()==1)
            {
                MessageBox.Show("Изменения внесены");
            } else
            {
                MessageBox.Show("Всё плохо");
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //добавить
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (var item in partners)
            {
                listBox1.Items.Add($"{item.name} {item.country} {item.discount}");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPartnerID = partners[listBox1.SelectedIndex].id;
            textBox1.Text = partners[listBox1.SelectedIndex].name;
            textBox2.Text = partners[listBox1.SelectedIndex].country;
            textBox3.Text = partners[listBox1.SelectedIndex].discount.ToString();
        }
    }
}
