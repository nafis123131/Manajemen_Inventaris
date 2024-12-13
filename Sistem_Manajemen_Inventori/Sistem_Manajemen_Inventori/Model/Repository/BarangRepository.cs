using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Sistem_Manajemen_Inventori.Model.Entity;
using Sistem_Manajemen_Inventori.Model.Contex;


namespace Sistem_Manajemen_Inventori.Model.Repository
{
    public class BarangRepository
    {
        private SqlConnection _conn;

        public BarangRepository(SqlConnection conn)
        {
            _conn = conn;
        }
        public int Create(Barang brg)
        {
            int result = 0;
            // deklarasi perintah SQL
            string sql = @"INSERT INTO barang (id_barang, nama_barang, category, jml_barang, hrg_barang, status_barang, tgl_barang) VALUES (@id_barang, @nama_barang, @category, @jml_barang, @hrg_barang, @status_barang)";
            // membuat objek command menggunakan blok using
            using (SqlCommand cmd = new SqlCommand(sql, _conn))
            {
                // mendaftarkan parameter dan mengeset nilainya
                cmd.Parameters.AddWithValue("@npm", brg.Npm);
                cmd.Parameters.AddWithValue("@nama", mhs.Nama);
                cmd.Parameters.AddWithValue("@angkatan", mhs.Angkatan);
                try
                {
                    // jalankan perintah INSERT dan tampung hasilnya ke dalam variabel result
                result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }
            }
            return result;
        }
    }
}
