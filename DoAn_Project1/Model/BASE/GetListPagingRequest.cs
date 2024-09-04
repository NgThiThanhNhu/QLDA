namespace Model.BASE
{
    public class GetListPagingRequest : BaseRequest
    {
        public string? TextSearch { get; set; } = string.Empty;
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
        public DateTime? NgayBaoCao { get; set; }
        public int PageIndex { get; set; }
        public int RowPerPage { get; set; } = 10;
    }
}
