namespace pacsapi.Models
{
    public class BarangModelListAndGetByKodeBarang
    {
        public string Kode_Barang { get; set; } = "";
        public string Nama_Barang { get; set; } = "";
        public float Qty_Stok { get; set; }
        public int Penerimaan_ID { get; set; }
    }

    public class UpdateBarang
    {
        public int? Penerimaan_ID { get; set; }
        public string Kode_Barang { get; set; } = "";

    }
}
