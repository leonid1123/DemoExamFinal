using MySqlConnector;
namespace DemoExamFinal
{
    public partial class Form1 : Form
    {
        public MySqlConnection conn;
        public MySqlCommand cmd;
        List<Partner> partners = new List<Partner>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection("Server=localhost;User ID=pk41;Password=123456;Database=partners");
            cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM partners LIMIT 10";
            conn.Open();
            var reader = cmd.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {
                var tmp = new Partner(reader.GetInt32(0),reader.GetString(2), reader.GetString(4));
                partners.Add(tmp);
                listBox1.Items.Add(
                    $"{reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)} {reader.GetString(4)} {reader.GetString(5)} {reader.GetInt32(6)} {reader.GetString(7)} {reader.GetInt32(8)} ");
            }
            conn.Close();
            cmd.CommandText = "SELECT id_partner,SUM(quantity) FROM sales GROUP BY id_partner";
            conn.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                foreach (var item in partners)
                {
                    if (reader.GetInt32(0) == item.id)
                    {
                        item.SetDiscount(reader.GetInt32(1));
                    }
                    
                }
            }
            conn.Close();
            listBox1.Items.Clear();
            foreach (var item in partners)
            {
                listBox1.Items.Add($"Название:{item.name} Скидка:{item.discount}");
            }
        }
    }
}
