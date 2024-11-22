namespace Electrolux.Api.ODataApi.Dto
{
    public class BackEndApiResponseDto<T>
    {
        public bool Success { get; set; }
        public Records<T> Records { get; set; }
    }

    public class Records<T>
    {
        public IEnumerable<T> Data { get; set; }
        public PageInfo PageInfo { get; set; }
    }

    public class PageInfo
    {
        public bool HasNextPage { get; set; }
    }

}
