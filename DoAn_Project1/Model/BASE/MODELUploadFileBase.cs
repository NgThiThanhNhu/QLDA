namespace Model.BASE
{
    public class MODELUploadFileBase
    {
        public double FileSizeLimit { get; set; } //Megabyte
        public bool MultiFile { get; set; }
        public string FileValidateText { get; set; }
        public string[] FileValidate { get; set; }
        public List<MODELTepDinhKem> ListTepDinhKem { get; set; } //Tệp đính kèm hiện có
    }
}
