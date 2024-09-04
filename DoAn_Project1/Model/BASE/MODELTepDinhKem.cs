namespace Model.BASE
{
    public class MODELTepDinhKem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid LienKetId { get; set; }
        public string TenFile { get; set; }
        public string TenMoRong { get; set; }
        public double? DoLon { get; set; }
        public string Url { get; set; }
        public string TenTapTinFull { get; set; }
    }
}
