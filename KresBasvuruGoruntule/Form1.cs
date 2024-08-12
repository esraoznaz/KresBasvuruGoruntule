using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
using System.Data; 
using System.Data.SqlClient;
using System.Drawing; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
using System.Windows.Forms; 
 
namespace KresBasvuruGoruntule 
{ 
	public partial class Form1 : Form 
	{

		//private DataGridView dataGridView1 = new DataGridView();
		private string connectionString = "Server=LAPTOP-3H9G77VD\\SQLEXPRESS;Database=Kres_Basvuru;Integrated Security=True";
		public Form1() 
		{ 
			InitializeComponent();

			Load += new EventHandler(Form1_Load);
			Controls.Add(dataGridView1); // Bu satırı kontrol edin ve eklemenin doğru yerde olduğundan emin olun
			dataGridView1.Dock = DockStyle.Fill;
		} 
         
		private void Form1_Load(object sender, EventArgs e) 
		{ 
			LoadData();
		}

		private void LoadData()
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string query = @"
                SELECT 
                    Cocuk_Bilgisi.Cocuk_Id,
                    Cocuk_Bilgisi.Cocuk_Adi_Soyadi,
                    Cocuk_Bilgisi.Cocuk_TC_No,
                    Cocuk_Bilgisi.Dogum_Tarihi,
                    Cocuk_Bilgisi.Cocuk_Cinsiyeti,
                    Cocuk_Bilgisi.Ev_Adresi,
                    Anne_Bilgisi.Anne_Adi_Soyadi,
                    Anne_Bilgisi.Anne_TC_No,
                    Anne_Bilgisi.Anne_Meslegi,
                    Anne_Bilgisi.Anne_Meslek_Tipi,
                    Anne_Bilgisi.Anne_Acik_Is_Adresi,
                    Anne_Bilgisi.Anne_Calisma_Saatleri,
                    Anne_Bilgisi.Anne_Cep_Telefonu,
                    Anne_Bilgisi.Anneye_Ulasilamadiginda_Irtibat_No,
                    Anne_Bilgisi.Anne_Durumu,
                    Baba_Bilgisi.Baba_Adi_Soyadi,
                    Baba_Bilgisi.Baba_TC_No,
                    Baba_Bilgisi.Baba_Meslegi,
                    Baba_Bilgisi.Baba_Meslek_Tipi,
                    Baba_Bilgisi.Baba_Acik_Is_Adresi,
                    Baba_Bilgisi.Baba_Calisma_Saatleri,
                    Baba_Bilgisi.Baba_Cep_Telefonu,
                    Baba_Bilgisi.Babaya_Ulasilamadiginda_Irtibat_No,
                    Baba_Bilgisi.Baba_Durumu,
                    Bakanin_Bilgisi.Emekli_Personel_Torun,
                    Bakanin_Bilgisi.Bakan_TC_No,
                    Bakanin_Bilgisi.Bakan_Telefon_Numarasi,
                    Basvuranin_Bilgisi.Telefon,
                    Cocuk_Harici_Bilgi.Cocuk_Kronik_Hastalik,
                    Cocuk_Harici_Bilgi.Cocuk_Alerji,
                    Cocuk_Harici_Bilgi.Cocuk_Davranis_Problemi,
                    Cocuk_Harici_Bilgi.Cocuk_Ozel_Durum
                FROM 
                    Cocuk_Bilgisi
                LEFT JOIN 
                    Anne_Bilgisi ON Cocuk_Bilgisi.Cocuk_Id = Anne_Bilgisi.Cocuk_Id
                LEFT JOIN 
                    Baba_Bilgisi ON Cocuk_Bilgisi.Cocuk_Id = Baba_Bilgisi.Cocuk_Id
                LEFT JOIN 
                    Bakanin_Bilgisi ON Cocuk_Bilgisi.Cocuk_Id = Bakanin_Bilgisi.Cocuk_Id
                LEFT JOIN 
                    Basvuranin_Bilgisi ON Cocuk_Bilgisi.Cocuk_Id = Basvuranin_Bilgisi.Cocuk_Id
                LEFT JOIN 
                    Cocuk_Harici_Bilgi ON Cocuk_Bilgisi.Cocuk_Id = Cocuk_Harici_Bilgi.Cocuk_Id;";

				SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
				DataTable dataTable = new DataTable();
				dataAdapter.Fill(dataTable);

				dataGridView1.DataSource = dataTable;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string cocukId = textBox1.Text;
			LoadFilteredData(cocukId);
		}

		private void LoadFilteredData(string cocukId)
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string query = @"
            SELECT 
                Cocuk_Bilgisi.Cocuk_Id,
                Cocuk_Bilgisi.Cocuk_Adi_Soyadi,
                Cocuk_Bilgisi.Cocuk_TC_No,
                Cocuk_Bilgisi.Dogum_Tarihi,
                Cocuk_Bilgisi.Cocuk_Cinsiyeti,
                Cocuk_Bilgisi.Ev_Adresi,
                Anne_Bilgisi.Anne_Adi_Soyadi,
                Anne_Bilgisi.Anne_TC_No,
                Anne_Bilgisi.Anne_Meslegi,
                Anne_Bilgisi.Anne_Meslek_Tipi,
                Anne_Bilgisi.Anne_Acik_Is_Adresi,
                Anne_Bilgisi.Anne_Calisma_Saatleri,
                Anne_Bilgisi.Anne_Cep_Telefonu,
                Anne_Bilgisi.Anneye_Ulasilamadiginda_Irtibat_No,
                Anne_Bilgisi.Anne_Durumu,
                Baba_Bilgisi.Baba_Adi_Soyadi,
                Baba_Bilgisi.Baba_TC_No,
                Baba_Bilgisi.Baba_Meslegi,
                Baba_Bilgisi.Baba_Meslek_Tipi,
                Baba_Bilgisi.Baba_Acik_Is_Adresi,
                Baba_Bilgisi.Baba_Calisma_Saatleri,
                Baba_Bilgisi.Baba_Cep_Telefonu,
                Baba_Bilgisi.Babaya_Ulasilamadiginda_Irtibat_No,
                Baba_Bilgisi.Baba_Durumu,
                Bakanin_Bilgisi.Emekli_Personel_Torun,
                Bakanin_Bilgisi.Bakan_TC_No,
                Bakanin_Bilgisi.Bakan_Telefon_Numarasi,
                Basvuranin_Bilgisi.Telefon,
                Cocuk_Harici_Bilgi.Cocuk_Kronik_Hastalik,
                Cocuk_Harici_Bilgi.Cocuk_Alerji,
                Cocuk_Harici_Bilgi.Cocuk_Davranis_Problemi,
                Cocuk_Harici_Bilgi.Cocuk_Ozel_Durum
            FROM 
                Cocuk_Bilgisi
            LEFT JOIN 
                Anne_Bilgisi ON Cocuk_Bilgisi.Cocuk_Id = Anne_Bilgisi.Cocuk_Id
            LEFT JOIN 
                Baba_Bilgisi ON Cocuk_Bilgisi.Cocuk_Id = Baba_Bilgisi.Cocuk_Id
            LEFT JOIN 
                Bakanin_Bilgisi ON Cocuk_Bilgisi.Cocuk_Id = Bakanin_Bilgisi.Cocuk_Id
            LEFT JOIN 
                Basvuranin_Bilgisi ON Cocuk_Bilgisi.Cocuk_Id = Basvuranin_Bilgisi.Cocuk_Id
            LEFT JOIN 
                Cocuk_Harici_Bilgi ON Cocuk_Bilgisi.Cocuk_Id = Cocuk_Harici_Bilgi.Cocuk_Id
            WHERE 
                Cocuk_Bilgisi.Cocuk_Id = @Cocuk_Id";

				SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
				dataAdapter.SelectCommand.Parameters.AddWithValue("@Cocuk_Id", cocukId);
				DataTable dataTable = new DataTable();
				dataAdapter.Fill(dataTable);

				dataGridView1.DataSource = dataTable;
			}
		}
	} 
} 
