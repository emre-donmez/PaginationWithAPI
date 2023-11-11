namespace PaginationAPI.Models.Dto
{
    public class PagedRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortOrder { get; set; }
    }
}
