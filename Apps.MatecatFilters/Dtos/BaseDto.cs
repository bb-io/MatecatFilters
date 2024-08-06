namespace Apps.MatecatFilters.Dtos
{
    public class BaseDto
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Log { get; set; }
        public string ErrorMessage { get; set; }
    }
}
